namespace GoogleCalendar.Secondary_Forms
{
    partial class AddEventForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.schedulerList = new System.Windows.Forms.ComboBox();
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.createBtn = new GoogleCalendar.FlatButton();
            this.exitBtn = new GoogleCalendar.FlatButton();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.TextBox();
            this.withTime = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(98, 246);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 13);
            label1.TabIndex = 14;
            label1.Text = "Начало";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(229, 246);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 13);
            label2.TabIndex = 15;
            label2.Text = "Конец";
            // 
            // schedulerList
            // 
            this.schedulerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schedulerList.Location = new System.Drawing.Point(63, 215);
            this.schedulerList.Name = "schedulerList";
            this.schedulerList.Size = new System.Drawing.Size(255, 21);
            this.schedulerList.TabIndex = 6;
            // 
            // descTextBox
            // 
            this.descTextBox.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.descTextBox.Location = new System.Drawing.Point(63, 69);
            this.descTextBox.Multiline = true;
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(255, 140);
            this.descTextBox.TabIndex = 8;
            this.descTextBox.Text = "Описание";
            this.descTextBox.Enter += new System.EventHandler(this.descTextBox_Enter);
            this.descTextBox.Leave += new System.EventHandler(this.descTextBox_Leave);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.nameTextBox.Location = new System.Drawing.Point(63, 31);
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(255, 32);
            this.nameTextBox.TabIndex = 7;
            this.nameTextBox.Text = "Название";
            this.nameTextBox.Enter += new System.EventHandler(this.nameTextBox_Enter);
            this.nameTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
            // 
            // createBtn
            // 
            this.createBtn.BackColor = System.Drawing.Color.Tomato;
            this.createBtn.ForeColor = System.Drawing.Color.White;
            this.createBtn.Item = null;
            this.createBtn.Location = new System.Drawing.Point(63, 310);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(255, 30);
            this.createBtn.TabIndex = 9;
            this.createBtn.Text = "Создать событие";
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Item = null;
            this.exitBtn.Location = new System.Drawing.Point(360, 0);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(0);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(24, 24);
            this.exitBtn.TabIndex = 10;
            this.exitBtn.Text = "X";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // endDatePicker
            // 
            this.endDatePicker.CustomFormat = "dd MMM yyyy";
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDatePicker.Location = new System.Drawing.Point(210, 264);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(88, 20);
            this.endDatePicker.TabIndex = 16;
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "HH:mm";
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(261, 264);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(57, 20);
            this.endTimePicker.TabIndex = 17;
            this.endTimePicker.Value = new System.DateTime(2020, 3, 31, 0, 0, 0, 0);
            this.endTimePicker.Visible = false;
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "HH:mm";
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(116, 264);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(52, 20);
            this.startTimePicker.TabIndex = 18;
            this.startTimePicker.Value = new System.DateTime(2020, 3, 31, 0, 0, 0, 0);
            this.startTimePicker.Visible = false;
            // 
            // startDate
            // 
            this.startDate.BackColor = System.Drawing.Color.White;
            this.startDate.Location = new System.Drawing.Point(82, 264);
            this.startDate.Name = "startDate";
            this.startDate.ReadOnly = true;
            this.startDate.Size = new System.Drawing.Size(80, 20);
            this.startDate.TabIndex = 19;
            this.startDate.Text = "31 мар 2020";
            this.startDate.WordWrap = false;
            // 
            // withTime
            // 
            this.withTime.AutoSize = true;
            this.withTime.Location = new System.Drawing.Point(128, 290);
            this.withTime.Name = "withTime";
            this.withTime.Size = new System.Drawing.Size(111, 17);
            this.withTime.TabIndex = 20;
            this.withTime.Text = "Добавить время";
            this.withTime.UseVisualStyleBackColor = true;
            this.withTime.CheckedChanged += new System.EventHandler(this.withTime_CheckedChanged);
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.withTime);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.descTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.schedulerList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEventForm";
            this.Text = "AddEventForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddEventForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox schedulerList;
        protected FlatButton createBtn;
        protected System.Windows.Forms.TextBox descTextBox;
        protected System.Windows.Forms.TextBox nameTextBox;
        private FlatButton exitBtn;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.TextBox startDate;
        private System.Windows.Forms.CheckBox withTime;
    }
}