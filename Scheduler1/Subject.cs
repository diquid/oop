using System.Collections.Generic;
using System.Drawing;

namespace Scheduler1
{
    public class Subject
    
    {
        public string Name;
        public Image Icon;
        public Color Color;
        public List<Task> Tasks;
        public List<Document> Documents;

        public Subject(string name, string icon, Color color, List<Task> tasks, 
            List<Document> documents)
        {
            Name = name;
            Icon = Image.FromFile(Files.GetPathTo(icon));
            Color = color;
            Tasks = tasks;
            Documents = documents;
        }
    }
}