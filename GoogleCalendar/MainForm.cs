using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using GoogleCalendar.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GoogleCalendar
{
    public partial class MainForm : Form
    {
        public static string UserName { private get; set; }
        public static UserCredential UserSecret { private get; set; }
        public static bool IsOnlineMode { get; set; }

        public static List<Scheduler> Schedulers { get; set; }

        public static CalendarService Service { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            Animator.Start();

            Service = IsOnlineMode ? new CalendarService(new BaseClientService.Initializer { HttpClientInitializer = UserSecret, ApplicationName = "Google Calendar Client" }) : null;

            Schedulers = new List<Scheduler>();
        }

        public void AddToPanel(Scheduler calendar)
        {
            var colorChechBox = new ColorCheckBox(calendar);

            colorChechBox.CheckStateChanged += UpdateTable;

            var changeColorBtn = new ChangeColorButton(colorChechBox);

            var delBtn = new DelButton(changeColorBtn);

            delBtn.Click += DelBtn_Click;
            changeColorBtn.Click += ChangeColorBtn_Click;

            calendarsPanel.Controls.Add(colorChechBox);
            calendarsPanel.Controls.Add(changeColorBtn);
            if (!calendar.Calendar?.Primary ?? true)
                calendarsPanel.Controls.Add(delBtn);
        }

        private void ChangeColorBtn_Click(object sender, EventArgs e)
        {
            var colorCheckBox = (sender as ChangeColorButton).Item;
            var previousColor = colorDialog.Color;
            colorDialog.Color = colorCheckBox.BoxColor;
            colorDialog.ShowDialog();

            if (previousColor == colorDialog.Color)
                return;

            colorCheckBox.BoxColor = colorDialog.Color;
            colorCheckBox.Item.ChangeColor(colorDialog.Color);

            colorCheckBox.Invalidate();
            UpdateTable(null, null);

            if (IsOnlineMode)
            {
                var colorUpdRequest = Service.CalendarList.Update(colorCheckBox.Item.Calendar, colorCheckBox.Item.Calendar.Id);
                colorUpdRequest.ColorRgbFormat = true;
                colorUpdRequest.ExecuteAsync();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as DelButton;
            var colorEditBtn = btn.Item;
            var colorCheckBox = colorEditBtn.Item;

            calendarsPanel.Controls.Remove(colorCheckBox);
            calendarsPanel.Controls.Remove(colorEditBtn);
            calendarsPanel.Controls.Remove(btn);

            Schedulers.Remove(colorCheckBox.Item);

            if (IsOnlineMode)
            {
                CalendarRequests.RemoveCalendar(colorCheckBox.Item);
            }

            UpdateTable(null, null);
        }

        public void EditEvent(DateTime date)
        {
            new EditEventsForm(date, this).ShowDialog();
        }

        public bool PanelChecker(Scheduler scheduler)
        {
            foreach (var control in calendarsPanel.Controls)
            {
                if (control is ColorCheckBox checkBox)
                    if (checkBox.Item.Calendar.Equals(scheduler.Calendar))
                        return checkBox.Checked;
            }
            return false;
        }

        private void ChangePanelBoxColor(Color newColor, string id)
        {
            foreach (var control in calendarsPanel.Controls)
            {
                if (control is ColorCheckBox cb)
                    if (cb.Item.Calendar.Id == id)
                    {
                        cb.BoxColor = newColor;
                        cb.Invalidate();
                        break;
                    }
            }
        }

        public void UpdateTable(object sender, EventArgs e)
        {
            calendar2.FillTable();
        }

        private void addCalendarBtn_Click(object sender, EventArgs e)
        {
            new AddCalendarForm().ShowDialog(this);
        }

        private void calendar2_Load(object sender, EventArgs e)
        {
            currDateLabel.Text = String.Format("{0}, {1}", calendar2.SelectedYear, calendar2.SelectedMonth);
        }

        private void swipeRight_Click(object sender, EventArgs e)
        {
            calendar2.NextMonth();
        }

        private void swipeLeft_Click(object sender, EventArgs e)
        {
            calendar2.PreviousMonth();
        }

        private void calendar2_Paint(object sender, PaintEventArgs e)
        {
            calendar2_Load(sender, e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            if (File.Exists($@".\saves\{UserName}.json"))
            {
                Schedulers.AddRange(JsonConvert.DeserializeObject<Scheduler[]>(File.ReadAllText($@".\saves\{UserName}.json")));

                foreach (var scheduler in Schedulers)
                    AddToPanel(scheduler);
            }

            if (IsOnlineMode)
            {
                AutoSync();
                SyncButton.Visible = true;
            }

            UpdateTable(null, null);
        }

        private async void SynchronizationAsync()
        {
            var request = await Service.CalendarList.List().ExecuteAsync();
            var calendars = request.Items;
            calendars.Remove(calendars.First(calendar => calendar.Id == "addressbook#contacts@group.v.calendar.google.com"));

            foreach (var scheduler in Schedulers)
            {
                if (calendars.Select(calendar => calendar.Id).Contains(scheduler.Calendar.Id))
                {
                    if (scheduler.Calendar.AccessRole == "reader")
                        continue;
                    var events = Service.Events.List(scheduler.Calendar.Id).ExecuteAsync().Result.Items;
                    /// Сравнение текущих ивентов с гугловскими
                    for (var i = 0; i < scheduler.Events.Count; i++)
                    {
                        var thisEvent = scheduler.Events[i];

                        if (events.Select(evt => evt.Id).Contains(thisEvent.Id))
                        {
                            var googleEvent = events.First(@event => @event.Id == thisEvent.Id);

                            if (googleEvent.Updated >= thisEvent.Updated)
                                lock (scheduler.Events)
                                {
                                    thisEvent = googleEvent;
                                }
                            else
                                await Service.Events.Patch(thisEvent, scheduler.Calendar.Id, thisEvent.Id).ExecuteAsync();
                        }
                        else if (thisEvent.Id != null)
                            lock (scheduler.Events)
                            {
                                scheduler.Events.Remove(thisEvent);
                            }
                        else
                            await Service.Events.Insert(thisEvent, scheduler.Calendar.Id).ExecuteAsync();
                    }

                    ///Сравниваем гугловские с текущими
                    foreach (var googleEvent in events)
                    {
                        if (!scheduler.Events.Select(e => e.Id).Contains(googleEvent.Id))
                            scheduler.Events.Add(googleEvent);
                    }

                    var googleCalendar = calendars.First(calendar => calendar.Id == scheduler.Calendar.Id);

                    if (googleCalendar.BackgroundColor != scheduler.Calendar.BackgroundColor)
                    {
                        scheduler.ChangeColor(ColorTranslator.FromHtml(googleCalendar.BackgroundColor));
                        ChangePanelBoxColor(ColorTranslator.FromHtml(googleCalendar.BackgroundColor), scheduler.Calendar.Id);
                    }

                }
                else
                {
                    var newCalendar = new Google.Apis.Calendar.v3.Data.Calendar
                    {
                        Summary = scheduler.Calendar.Summary,
                        Description = scheduler.Calendar.Description
                    };

                    scheduler.Calendar.Id = Service.Calendars.Insert(newCalendar).ExecuteAsync().Result.Id;
                    scheduler.Calendar.Selected = true;
                    scheduler.Calendar.ETag = null;
                    var req = Service.CalendarList.Update(scheduler.Calendar, scheduler.Calendar.Id);
                    req.ColorRgbFormat = true;
                    await req.ExecuteAsync();

                    foreach (var @event in scheduler.Events)
                        @event.Id = Service.Events.Insert(@event, scheduler.Calendar.Id).ExecuteAsync().Result.Id;
                }
            }

            foreach (var googleCalendar in calendars)
            {
                if (!Schedulers.Select(scheduler => scheduler.Calendar.Id).Contains(googleCalendar.Id))
                    lock (Schedulers)
                    {
                        var scheduler = new Scheduler(googleCalendar, Service.Events.List(googleCalendar.Id).ExecuteAsync().Result.Items.ToArray());
                        Schedulers.Add(scheduler);
                        AddToPanel(scheduler);
                    }
            }

            Invalidate();
            UpdateTable(null, null);
        }

        private void AutoSync()
        {
            SynchronizationAsync();
            timer.Interval = (int)new TimeSpan(0, 3, 0).TotalMilliseconds;
            timer.Tick += (sender, args) =>
            {
                if (Application.OpenForms.Count == 1)
                    SynchronizationAsync();
            };
            timer.Start();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите выйти?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            if (!Directory.Exists(@".\saves"))
                Directory.CreateDirectory(@".\saves");

            File.WriteAllText($@".\saves\{UserName}.json", JsonConvert.SerializeObject(Schedulers, Formatting.Indented));

            if (Directory.Exists($@".\token.json"))
                Directory.Delete($@".\token.json", true);

            Application.Exit();
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            SynchronizationAsync();
            timer.Interval = timer.Interval;
            timer.Start();
        }
    }
}
