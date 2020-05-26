using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GoogleCalendar.Controls
{
    class Calendar : UserControl
    {
        private TableLayoutPanel table;

        private static readonly Dictionary<int, string> intToMonth = new Dictionary<int, string>
        {
            {1, "Январь"},
            {2, "Февраль" },
            {3, "Март" },
            {4, "Апрель" },
            {5, "Май" },
            {6, "Июнь" },
            {7, "Июль" },
            {8, "Август" },
            {9, "Сентябрь" },
            {10, "Октябрь" },
            {11, "Ноябрь" },
            {12, "Декабрь" }
        };

        private List<CalendarButton> days;

        public string SelectedYear
        {
            get => selectedYear.ToString();
        }
        public string SelectedMonth
        {
            get => intToMonth[selectedMonth];
        }

        private int selectedYear;
        private int selectedMonth;

        private void InitializeComponent()
        {
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.ColumnCount = 7;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(0);
            this.table.Name = "table";
            this.table.RowCount = 7;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table.Size = new System.Drawing.Size(400, 200);
            this.table.TabIndex = 0;
            // 
            // Calendar
            // 
            this.Controls.Add(this.table);
            this.Name = "Calendar";
            this.Size = new System.Drawing.Size(400, 200);
            this.ResumeLayout(false);

        }

        public Calendar()
        {
            InitializeComponent();

            selectedYear = DateTime.Now.Year;
            selectedMonth = DateTime.Now.Month;

            days = new List<CalendarButton>();

            FillTable();
        }

        public void NextMonth()
        {
            if (selectedMonth == 12)
            {
                selectedMonth = 1;
                selectedYear++;
            }
            else
                selectedMonth++;

            FillTable();
            Invalidate();
        }

        public void PreviousMonth()
        {
            if (selectedMonth == 1)
            {
                selectedMonth = 12;
                selectedYear--;
            }
            else
                selectedMonth--;

            FillTable();
            Invalidate();
        }

        private void DrawEvents()
        {
            if (MainForm.Schedulers == null)
                return;

            foreach (var scheduler in MainForm.Schedulers)
            {
                if (!scheduler.Selected)
                    continue;

                var notOneDayEvents = scheduler.Events
                    .SelectMany(@event => EachDay(@event.Start, @event.End)
                        .Where(date => date.Month == selectedMonth));

                foreach (var day in notOneDayEvents)
                    days[day.Day - 1].Colors.Add(scheduler.Color);           
            }
        }

        public void FillTable()
        {
            table.Controls.Clear();
            this.days.Clear();

            var days = new[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

            foreach (var day in days)
                table.Controls.Add(new Label { Text = day, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill });

            var daysCount = DateTime.DaysInMonth(selectedYear, selectedMonth);

            var firstDay = new DateTime(selectedYear, selectedMonth, 1).DayOfWeek;

            var columnShift = firstDay == DayOfWeek.Sunday ? 6 : (int)firstDay - 1;

            for (var i = 0; i < columnShift; i++)
                table.Controls.Add(new Label()
                {
                    Font = new Font("Comic Sans MS", 14F, FontStyle.Bold)
                });

            for (var i = 0; i < daysCount; i++)
            {
                var day = new CalendarButton()
                {
                    Text = (i + 1).ToString(),
                    IsToday = selectedYear == DateTime.Now.Year && selectedMonth == DateTime.Now.Month && i + 1 == DateTime.Now.Day
                };

                this.days.Add(day);

                day.Click += AddEvent;

                table.Controls.Add(day);
            }

            DrawEvents();
        }

        private void AddEvent(object sender, EventArgs e)
        {
            var parent = ParentForm as MainForm;
            var btn = sender as CalendarButton;
            parent.EditEvent(DateTime.Parse($"{SelectedYear}.{SelectedMonth}.{btn.Text}"));
        }

        private static IEnumerable<DateTime> EachDay(DateTime? from, DateTime? thru)
        {

            for (var day = ((DateTime)from).Date; day.Date <= ((DateTime)thru).Date; day = day.AddDays(1))
                yield return day;
        }

        public static IEnumerable<DateTime> EachDay(EventDateTime from, EventDateTime to)
        {
            var start = from.DateTime ?? DateTime.Parse(from.Date);
            var end = to.DateTime ?? (from.Date == to.Date ? DateTime.Parse(to.Date) : DateTime.Parse(to.Date).AddDays(-1));
            return EachDay(start, end);
        }
    }
}
