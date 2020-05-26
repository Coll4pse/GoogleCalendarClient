using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GoogleCalendar
{
    [Serializable]
    public class Scheduler
    {
        public CalendarListEntry Calendar { get; set; }
        public List<Event> Events { get; set; }
        public Color Color { get; private set; }

        public bool Selected { get; set; }

        public Scheduler(CalendarListEntry calendar, params Event[] events)
        {
            Calendar = calendar;
            Color = ColorTranslator.FromHtml(calendar.BackgroundColor);
            Events = new List<Event>(events);
            Selected = true;
        }

        public void ChangeColor(Color newColor)
        {
            Color = newColor;
            Calendar.BackgroundColor = ColorTranslator.ToHtml(newColor).ToLower();
            Calendar.ETag = null;
        }
        public override string ToString()
        {
            return Calendar.Summary;
        }
    }
}
