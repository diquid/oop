using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Scheduler1
{
    public class MainForm : Form
    {
        private readonly Stack<Page> pagesHistory = new Stack<Page>();
        private Page mainPage;
        private Page settingsPage;
        private Page addSubjectPage;
        private readonly List<Page> subjectsPages = new List<Page>();

        public MainForm()
        {
            InitializeForm();

            GenerateSubjectsPages();

            GenerateAddSubjectPage();

            GenerateMainPage();

            GenerateSettingsPage();

            mainPage.Panel.BringToFront();
        }

        private void GenerateSubjectsPages()
        {
            foreach (var subject in GetSubjects())
            {
                var tableLayoutPanel = new TableLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    VerticalScroll = {Maximum = 0},
                    AutoScroll = true
                };
                for (var i = 0; i < 5; i++)
                    tableLayoutPanel.Controls.Add(
                        new Field("Tasks", subject.Tasks).Panel);

                var subjectPage = new Page(new Header(subject.Color),
                    tableLayoutPanel, subject);
                subjectPage.Panel.GeneratePage(Controls);
                subjectPage.Header.Label.Text = subject.Name;
                subjectPage.Header.SettingsButton.Click += (sender, e) =>
                    OpenPage(settingsPage, subjectPage);
                subjectPage.Header.BackButton.Click += OpenPreviousPage;
                subjectsPages.Add(subjectPage);
            }
        }

        private void GenerateAddSubjectPage()
        {
            addSubjectPage = new Page(new Header(Globals.MenuElement));
            addSubjectPage.Panel.GeneratePage(Controls);
            addSubjectPage.Header.Label.Text = @"Add Subject";
            addSubjectPage.Header.BackButton.Click += OpenPreviousPage;
            addSubjectPage.Header.SettingsButton.Click += (sender, e) =>
                OpenPage(settingsPage, addSubjectPage);
        }

        private void GenerateSettingsPage()
        {
            settingsPage = new Page(new Header(Globals.MenuElement));
            settingsPage.Panel.GeneratePage(Controls);
            settingsPage.Header.Label.Text = @"Settings";
            settingsPage.Header.SettingsButton.Visible = false;
            settingsPage.Header.BackButton.Click += OpenPreviousPage;
        }

        private void GenerateMainPage()
        {
            var tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                VerticalScroll = {Maximum = 0},
                AutoScroll = true
            };
            foreach (var b in GetButtons())
                tableLayoutPanel.Controls.Add(b);
            
            mainPage = new Page(new Header(Globals.MenuElement), 
                tableLayoutPanel);
            mainPage.Panel.GeneratePage(Controls);
            mainPage.Header.Label.Text = @"Study Structurizer";
            mainPage.Header.BackButton.Visible = false;
            mainPage.Header.SettingsButton.Click += (sender, e) =>
                OpenPage(settingsPage, mainPage);
        }

        private void InitializeForm()
        {
            ClientSize = new Size(900, 600);
            //FormBorderStyle = FormBorderStyle.FixedSingle;
            Text = @"Study Structurizer";
            BackColor = Globals.FormBackground;
        }

        private void OpenPreviousPage(object sender, EventArgs eventArgs)
        {
            pagesHistory.Pop().Panel.BringToFront();
        }

        public void OpenPage(Page pageToOpen, Page previousPage)
        {
            pagesHistory.Push(previousPage);
            pageToOpen.Panel.BringToFront();
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
                    @"Icons\4.png", colors[random], new List<Task>
                    {
                        new Task(DateTime.Now, false, "Task1"),
                        new Task(DateTime.Today, false, "Task2"),
                        new Task(DateTime.Now, false, "Task1"),
                        new Task(DateTime.Today, false, "Task2"),
                        new Task(DateTime.Now, false, "Task1"),
                        new Task(DateTime.Today, false, "Task2"),
                    }, new List<Document>
                    {
                        new Document(@"Icons\3.png", "DocumentTestFile.txt", "Doc1"),
                        new Document(@"Icons\1.png", "DocumentTestFile.txt", "Doc2")
                    }));
            }

            return subjects;
        }

        private List<Button> GetButtons()
        {
            var buttons = new List<Button>();
            foreach (var subjectPage in subjectsPages)
            {
                var button = new Button
                {
                    Size = new Size(ClientSize.Width / 16 * 10,
                        Globals.MainSize * 2),
                    FlatStyle = FlatStyle.Flat,
                    Text = subjectPage.Subject.Name,
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
                    BackColor = subjectPage.Subject.Color,
                    Font = Globals.ButtonFont,
                    ForeColor = Globals.FontLight,
                    Margin = new Padding(0, 15, 0, 15),
                    FlatAppearance = {BorderSize = 0}
                };
                button.Click += (sender, eventsArg) =>
                    OpenPage(subjectPage, mainPage);
                buttons.Add(button);
            }
            
            var addSubjectButton = new Button
            {
                FlatStyle = FlatStyle.Flat,
                Text = "+",
                Size = new Size(ClientSize.Width / 16 * 10,
                    Globals.MainSize * 2),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
                BackColor = Globals.MenuElement,
                Font = Globals.ButtonFont,
                ForeColor = Globals.FontLight,
                Margin = new Padding(0, 15, 0, 15),
                FlatAppearance = {BorderSize = 0}
            };
            addSubjectButton.Click += (sender, eventsArg) =>
                OpenPage(addSubjectPage, mainPage);
            buttons.Add(addSubjectButton);

            return buttons;
        }
    }
}