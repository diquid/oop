using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Scheduler1
{
    public class MainForm : Form
    {
        private Panel mainPanel;
        private Panel settingsPanel;
        private readonly Stack<Panel> panelsStack = new Stack<Panel>();

        public MainForm()
        {
            InitializeForm();
            var subjects = GetSubjects();
            CreateMainPanel(subjects);
            CreateSubjectsPanels(subjects);
            CreateSettingsPanel();
        }

        private void InitializeForm()
        {
            ClientSize = new Size(900, 600);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = @"Study Structurizer";
            BackColor = Globals.FormBackground;
        }

        private void CreateMainPanel(List<Subject> subjects)
        {
            var headerSettings = new Button
            {
                Size = new Size(Globals.MainSize, Globals.MainSize),
                Location = new Point(ClientSize.Width - Globals.MainSize, 0),
                FlatStyle = FlatStyle.Flat,
                BackgroundImage = Image.FromFile(Files.GetPathTo(@"Icons\1.png")),
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
                Text = @"Study Structurizer",
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(Globals.MainSize, 0, 0, 0)
            };
            var tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                VerticalScroll = {Maximum = 0},
                AutoScroll = true,
            };
            var panel = new Panel {Dock = DockStyle.Fill};

            var buttons = GetButtons(subjects);
            foreach (var b in buttons)
                tableLayoutPanel.Controls.Add(b);

            panel.Controls.Add(tableLayoutPanel);
            panel.Controls.Add(headerSettings);
            panel.Controls.Add(headerText);
            Controls.Add(panel);

            mainPanel = panel;

            headerSettings.Click += (sender, eventArgs) =>
                OpenPanelClicked(settingsPanel,
                    panel);
        }

        private void CreateSubjectsPanels(List<Subject> subjects)
        {
            foreach (var subject in subjects)
            {
                var headerSettings = new Button
                {
                    Size = new Size(Globals.MainSize, Globals.MainSize),
                    Location = new Point(ClientSize.Width - Globals.MainSize, 0),
                    FlatStyle = FlatStyle.Flat,
                    BackgroundImage = Image.FromFile(Files.GetPathTo(@"Icons\1.png")),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BackColor = subject.Color,
                    FlatAppearance =
                    {
                        BorderSize = 0
                    }
                };
                var headerBack = new Button
                {
                    Size = new Size(Globals.MainSize, Globals.MainSize),
                    Location = new Point(0, 0),
                    BackgroundImage = Image.FromFile(Files.GetPathTo(@"Icons\6.png")),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = subject.Color,
                    FlatAppearance =
                    {
                        BorderSize = 0
                    }
                };
                var headerText = new Label
                {
                    Dock = DockStyle.Top,
                    BackColor = subject.Color,
                    Size = new Size(ClientSize.Width, Globals.MainSize),
                    Font = Globals.HeaderBarFont,
                    ForeColor = Globals.FontLight,
                    Text = subject.Name,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(Globals.MainSize, 0, 0, 0)
                };
                var flowLayoutPanel1 = new TableLayoutPanel 
                    {Dock = DockStyle.Fill,AutoScroll = true};
                var panel = new Panel {Dock = DockStyle.Fill};

                panel.Controls.Add(flowLayoutPanel1);
                panel.Controls.Add(headerSettings);
                panel.Controls.Add(headerBack);
                panel.Controls.Add(headerText);
                Controls.Add(panel);

                subject.Panel = panel;

                headerBack.Click += OpenPreviousPanelClicked;
                headerSettings.Click += (sender, eventArgs) =>
                    OpenPanelClicked(settingsPanel,
                        panel);
            }
        }

        private void CreateSettingsPanel()
        {
            var headerBack = new Button
            {
                Size = new Size(Globals.MainSize, Globals.MainSize),
                Location = new Point(0, 0),
                BackgroundImage = Image.FromFile(Files.GetPathTo(@"Icons\6.png")),
                BackgroundImageLayout = ImageLayout.Stretch,
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
                Size = new Size(ClientSize.Width, Globals.MainSize),
                Font = Globals.HeaderBarFont,
                ForeColor = Globals.FontLight,
                Text = @"Settings",
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(Globals.MainSize, 0, 0, 0)
            };
            var flowLayoutPanel1 = new TableLayoutPanel 
                {Dock = DockStyle.Fill, AutoScroll = true};
            var panel = new Panel {Dock = DockStyle.Fill};

            panel.Controls.Add(flowLayoutPanel1);
            panel.Controls.Add(headerBack);
            panel.Controls.Add(headerText);
            Controls.Add(panel);

            settingsPanel = panel;
            headerBack.Click += OpenPreviousPanelClicked;
        }

        private void OpenPreviousPanelClicked(object sender, EventArgs e) =>
            panelsStack.Pop().BringToFront();

        private void OpenPanelClicked(Panel panelToOpen, Panel previousPanel)
        {
            panelToOpen.BringToFront();
            panelsStack.Push(previousPanel);
        }

        private static List<Subject> GetSubjects()
        {
            var rnd = new Random();
            var subjects = new List<Subject>();
            for (var i = 0; i < 10; i++)
            {
                var random = rnd.Next(2);
                var colors = new[] {Globals.Button1, Globals.Button2};
                subjects.Add(new Subject("Алгебра и геометрия",
                    new Panel(), @"Icons\4.png",
                    colors[random], new List<Task>
                    {
                        new Task(DateTime.Now, false, "Task1"),
                        new Task(DateTime.Today, false, "Task2")
                    }, new List<Document>
                    {
                        new Document(@"Icons\3.png", "DocumentTestFile.txt", "Doc1"),
                        new Document(@"Icons\1.png", "DocumentTestFile.txt", "Doc2")
                    }));
            }

            return subjects;
        }

        private List<Button> GetButtons(List<Subject> subjects)
        {
            var buttons = new List<Button>();
            foreach (var subject in subjects)
            {
                var button = new Button
                {
                    Size = new Size(ClientSize.Width / 16 * 10, Globals.MainSize * 2),
                    FlatStyle = FlatStyle.Flat,
                    Text = subject.Name,
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
                    BackColor = subject.Color,
                    Font = Globals.ButtonFont,
                    ForeColor = Globals.FontLight,
                    Margin = new Padding(0, 15, 0, 15),
                    FlatAppearance = {BorderSize = 0}
                };
                button.Click += (sender, eventArgs) =>
                    OpenPanelClicked(subject.Panel, mainPanel);
                buttons.Add(button);
            }

            return buttons;
        }
    }
}