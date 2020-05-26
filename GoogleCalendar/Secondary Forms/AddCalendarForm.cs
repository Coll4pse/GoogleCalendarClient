using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoogleCalendar
{
    public partial class AddCalendarForm : Form
    {
        public AddCalendarForm()
        {
            InitializeComponent();
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

        private void flatButton1_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                var newCalendar = new Scheduler(CalendarRequests.CreateCalendar(nameTextBox.Text, descTextBox.Text));

                MainForm.Schedulers.Add(newCalendar);
                var owner = Owner as MainForm;
                owner.AddToPanel(newCalendar);
                Close();
            }
        }

        private void AddCalendarForm_MouseDown(object sender, MouseEventArgs e)
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
    }
}
