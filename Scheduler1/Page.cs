using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    public sealed class Page : Control
    {
        public readonly Header Header;
        public readonly Control Filling;
        public readonly Subject Subject;

        public Page(Header header, Control filling, Subject subject = null)
        {
            Header = header;
            Filling = filling;
            Subject = subject;
            Dock = DockStyle.Fill;
            Controls.Add(Filling);
            Controls.Add(Header);
        }
    }
}