using Google.Apis.Calendar.v3.Data;
using GoogleCalendar.Secondary_Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GoogleCalendar
{
    public partial class EditEventsForm : Form
    {
        public DateTime Date { get; set; }
        public List<FlatButton> Buttons { get; set; }

        private MainForm owner;
        public EditEventsForm()
        {
            InitializeComponent();
        }

        public EditEventsForm(DateTime date, MainForm owner)
        {
            InitializeComponent();

            this.owner = owner;

            Date = date;

            Buttons = new List<FlatButton>();

            foreach (var scheduler in MainForm.Schedulers)
            {
                if (scheduler.Selected)
                    foreach (var evt in scheduler.Events)
                    {
                        if (evt.Start.Date == date.ToString("yyyy-MM-dd"))
                            AddEvent(evt, scheduler);
                        else
                        {
                            if (GoogleCalendar.Controls.Calendar.EachDay(evt.Start, evt.End).Contains(date))
                                AddEvent(evt, scheduler);
                        }
                    }
            }
        }

        private void AddEventBtn_Click(object sender, EventArgs e)
        {
            try
            {
                new AddEventForm(owner.PanelChecker, owner.UpdateTable, Date).ShowDialog(this);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Все календари неактивны или нет созданных. Создайте новый календарь или активируйте уже созданный.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddEvent(Event evt, Scheduler scheduler)
        {
            var btnEvent = new FlatButton()
            {
                Text = evt.Summary,
                ForeColor = scheduler.Color.Equals(Color.Black) ? Color.White : Color.Black,
                BackColor = scheduler.Color,
                Width = eventsPanel.Width - 10,
                Item = Tuple.Create(evt, scheduler)
            };

            Buttons.Add(btnEvent);
            btnEvent.Click += ShowInfo;
            eventsPanel.Controls.Add(btnEvent);
        }

        public void DeleteEvent(Scheduler scheduler, Event evt)
        {
            scheduler.Events.Remove(evt);

            var delBtn = Buttons.Find(btn => btn.Item.Equals(Tuple.Create(evt, scheduler)));

            Buttons.Remove(delBtn);
            eventsPanel.Controls.Remove(delBtn);

            owner.UpdateTable(null, null);

            if (MainForm.IsOnlineMode)
            {
                var evtId = MainForm.Service.Events.List(scheduler.Calendar.Id).ExecuteAsync().Result.Items
                    .First(e => e.Summary == evt.Summary && e.Description == evt.Description && e.Start.Date == evt.Start.Date).Id;
                MainForm.Service.Events.Delete(scheduler.Calendar.Id, evtId).ExecuteAsync();
            }
        }

        private void ShowInfo(object sender, EventArgs e)
        {
            var btn = sender as FlatButton;
            new EventInfo(btn.Item as Tuple<Event, Scheduler>).ShowDialog(this);
        }

        private void EditEventsForm_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
