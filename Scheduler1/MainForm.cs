using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Scheduler1
{
    public class MainForm : Form
    {
        private Panel mainPanel;

        public MainForm()
        {
            InitializeForm();
            CreateMainPanel();
            CreateSettingsPanel();
        }

        private void CreateSettingsPanel()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var headerButton = new Button
            {
                Size = new Size(Globals.MainSize, Globals.MainSize),
                Location = new Point(0, 0),
                BackgroundImage = Image.FromFile(GetPathTo(@"Icons\6.png")),
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatStyle = FlatStyle.Flat,
                BackColor = Globals.MenuElement,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };
            headerButton.Click += BackToMainPanel;
            var headerText = new Label
            {
                Dock = DockStyle.Top,
                BackColor = Globals.MenuElement,
                Size = new Size(ClientSize.Width, Globals.MainSize),
                Font = Globals.HeaderBarFont,
                ForeColor = Globals.FontLight,
                Text = @"Settings",
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(Globals.MainSize, 0, 0, 0)
            };
            var flowLayoutPanel1 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            var panel = new Panel
            {
                Dock = DockStyle.Fill
            };

            panel.Controls.Add(flowLayoutPanel1);
            panel.Controls.Add(headerButton);
            panel.Controls.Add(headerText);
            Controls.Add(panel);
        }

        private void BackToMainPanel(object sender, EventArgs e)
        {
            mainPanel.Show();
        }

        private void CreateMainPanel()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var headerSettings = new Button
            {
                Size = new Size(Globals.MainSize, Globals.MainSize),
                Location = new Point(ClientSize.Width - Globals.MainSize, 0),
                FlatStyle = FlatStyle.Flat,
                BackgroundImage = Image.FromFile(GetPathTo(@"Icons\1.png")),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Globals.MenuElement,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };
            headerSettings.Click += HeaderSettingsClicked;
            var headerText = new Label
            {
                Dock = DockStyle.Top,
                BackColor = Globals.MenuElement,
                Size = new Size(ClientSize.Width, Globals.MainSize),
                Font = Globals.HeaderBarFont,
                ForeColor = Globals.FontLight,
                Text = @"Study Structurizer",
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(Globals.MainSize, 0, 0, 0)
            };
            var flowLayoutPanel1 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            var panel = new Panel
            {
                Dock = DockStyle.Fill
            };

            var buttons = GetButtons();
            foreach (var b in buttons)
                flowLayoutPanel1.Controls.Add(b);

            panel.Controls.Add(flowLayoutPanel1);
            panel.Controls.Add(headerSettings);
            panel.Controls.Add(headerText);
            Controls.Add(panel);

            mainPanel = panel;
        }

        private void HeaderSettingsClicked(object sender, EventArgs e)
        {
            mainPanel.Hide();
        }

        private static string GetPathTo(string path) =>
            Path.Combine(Environment.CurrentDirectory
                .Split("bin")
                .First(), path);

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
                    Margin = new Padding(0, 15, 0, 15),
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
            ClientSize = new Size(900, 600);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = @"Study Structurizer";
            BackColor = Globals.FormBackground;
        }
    }
}