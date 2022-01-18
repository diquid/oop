using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Scheduler1
{
    public class Field : Control
    {
        public readonly Label Label;
        public readonly FlowLayoutPanel LayoutPanel;
        public readonly Panel Panel;

        public Field(string name, IEnumerable<IElement> elements, Control control)
        {
            Parent = control;
            var builtElements = elements
                .Select(e => e.Build(150))
                .ToList();
            
            var historyBtn = new Button 
            {
                Dock = DockStyle.Right,
                Size = new Size(Globals.MainSize, Globals.MainSize),
                BackColor = Globals.MenuElement,
                BackgroundImage = Image.FromFile(
                    Files.GetPathTo(@"Icons\history.png")),
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = {BorderSize = 0}
            };
            var deleteBtn = new Button 
            {
                Dock = DockStyle.Right,
                Size = new Size(Globals.MainSize, Globals.MainSize),
                BackColor = Globals.MenuElement,
                BackgroundImage = Image.FromFile(
                    Files.GetPathTo(@"Icons\can.png")),
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = {BorderSize = 0}
            };
            deleteBtn.Click += RemoveField;

            Panel = new Panel
            {
                BackColor = Color.Brown,
                Height = 700,
                Dock = DockStyle.Top,
                Margin = new Padding(20),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };
            
            Label = new Label
            {
                Text = name,
                Dock = DockStyle.Top,
                Size = new Size(100, 50),
                BackColor = Globals.MenuElement,
                Font = Globals.HeaderBarFont,
                ForeColor = Globals.FontLight,
                TextAlign = ContentAlignment.MiddleLeft,
            };
            Label.Controls.Add(historyBtn);
            Label.Controls.Add(deleteBtn);
            
            LayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                BackColor = Color.Magenta,
                Padding = new Padding(10),
                Margin = new Padding(20),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = true
            };
            foreach (var e in builtElements) 
                LayoutPanel.Controls.Add(e);

            Panel.Controls.Add(LayoutPanel);
            Panel.Controls.Add(Label);
        }

        private void RemoveField(object sender, EventArgs eventArgs)
        {
            Parent.Controls.Remove(Panel);
        }
    }
}