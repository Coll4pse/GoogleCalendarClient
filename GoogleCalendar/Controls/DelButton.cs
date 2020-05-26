using System.Drawing;
using System.Windows.Forms;

namespace GoogleCalendar.Controls
{
    sealed internal class DelButton : Button
    {
        public ChangeColorButton Item;

        public DelButton(ChangeColorButton item)
        {
            Size = new Size(20, 20);
            Item = item;
            Text = "";
            Image = new Bitmap(@"C:\Users\Mihail\Desktop\С# Projects\GoogleCalendar\GoogleCalendar\Images\laz_cancel.png");
        }
    }
}
