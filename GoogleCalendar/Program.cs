using System;
using System.Windows.Forms;

namespace GoogleCalendar
{

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthorizeForm());
            Application.Run(new MainForm());
        }
    }
}
