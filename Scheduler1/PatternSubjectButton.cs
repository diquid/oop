using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    public sealed class PatternSubjectButton : Button
    {
        public PatternSubjectButton(string text, Color color, int width)
        {
            Text = text;
            Size = new Size(width, Globals.MainSize * 2);
            FlatStyle = FlatStyle.Flat;
            BackColor = color;
            Anchor = AnchorStyles.Top;
            Font = Globals.ButtonFont;
            ForeColor = Globals.FontLight;
            Margin = new Padding(0, 15, 0, 15);
            FlatAppearance.BorderSize = 0;
        }
    }
}