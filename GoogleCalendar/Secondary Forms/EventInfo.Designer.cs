namespace GoogleCalendar.Secondary_Forms
{
    partial class EventInfo
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
            this.infoLabel = new System.Windows.Forms.Label();
            this.deleteEvtBtn = new GoogleCalendar.FlatButton();
            this.exitBtn = new GoogleCalendar.FlatButton();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.Location = new System.Drawing.Point(34, 36);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(397, 50);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "LABEL";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deleteEvtBtn
            // 
            this.deleteEvtBtn.BackColor = System.Drawing.Color.Tomato;
            this.deleteEvtBtn.ForeColor = System.Drawing.Color.White;
            this.deleteEvtBtn.Item = null;
            this.deleteEvtBtn.Location = new System.Drawing.Point(178, 113);
            this.deleteEvtBtn.Name = "deleteEvtBtn";
            this.deleteEvtBtn.Size = new System.Drawing.Size(100, 30);
            this.deleteEvtBtn.TabIndex = 1;
            this.deleteEvtBtn.Text = "Удалить событие";
            this.deleteEvtBtn.Click += new System.EventHandler(this.deleteEvtBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Item = null;
            this.exitBtn.Location = new System.Drawing.Point(445, 0);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(0);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(24, 24);
            this.exitBtn.TabIndex = 10;
            this.exitBtn.Text = "X";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // EventInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 177);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.deleteEvtBtn);
            this.Controls.Add(this.infoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EventInfo";
            this.Text = "EventInfo";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EventInfo_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label infoLabel;
        private FlatButton deleteEvtBtn;
        private FlatButton exitBtn;
    }
}