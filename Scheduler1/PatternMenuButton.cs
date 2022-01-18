using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    public sealed class PatternMenuButton : Button
    {
        public PatternMenuButton(Color color) 
        {
            Size = new Size(Globals.MainSize, Globals.MainSize);
            BackgroundImageLayout = ImageLayout.Stretch;
            FlatStyle = FlatStyle.Flat;
            BackColor = color;
            FlatAppearance.BorderSize = 0;
        }
    }
}