namespace GoogleCalendar
{
    partial class EditEventsForm
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
            this.eventsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AddEventBtn = new GoogleCalendar.FlatButton();
            this.exitBtn = new GoogleCalendar.FlatButton();
            this.SuspendLayout();
            // 
            // eventsPanel
            // 
            this.eventsPanel.AutoScroll = true;
            this.eventsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.eventsPanel.Location = new System.Drawing.Point(32, 25);
            this.eventsPanel.Name = "eventsPanel";
            this.eventsPanel.Size = new System.Drawing.Size(319, 295);
            this.eventsPanel.TabIndex = 0;
            // 
            // AddEventBtn
            // 
            this.AddEventBtn.BackColor = System.Drawing.Color.Tomato;
            this.AddEventBtn.ForeColor = System.Drawing.Color.White;
            this.AddEventBtn.Item = null;
            this.AddEventBtn.Location = new System.Drawing.Point(140, 326);
            this.AddEventBtn.Name = "AddEventBtn";
            this.AddEventBtn.Size = new System.Drawing.Size(100, 30);
            this.AddEventBtn.TabIndex = 1;
            this.AddEventBtn.Text = "Добавить событие";
            this.AddEventBtn.Click += new System.EventHandler(this.AddEventBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Item = null;
            this.exitBtn.Location = new System.Drawing.Point(361, 0);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(0);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(24, 24);
            this.exitBtn.TabIndex = 10;
            this.exitBtn.Text = "X";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // EditEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 383);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.AddEventBtn);
            this.Controls.Add(this.eventsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditEventsForm";
            this.Text = "EditEventsForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditEventsForm_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel eventsPanel;
        private FlatButton AddEventBtn;
        private FlatButton exitBtn;
    }
}