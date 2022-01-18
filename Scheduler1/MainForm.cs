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
            
            mainPage.BringToFront();
        }

        private void GenerateMainPage()
        {
            var header = new Header(@"Study Structurizer", Globals.MenuElement);
            var layoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                VerticalScroll = {Maximum = 0},
                AutoScroll = true
            };
            foreach (var b in GetButtons())
                layoutPanel.Controls.Add(b);
            
            var page = new Page(header, layoutPanel);
            Controls.Add(page);

            page.Header.BackButton.Visible = false;
            page.Header.AddButton.Visible = false;
            
            page.Header.SettingsButton.Click += (sender, e) => 
                OpenPage(settingsPage, mainPage);

            mainPage = page;
        }
        
        private void GenerateSettingsPage()
        {
            var header = new Header(@"Settings", Globals.MenuElement);

            var page = new Page(header, new Control());
            Controls.Add(page);

            page.Header.SettingsButton.Visible = false;
            page.Header.AddButton.Visible = false;
            
            page.Header.BackButton.Click += OpenPreviousPage;

            settingsPage = page;
        }

        private void GenerateSubjectsPages()
        {
            foreach (var subject in GetSubjects())
            {
                var layoutPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    VerticalScroll = {Maximum = 0},
                    AutoScroll = true
                };
                
                for (var i = 0; i < 2; i++)
                    layoutPanel.Controls.Add(new Field("Tasks", 
                            subject.Tasks, layoutPanel).Panel);
        
                var header = new Header(subject.Name, subject.Color);
                var page = new Page(header, layoutPanel, subject);
                Controls.Add(page);
                
                page.Header.BackButton.Click += OpenPreviousPage;
                page.Header.SettingsButton.Click += (sender, e) =>
                    OpenPage(settingsPage, page);
                
                subjectsPages.Add(page);
            }
        }
        
        private void GenerateAddSubjectPage()
        {
            var header = new Header(@"Add Subject", Globals.MenuElement);
            var page = new Page(header, new Control());
            Controls.Add(page);
            
            page.Header.AddButton.Visible = false;
            
            page.Header.BackButton.Click += OpenPreviousPage;
            page.Header.SettingsButton.Click += (sender, e) =>
                OpenPage(settingsPage, addSubjectPage);
            
            addSubjectPage = page;
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
            pagesHistory.Pop().BringToFront();
        }
        
        private void OpenPage(Page pageToOpen, Page previousPage)
        {
            pagesHistory.Push(previousPage);
            pageToOpen.BringToFront();
        }
        
        private static List<Subject> GetSubjects()
        {
            var rnd = new Random();
            var subjects = new List<Subject>();
            for (var i = 0; i < 2; i++)
            {
                var random = rnd.Next(2);
                var colors = new[] {Globals.Button1, Globals.Button2};
                subjects.Add(new Subject($"Алгебра и геометрия {i}",
                    @"Icons\4.png", colors[random], new List<Task>
                    {
                        new Task(DateTime.Now, false, "Task1"),
                        new Task(DateTime.Today, false, "Task2"),
                        new Task(DateTime.Now, false, "Task1"),
                        new Task(DateTime.Today, false, "Task2"),
                        new Task(DateTime.Now, false, "Task1"),
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
                var button = new PatternSubjectButton(subjectPage.Subject.Name,
                    subjectPage.Subject.Color, ClientSize.Width / 2);
                button.Click += (sender, eventsArg) =>
                    OpenPage(subjectPage, mainPage);
                buttons.Add(button);
            }
            
            var addSubjectButton = new PatternSubjectButton("+",
                Globals.MenuElement, ClientSize.Width / 2);
            addSubjectButton.Click += (sender, eventsArg) =>
                OpenPage(addSubjectPage, mainPage);
            buttons.Add(addSubjectButton);

            return buttons;
        }
    }
}