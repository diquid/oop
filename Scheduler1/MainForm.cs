using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
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
            PlaceButtons();
            PlaceAntiHeaderBar();
        }

        private void PlaceAntiHeaderBar()
        {
            var antiHeader = new Label
            {
                Dock = DockStyle.Bottom,
                BackColor = Globals.FormBackground,
                Location = new Point(0, ClientSize.Height - Globals.MainSize),
                Size = new Size(ClientSize.Width, Globals.MainSize)
            };
            Controls.Add(antiHeader);
        }

        private void PlaceButtons()
        {
            for (var i = 0; i < 5; i++)
            {
                var button = new Button
                {
                    Size = new Size(ClientSize.Width / 16 * 10,
                        Globals.MainSize * 2),
                    Location = new Point(ClientSize.Width / 16 * 3,
                        Globals.MainSize * 2 + i * Globals.MainSize * 3),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Globals.MenuElement,
                    FlatAppearance =
                    {
                        BorderSize = 0
                    }
                };
                Controls.Add(button);
            }
        }

        private void PlaceHeaderBar(string text)
        {
            var headerButton = new Button
            {
                Size = new Size(Globals.MainSize, Globals.MainSize),
                Location = new Point(0, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = Globals.MenuElement,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };
            var headerSettings = new Button
            {
                Size = new Size(Globals.MainSize, Globals.MainSize),
                Location = new Point(ClientSize.Width - Globals.MainSize, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = Globals.MenuElement,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };
            var headerText = new Label
            {
                Dock = DockStyle.Top,
                BackColor = Globals.MenuElement,
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, Globals.MainSize),
                Font = Globals.HeaderBarFont,
                ForeColor = Globals.FontLight,
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(50, 0, 0, 0),
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
            BackColor = Globals.FormBackground;
            
            AutoScroll = true;
        }
    }
}