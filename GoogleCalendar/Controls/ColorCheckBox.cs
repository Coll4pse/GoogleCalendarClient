using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoogleCalendar
{
    class ColorCheckBox : CheckBox
    {
        private bool isEntered;

        public Color BoxColor { get; set; }

        public Scheduler Item { get; private set; }

        public ColorCheckBox(Scheduler item)
            : base()
        {
            Item = item;
            BoxColor = ColorTranslator.FromHtml(item.Calendar.BackgroundColor);
            Text = item.Calendar?.Primary ?? false ? "Основной календарь" : item.Calendar.Summary;
            Checked = true;
        }
        public ColorCheckBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            BoxColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            pevent.Graphics.Clear(BackColor);

            pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 20, 2);

            if (this.Checked)
                pevent.Graphics.FillEllipse(new SolidBrush(BoxColor), 0, 2, 16, 16);
            else
                pevent.Graphics.DrawEllipse(new Pen(new SolidBrush(BoxColor)), 0, 2, 16, 16);

            if (isEntered)
                pevent.Graphics.DrawRectangle(new Pen(Color.FromArgb(130, Color.LightBlue)), 0, 0, Size.Width - 1, Size.Height - 1);
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);

            Item.Selected = Checked;
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);

            isEntered = true;

            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);

            isEntered = false;

            Invalidate();
        }
    }
}
