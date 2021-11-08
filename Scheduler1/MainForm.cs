using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    public class MainForm : Form
    {
        public MainForm()
        {
            InitializeForm();
            ArrangeElements();
        }

        private void ArrangeElements()
        {
            PlaceHeaderBar("Study Structurizer");
        }

        private void PlaceHeaderBar(string text)
        {
            const int size = 50;
            var headerButton = new Button
            {
                Size = new Size(size, size),
                Location = new Point(0, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = Palette.MenuElement,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };
            var headerSettings = new Button
            {
                Size = new Size(size, size),
                Location = new Point(ClientSize.Width - size, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = Palette.MenuElement,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };
            var headerText = new Label
            {
                Dock = DockStyle.Top,
                BackColor = Palette.MenuElement,
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, size),
                Font = Fonts.HeaderBarFont,
                ForeColor = Palette.FontLight,
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(50, 0, 0, 0)
            };
            Controls.Add(headerButton);
            Controls.Add(headerSettings);
            Controls.Add(headerText);
        }

        private void InitializeForm()
        {
            ClientSize = new Size(1000, 600);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = "MainForm";
            BackColor = Palette.FormBackground;
        }
    }
}