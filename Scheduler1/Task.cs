using System;
using System.Collections.Generic;

namespace Scheduler1
{
    public class Task
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
    }
}