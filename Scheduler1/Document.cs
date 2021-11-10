using System;
using System.Drawing;

namespace Scheduler1
{
    public class Document
    {
        public Image Icon;
        public string Path;
        public string Type;
        public string Text;

        public Document(string icon, string path, string text)
        {
            Icon = Image.FromFile(Files.GetPathTo(icon));
            Path = path;
            Type = path[path.LastIndexOf('.')..];
            Text = text;
        }
    }
}