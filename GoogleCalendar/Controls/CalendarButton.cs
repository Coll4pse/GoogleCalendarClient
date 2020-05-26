using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GoogleCalendar.Controls
{
    public class CalendarButton : Control
    {
        private Animation animation;
        private bool mouseEntered;
        private float shapeShift;
        private Font animFont = new Font("Arial", 9.5f, FontStyle.Bold);
        private Random rnd = new Random();
        private readonly StringFormat stringFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        public HashSet<Color> Colors { get; private set; }

        public bool IsToday { get; set; }

        public CalendarButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(85, 59);
            BackColor = Color.White;
            ForeColor = Color.Black;
            Font = new Font("Arial Black", 20F, FontStyle.Bold);
            Margin = new Padding(1);

            Colors = new HashSet<Color>();

            shapeShift = -84;

            animation = new Animation();
            animation.Value = shapeShift;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var graph = e.Graphics;
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graph.Clear(Color.White);

            if (Colors.Count == 0)
            {
                Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

                graph.DrawRectangle(new Pen(BackColor), rect);
                graph.FillRectangle(new SolidBrush(BackColor), rect);
            }
            else
            {
                var widthShift = (int)Math.Round((double)Width / Colors.Count);
                var width = widthShift;
                var start = 0;
                foreach (var color in Colors)
                {
                    var rect = new Rectangle(start, 0, width - 1, Height - 1);
                    graph.DrawRectangle(new Pen(color), rect);
                    graph.FillRectangle(new SolidBrush(color), rect);
                    start = width;
                    width += widthShift;
                }
            }

            if (IsToday)
            {
                ForeColor = Color.White;
                graph.FillEllipse(new SolidBrush(Color.Black), new Rectangle(16, 3, 50, 50));
            }

            graph.DrawRectangle(new Pen(Color.Black, 0.1f), new Rectangle(0, 0, Width - 1, Height - 1));
            graph.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Width - 1, Height - 1), stringFormat);

            var rectAnim = new Rectangle((int)animation.Value, 0, Width - 1, Height - 1);
            graph.FillRectangle(new SolidBrush(Colors.Count == 0 ? Color.White : Colors.First()), rectAnim);
            graph.DrawString("Посмотреть события", animFont, new SolidBrush(Color.Black), rectAnim, stringFormat);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            mouseEntered = true;

            DoAnimation();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            mouseEntered = false;

            DoAnimation();
        }

        protected void DoAnimation()
        {
            if (mouseEntered)
            {
                animation = new Animation("Curtain_" + Handle, Invalidate, animation.Value, 0);
            }
            else
            {
                animation = new Animation("Curtain_" + Handle, Invalidate, animation.Value, shapeShift);
            }

            Animator.Request(animation, true);
        }
    }
}
