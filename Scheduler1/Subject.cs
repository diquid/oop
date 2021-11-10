using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    public class Subject
    
    {
        public string Name;
        public Panel Panel;
        public Image Icon;
        public Color Color;
        public List<Task> Tasks;
        public List<Document> Documents;

        public Subject(string name, Panel panel, string iconPath, Color color, List<Task> tasks, 
            List<Document> documents)
        {
            Name = name;
            Panel = panel;
            Icon = Image.FromFile(Files.GetPathTo(iconPath));
            Color = color;
            Tasks = tasks;
            Documents = documents;
        }
    }
}