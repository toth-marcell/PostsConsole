using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsConsole
{
    internal struct MenuOption(string name, Func<Task> execute)
    {
        public string Name { get; set; } = name;
        public Func<Task> Execute { get; set; } = execute;
    }
}
