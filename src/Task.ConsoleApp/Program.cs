using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLAP;
using Task.Models;

namespace Task.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            Parser.Run(args, app);
            Console.Read();
        }
    }
}
