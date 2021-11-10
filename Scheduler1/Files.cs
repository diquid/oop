using System;
using System.IO;
using System.Linq;

namespace Scheduler1
{
    public class Files
    {
        public static string GetPathTo(string path) =>
            Path.Combine(Environment.CurrentDirectory
                .Split("bin")
                .First(), path);
    }
}