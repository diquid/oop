using System;
using System.Drawing;

namespace Scheduler1
{
    /// <summary>
    /// Будущие документы, лежащие в предмете
    /// </summary>
    public class Document
    {
        public Image Icon;
        public string Path;
        public string Type;
        public string Text;

        public Document(string iconPath, string path, string text)
        {
            Icon = Image.FromFile(Files.GetPathTo(iconPath));
            Path = path;
            Type = path[path.LastIndexOf('.')..];
            Text = text;
        }
    }
}