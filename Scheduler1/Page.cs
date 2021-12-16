using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    /// <summary>
    /// Это типа класс вкладки (главное меню / настройки / предмет)
    /// </summary>
    public class Page : Control
    {
        public Header Header;
        public Control Filling;
        public Subject Subject;
        public readonly Panel Panel;

        public Page(Header header, Control filling = null, Subject subject = null)
        {
            Header = header;
            Filling = filling;
            Subject = subject;
            Panel = new Panel {Dock = DockStyle.Fill};
            if (filling != null) 
                Panel.Controls.Add(Filling);
            Panel.Controls.Add(Header.Label);
        }
    }

    public static class PageExtensions
    {
        public static void GeneratePage(this Panel panel,
            Control.ControlCollection controls)
        {
            controls.Add(panel);
        }
    }
}