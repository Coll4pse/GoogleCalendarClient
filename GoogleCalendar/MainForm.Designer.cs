namespace GoogleCalendar
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.calendarsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.swipeRight = new System.Windows.Forms.Button();
            this.swipeLeft = new System.Windows.Forms.Button();
            this.currDateLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SyncButton = new GoogleCalendar.FlatButton();
            this.exitBtn = new GoogleCalendar.FlatButton();
            this.addCalendarBtn = new GoogleCalendar.FlatButton();
            this.calendar2 = new GoogleCalendar.Controls.Calendar();
            this.SuspendLayout();
            // 
            // calendarsPanel
            // 
            this.calendarsPanel.AutoScroll = true;
            this.calendarsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendarsPanel.Location = new System.Drawing.Point(12, 48);
            this.calendarsPanel.Name = "calendarsPanel";
            this.calendarsPanel.Size = new System.Drawing.Size(200, 390);
            this.calendarsPanel.TabIndex = 2;
            // 
            // swipeRight
            // 
            this.swipeRight.Location = new System.Drawing.Point(600, 444);
            this.swipeRight.Name = "swipeRight";
            this.swipeRight.Size = new System.Drawing.Size(19, 23);
            this.swipeRight.TabIndex = 6;
            this.swipeRight.Text = ">";
            this.swipeRight.UseVisualStyleBackColor = true;
            this.swipeRight.Click += new System.EventHandler(this.swipeRight_Click);
            // 
            // swipeLeft
            // 
            this.swipeLeft.Location = new System.Drawing.Point(435, 444);
            this.swipeLeft.Name = "swipeLeft";
            this.swipeLeft.Size = new System.Drawing.Size(21, 23);
            this.swipeLeft.TabIndex = 7;
            this.swipeLeft.Text = "<";
            this.swipeLeft.UseVisualStyleBackColor = true;
            this.swipeLeft.Click += new System.EventHandler(this.swipeLeft_Click);
            // 
            // currDateLabel
            // 
            this.currDateLabel.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currDateLabel.Location = new System.Drawing.Point(462, 444);
            this.currDateLabel.Name = "currDateLabel";
            this.currDateLabel.Size = new System.Drawing.Size(132, 23);
            this.currDateLabel.TabIndex = 8;
            this.currDateLabel.Text = "Year, Month";
            this.currDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // SyncButton
            // 
            this.SyncButton.BackColor = System.Drawing.Color.Tomato;
            this.SyncButton.ForeColor = System.Drawing.Color.White;
            this.SyncButton.Item = null;
            this.SyncButton.Location = new System.Drawing.Point(218, 12);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(593, 30);
            this.SyncButton.TabIndex = 10;
            this.SyncButton.Text = "Синхронизировать с Google";
            this.SyncButton.Visible = false;
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Item = null;
            this.exitBtn.Location = new System.Drawing.Point(814, 0);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(0);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(24, 24);
            this.exitBtn.TabIndex = 9;
            this.exitBtn.Text = "X";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // addCalendarBtn
            // 
            this.addCalendarBtn.BackColor = System.Drawing.Color.Tomato;
            this.addCalendarBtn.ForeColor = System.Drawing.Color.White;
            this.addCalendarBtn.Item = null;
            this.addCalendarBtn.Location = new System.Drawing.Point(12, 12);
            this.addCalendarBtn.Name = "addCalendarBtn";
            this.addCalendarBtn.Size = new System.Drawing.Size(200, 30);
            this.addCalendarBtn.TabIndex = 5;
            this.addCalendarBtn.Text = "Добавить календарь";
            this.addCalendarBtn.Click += new System.EventHandler(this.addCalendarBtn_Click);
            // 
            // calendar2
            // 
            this.calendar2.BackColor = System.Drawing.Color.Transparent;
            this.calendar2.Location = new System.Drawing.Point(218, 48);
            this.calendar2.Name = "calendar2";
            this.calendar2.Size = new System.Drawing.Size(614, 390);
            this.calendar2.TabIndex = 4;
            this.calendar2.Load += new System.EventHandler(this.calendar2_Load);
            this.calendar2.Paint += new System.Windows.Forms.PaintEventHandler(this.calendar2_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 476);
            this.Controls.Add(this.SyncButton);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.currDateLabel);
            this.Controls.Add(this.swipeLeft);
            this.Controls.Add(this.swipeRight);
            this.Controls.Add(this.addCalendarBtn);
            this.Controls.Add(this.calendar2);
            this.Controls.Add(this.calendarsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.Calendar calendar2;
        private FlatButton addCalendarBtn;
        private System.Windows.Forms.FlowLayoutPanel calendarsPanel;
        private System.Windows.Forms.Button swipeRight;
        private System.Windows.Forms.Button swipeLeft;
        private System.Windows.Forms.Label currDateLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private FlatButton exitBtn;
        private FlatButton SyncButton;
        private System.Windows.Forms.Timer timer;
    }
}

