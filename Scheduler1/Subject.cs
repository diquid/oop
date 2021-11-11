using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    public sealed class Subject
    {
        public string Name;
        public Image Icon;
        public Color Color;
        public List<Task> Tasks;
        public List<Document> Documents;
        public Button ButtonToThisSubject;

        public Subject(string name, string iconPath, Color color, List<Task> tasks,
            List<Document> documents)
        {
            Name = name;
            Icon = Image.FromFile(Files.GetPathTo(iconPath));
            Color = color;
            Tasks = tasks;
            Documents = documents;
        }
    }
}