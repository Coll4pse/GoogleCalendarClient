using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GoogleCalendar
{
    public partial class AuthorizeForm : Form
    {
        public AuthorizeForm()
        {
            InitializeComponent();
        }

        private void authButton_Click(object sender, EventArgs e)
        {
            ClientSecrets secrets;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                secrets = GoogleClientSecrets.Load(stream).Secrets;
            }

            if (!usernameBox.Modified)
            {
                errorMessage.Visible = true;
                return;
            }

            var scope = new[] { CalendarService.Scope.Calendar };

            MainForm.UserName = usernameBox.Text;
            MainForm.UserSecret = GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, scope, usernameBox.Text, CancellationToken.None, new FileDataStore("token.json", true)).Result;
            MainForm.IsOnlineMode = true;

            this.Close();
        }

        private void OffButton_MouseEnter(object sender, EventArgs e)
        {
            var label = sender as Label;
            label.Font = new Font(label.Font, FontStyle.Underline);
        }

        private void OffButton_MouseLeave(object sender, EventArgs e)
        {
            var label = sender as Label;
            label.Font = new Font(label.Font, FontStyle.Regular);
        }

        private void OffButton_Click(object sender, EventArgs e)
        {
            if (!usernameBox.Modified)
            {
                errorMessage.Visible = true;
                return;
            }

            MainForm.UserName = usernameBox.Text;
            this.Close();
        }

        private void AuthorizeForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usernameBox_Enter(object sender, EventArgs e)
        {
            if (usernameBox.Modified)
                return;
            usernameBox.Text = "";
            usernameBox.ForeColor = Color.Black;
        }

        private void usernameBox_Leave(object sender, EventArgs e)
        {
            if (usernameBox.Text != "")
                return;
            usernameBox.Text = "Введите никнейм";
            usernameBox.ForeColor = Color.DarkGray;
        }

        private void exitBtn_MouseEnter(object sender, EventArgs e)
        {
            exitBtn.BackColor = Color.Red;
            exitBtn.ForeColor = Color.White;
        }

        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            exitBtn.BackColor = BackColor;
            exitBtn.ForeColor = Color.DarkRed;
        }

        private void AuthorizeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
                Application.Exit();
        }
    }
}
