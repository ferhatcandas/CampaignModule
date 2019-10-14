using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public static class Logger
    {
        //it could be an throw an exception, but than app is crashing
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
