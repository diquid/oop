using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    public sealed class Header : Control
    {
        public readonly Button BackButton;
        public readonly Button SettingsButton;
        public readonly Button AddButton;
        public readonly Label Label;

        public Header(string text, Color color)
        {
            Height = 50;
            Dock = DockStyle.Top;
            BackColor = color;
            SettingsButton = new PatternMenuButton(color)
            {
                Dock = DockStyle.Right,
                BackgroundImage = Image.FromFile(
                    Files.GetPathTo(@"Icons\1.png"))
            };
            BackButton = new PatternMenuButton(color)
            {
                Dock = DockStyle.Left,
                BackgroundImage = Image.FromFile(
                    Files.GetPathTo(@"Icons\6.png"))
            };
            Label = new Label
            {
                Text = text,
                Dock = DockStyle.Left,
                AutoSize = true,
                Font = Globals.HeaderBarFont,
                ForeColor = Globals.FontLight
            };
            AddButton = new PatternMenuButton(color)
            {
                Dock = DockStyle.Right,
                BackgroundImage = Image.FromFile(
                    Files.GetPathTo(@"Icons\add.png"))
            };
            Controls.Add(Label);
            Controls.Add(BackButton);
            Controls.Add(AddButton);
            Controls.Add(SettingsButton);
        }
    }
}