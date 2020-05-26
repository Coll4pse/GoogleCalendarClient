using Google.Apis.Calendar.v3.Data;
using System;
using System.Windows.Forms;

namespace GoogleCalendar.Secondary_Forms
{
    public partial class EventInfo : Form
    {
        private Scheduler scheduler;
        private Event evt;

        public EventInfo(Tuple<Event, Scheduler> e)
        {
            InitializeComponent();

            evt = e.Item1;
            scheduler = e.Item2;

            if (evt.Start.Date == evt.End.Date && evt.Start.Date != null)
                infoLabel.Text = String.Format("Название события: {0}\nОписание события: {1}\nДата события: {2} ", evt.Summary, evt.Description, evt.Start.Date);
            else if (evt.Start.Date != null)
            {
                if (DateTime.Parse(evt.End.Date).Subtract(DateTime.Parse(evt.Start.Date)).Days == 1)
                    infoLabel.Text = String.Format("Название события: {0}\nОписание события: {1}\nДата события: {2} ", evt.Summary, evt.Description, evt.Start.Date);
                else
                    infoLabel.Text = String.Format($"Название события: {evt.Summary}\nОписание события: {evt.Description}\nДата события: {evt.Start.Date} - {evt.End.Date}");
            }
            else
                infoLabel.Text = String.Format($"Название события: { evt.Summary}\nОписание события: { evt.Description}\nДата события: {((DateTime)evt.Start.DateTime).ToString("HH:mm yyyy-MM-dd")} - {((DateTime)evt.End.DateTime).ToString("HH:mm yyyy-MM-dd")}");

            if (scheduler.Calendar.AccessRole == "reader")
                deleteEvtBtn.Visible = false;
        }

        private void deleteEvtBtn_Click(object sender, EventArgs e)
        {
            (Owner as EditEventsForm).DeleteEvent(scheduler, evt);
            Close();
        }

        private void EventInfo_MouseDown(object sender, MouseEventArgs e)
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
