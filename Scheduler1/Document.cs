using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduler1
{
    /// <summary>
    /// Будущие документы, лежащие в предмете
    /// </summary>
    public class Document : IElement
    {
        public Image Icon;
        public string Path;
        public string Type;
        public string Name;

        public Document(string iconPath, string path, string name)
        {
            Icon = Image.FromFile(Files.GetPathTo(iconPath));
            Path = path;
            Type = path[path.LastIndexOf('.')..];
            Name = name;
        }

        public Control Build(Size size)
        {
            return new Panel();
        }

        public Control Build(int size)
        {
            throw new NotImplementedException();
        }
    }
}