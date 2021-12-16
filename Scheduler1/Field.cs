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

        public Field(string name, IEnumerable<IElement> elements)
        {
            var builtElements = elements
                .Select(e => e.Build(150))
                .ToList();
            Panel = new Panel
            {
                BackColor = Color.Brown,
                Dock = DockStyle.Top,
                Margin = new Padding(20, 20, 20, 20),
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
    }
}