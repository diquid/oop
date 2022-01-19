using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Scheduler1
{
    public sealed class Field : Control
    {
        public readonly Header Header;
        public readonly FlowLayoutPanel LayoutPanel;

        public Field(string name, IEnumerable<IElement> elements, Control control)
        {
            Parent = control;
            var builtElements = elements
                .Select(e => e.Build(150))
                .ToList();

            BackColor = Color.Brown;
            Dock = DockStyle.Top;
            Height = 200;
            Margin = new Padding(20);
            AutoSize = true;

            var header = new Header(name, Globals.MenuElement, 
                new List<ElementsTypes>
                {
                    ElementsTypes.HistoryBtn,
                    ElementsTypes.DeleteBtn
                });
            
            header.Elements[ElementsTypes.DeleteBtn].Click += RemoveField;
            
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

            Controls.Add(LayoutPanel);
            Controls.Add(header);

            Header = header;
        }

        private void RemoveField(object sender, EventArgs eventArgs)
        {
            Parent.Controls.Remove(this);
        }
    }
}