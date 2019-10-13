using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface ICommand
    {
        void Execute(string command, string[] arguments);
        TimeSpan GetTime();
    }
}
