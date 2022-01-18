using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    public class Task : IElement
    {
        public DateTime Date;
        public bool Done;
        public string Text;

        public Task(DateTime date, bool done, string text)
        {
            Date = date;
            Done = done;
            Text = text;
        }

        public Control Build(int size)
        {
            var field = new Panel
            {
                Size = new Size(size, size),
                BackColor = Color.Khaki,
            };
            var fieldElements = new List<Control>
            {
                new Label
                {
                    Text = "ljfnawefonwonfpawoenf pfnwaebf lihbawe ifhbawne iounfawl" +
                           ";f ",
                    Dock = DockStyle.Fill,
                },
                new Label
                {
                    Text = "10.234.524",
                    Dock = DockStyle.Top,
                    Size = new Size(10, field.Size.Height / 4)
                }, 
            };

            foreach (var element in fieldElements)
            {
                element.Click += (sender, args) => ChangeColor(field);
                field.Controls.Add(element);
            }
            
            return field;
        }

        private void ChangeColor(Control field)
        {
            var colors = new[] {Color.GreenYellow, Color.Khaki};
            field.BackColor = field.BackColor == colors[0] ? colors[1] : colors[0];
        }
    }
}