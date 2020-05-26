using Google.Apis.Calendar.v3.Data;
using System;
using System.Drawing;
using System.Linq;

namespace GoogleCalendar
{
    public static class CalendarRequests
    {
        public static CalendarListEntry CreateCalendar(string name, string description)
        {
            var rnd = new Random();
            var color = ColorTranslator.ToHtml(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));

            if (MainForm.IsOnlineMode)
            {
                var newCalendar = new Calendar
                {
                    Summary = name,
                    Description = description
                };

                MainForm.Service.Calendars.Insert(newCalendar).Execute();

                var calendars = MainForm.Service.CalendarList.List().Execute().Items;

                var syncCalendar = calendars.First(clnd => clnd.Summary == newCalendar.Summary && clnd.Description == newCalendar.Description);

                syncCalendar.BackgroundColor = color.ToLower();

                var colorUpdRequest = MainForm.Service.CalendarList.Patch(syncCalendar, syncCalendar.Id);
                colorUpdRequest.ColorRgbFormat = true;
                colorUpdRequest.ExecuteAsync();

                return syncCalendar;
            }
            else
                return new CalendarListEntry
                {
                    Summary = name,
                    Description = description,
                    BackgroundColor = color,
                    AccessRole = "owner",
                    ForegroundColor = "#000000"
                };
        }

        public static void RemoveCalendar(Scheduler scheduler)
        {
            MainForm.Service.CalendarList.Delete(scheduler.Calendar.Id).ExecuteAsync();
        }

        public static Event CreateEvent(string name, string description, DateTime start, DateTime end, bool withTime)
        {

            var newEvent = new Event()
            {
                Summary = name,
                Description = description,
                Start = new EventDateTime(),
                End = new EventDateTime(),
                Updated = DateTime.Now,
                Created = DateTime.Now
            };

            if (withTime)
            {
                newEvent.Start.DateTime = start;
                newEvent.End.DateTime = end;
            }
            else
            {
                newEvent.Start.Date = start.ToString("yyyy-MM-dd");
                newEvent.End.Date = end.ToString("yyyy-MM-dd");
            }

            return newEvent;
        }
    }
}
