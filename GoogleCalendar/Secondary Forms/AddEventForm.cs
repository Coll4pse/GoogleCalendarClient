using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GoogleCalendar.Secondary_Forms
{
    public partial class AddEventForm : Form
    {
        public event EventHandler AddEvent;

        public AddEventForm(Func<Scheduler, bool> panelChecker, EventHandler tableUpdate, DateTime date)
        {
            InitializeComponent();

            schedulerList.Items.AddRange(MainForm.Schedulers
                .Where(scheduler => panelChecker(scheduler) && scheduler.Calendar.AccessRole != "reader")
                .ToArray());

            schedulerList.SelectedItem = schedulerList.Items[0];

            startDate.Text = date.ToString("dd MMM yyyy");
            endDatePicker.MinDate = date;
            endDatePicker.Value = date;

            AddEvent += tableUpdate;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            var owner = Owner as EditEventsForm;
            var scheduler = schedulerList.SelectedItem as Scheduler;


            var start = owner.Date;
            var end = endDatePicker.Value;

            if (withTime.Checked)
            {
                start = start.AddHours(startTimePicker.Value.Hour);
                start = start.AddMinutes(startTimePicker.Value.Minute);

                end = end.AddHours(endTimePicker.Value.Hour);
                end = end.AddMinutes(endTimePicker.Value.Minute);
            }

            if (start > end)
            {
                MessageBox.Show("Время начала события не может быть раньше конца события.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newEvent = CalendarRequests.CreateEvent(nameTextBox.Text, descTextBox.Text, start, end, withTime.Checked);

            if (MainForm.IsOnlineMode)
                newEvent.Id = MainForm.Service.Events.Insert(newEvent, scheduler.Calendar.Id).ExecuteAsync().Result.Id;

            owner.AddEvent(newEvent, scheduler);
            scheduler.Events.Add(newEvent);


            AddEvent(this, new EventArgs());

            Close();
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            if (nameTextBox.Modified)
                return;
            nameTextBox.Text = "";
            nameTextBox.ForeColor = Color.Black;
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length != 0)
                return;
            nameTextBox.Text = "Название";
            nameTextBox.ForeColor = Color.DarkGray;
        }

        private void descTextBox_Enter(object sender, EventArgs e)
        {
            if (descTextBox.Modified)
                return;
            descTextBox.Text = "";
            descTextBox.ForeColor = Color.Black;
        }

        private void descTextBox_Leave(object sender, EventArgs e)
        {
            if (descTextBox.Text.Length != 0)
                return;
            descTextBox.Text = "Описание";
            descTextBox.ForeColor = Color.DarkGray;
        }

        private void AddEventForm_MouseDown(object sender, MouseEventArgs e)
        {
            ActiveControl = null;
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void withTime_CheckedChanged(object sender, EventArgs e)
        {
            if (withTime.Checked)
            {
                startDate.Location = new Point(37, 264);
                endDatePicker.Location = new Point(174, 264);
                startTimePicker.Visible = true;
                endTimePicker.Visible = true;
            }
            else
            {
                startDate.Location = new Point(81, 264);
                endDatePicker.Location = new Point(210, 264);
                startTimePicker.Visible = false;
                endTimePicker.Visible = false;
            }
        }
    }
}
