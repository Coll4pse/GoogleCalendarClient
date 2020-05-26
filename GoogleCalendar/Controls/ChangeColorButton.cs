using System.Drawing;
using System.Windows.Forms;

namespace GoogleCalendar.Controls
{
    sealed internal class ChangeColorButton : Button
    {
        public ColorCheckBox Item;
        public ChangeColorButton(ColorCheckBox item)
        {
            Size = new Size(20, 20);
            Text = "";
            Image = Image.FromFile(@"C:\Users\Mihail\Desktop\С# Projects\GoogleCalendar\GoogleCalendar\Images\color-picker.png");
            Item = item;
            Image = new Bitmap(Image, new Size(12, 12));
        }
    }
}
