namespace GoogleCalendar
{
    partial class AuthorizeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OffButton = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.errorMessage = new System.Windows.Forms.Label();
            this.exitBtn = new GoogleCalendar.FlatButton();
            this.authButton = new GoogleCalendar.FlatButton();
            this.SuspendLayout();
            // 
            // OffButton
            // 
            this.OffButton.AutoSize = true;
            this.OffButton.ForeColor = System.Drawing.Color.CadetBlue;
            this.OffButton.Location = new System.Drawing.Point(109, 226);
            this.OffButton.Name = "OffButton";
            this.OffButton.Size = new System.Drawing.Size(167, 13);
            this.OffButton.TabIndex = 1;
            this.OffButton.Text = "(Запуск в автономном режиме)";
            this.OffButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OffButton.Click += new System.EventHandler(this.OffButton_Click);
            this.OffButton.MouseEnter += new System.EventHandler(this.OffButton_MouseEnter);
            this.OffButton.MouseLeave += new System.EventHandler(this.OffButton_MouseLeave);
            // 
            // usernameBox
            // 
            this.usernameBox.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usernameBox.ForeColor = System.Drawing.Color.DarkGray;
            this.usernameBox.Location = new System.Drawing.Point(107, 134);
            this.usernameBox.Multiline = true;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(172, 32);
            this.usernameBox.TabIndex = 11;
            this.usernameBox.Text = "Введите никнейм";
            this.usernameBox.WordWrap = false;
            this.usernameBox.Enter += new System.EventHandler(this.usernameBox_Enter);
            this.usernameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AuthorizeForm_KeyDown);
            this.usernameBox.Leave += new System.EventHandler(this.usernameBox_Leave);
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorMessage.Location = new System.Drawing.Point(79, 243);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(230, 26);
            this.errorMessage.TabIndex = 12;
            this.errorMessage.Text = "Неправильно введен никнейм.\r\nОн должен содержать хотя бы один символ";
            this.errorMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.errorMessage.Visible = false;
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.Color.DarkRed;
            this.exitBtn.Item = null;
            this.exitBtn.Location = new System.Drawing.Point(357, 0);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(0);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(24, 24);
            this.exitBtn.TabIndex = 10;
            this.exitBtn.Text = "X";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            this.exitBtn.MouseEnter += new System.EventHandler(this.exitBtn_MouseEnter);
            this.exitBtn.MouseLeave += new System.EventHandler(this.exitBtn_MouseLeave);
            // 
            // authButton
            // 
            this.authButton.BackColor = System.Drawing.Color.CadetBlue;
            this.authButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authButton.ForeColor = System.Drawing.Color.White;
            this.authButton.Item = null;
            this.authButton.Location = new System.Drawing.Point(107, 172);
            this.authButton.Name = "authButton";
            this.authButton.Size = new System.Drawing.Size(172, 51);
            this.authButton.TabIndex = 0;
            this.authButton.Text = "Авторизация";
            this.authButton.Click += new System.EventHandler(this.authButton_Click);
            // 
            // AuthorizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(380, 380);
            this.ControlBox = false;
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.OffButton);
            this.Controls.Add(this.authButton);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthorizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthorizeForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AuthorizeForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AuthorizeForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlatButton authButton;
        private System.Windows.Forms.Label OffButton;
        private FlatButton exitBtn;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label errorMessage;
    }
}