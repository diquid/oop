using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ContentAlignment = System.Drawing.ContentAlignment;

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
            var headerButton = new Button
            {
                Size = new Size(Globals.MainSize, Globals.MainSize),
                Location = new Point(0, 0),
                BackgroundImage = Image.FromFile(@"C:\Users\aesok\OneDrive\Рабочий стол\oop\Scheduler1\Icons\1.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
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
                BackgroundImage =
                    Image.FromFile(
                        @"C:\Users\aesok\OneDrive\Рабочий стол\oop\Scheduler1\Icons\1.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
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
                Size = new Size(ClientSize.Width, Globals.MainSize),
                Font = Globals.HeaderBarFont,
                ForeColor = Globals.FontLight,
                Text = "Study Structurizer",
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(Globals.MainSize, 0, 0, 0)
            };
            
            var buttons = GetButtons();
            var flowLayoutPanel1 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            foreach (var b in buttons)
            {
                flowLayoutPanel1.Controls.Add(b);
            }
            
            Controls.Add(flowLayoutPanel1);
            Controls.Add(headerButton);
            Controls.Add(headerSettings);
            Controls.Add(headerText);
        }

        private List<Button> GetButtons()
        {
            var buttons = new List<Button>();
            for (var i = 0; i < 10; i++)
            {
                var button = new Button
                {
                    Size = new Size(ClientSize.Width / 16 * 10,
                        Globals.MainSize * 2),
                    FlatStyle = FlatStyle.Flat,
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
                    BackColor = Globals.MenuElement,
                    Margin = new Padding(0, Globals.MainSize, 0, Globals.MainSize),
                    FlatAppearance =
                    {
                        BorderSize = 0
                    }
                };
                buttons.Add(button);
            }

            return buttons;
        }

        private void InitializeForm()
        {
            ClientSize = new Size(Globals.FormWidth, Globals.FormHeight);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = "MainForm";
            BackColor = Globals.FormBackground;
        }
    }
}