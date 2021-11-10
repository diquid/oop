using System.Drawing;
using System.Net.Mime;
using System.Windows.Forms;
using Label = System.Reflection.Emit.Label;

namespace Scheduler1
{
    public class Header
    {
        public Label Text;
        public Button SettingsButton;
        public Button BackButton;
        public Image Icon;

        public Header(Label text)
        {
            Text = text;
        }
    }
}