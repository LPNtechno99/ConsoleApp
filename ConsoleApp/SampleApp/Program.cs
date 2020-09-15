using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    using Framework;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sample App";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ViewHelper.WriteLine("This message is printed in green", ConsoleColor.Green, true);
            ViewHelper.WriteLine("This color has been reset to default");

            var name = ViewHelper.Read("Enter your name");
            $"Your name is {name}".WriteLine(ConsoleColor.Yellow);
            name = "Now change your name".Update(name);
            $"Your new name is {name}".WriteLine(ConsoleColor.Yellow);

            Console.ReadLine();
        }
        //private static void SomeAction(Parameter p)
        //{
        //    Console.WriteLine($"You've entered the string: {p["param"]}");
        //}
        //private static void About(Parameter p)
        //{
        //    Console.WriteLine("This is the about section");
        //}

        //private static void Help(Parameter p)
        //{
        //    if(p == null)
        //    {
        //        Console.WriteLine("SUPPORTED COMMANDS:");
        //        Console.WriteLine(Router.Instance.GetRoutes());
        //        Console.WriteLine("type: help ? cmd = <command> to get command details");
        //        return;
        //    }
        //    Console.BackgroundColor = ConsoleColor.DarkBlue;
        //    var command = p["cmd"].ToLower();
        //    Console.WriteLine(Router.Instance.GetHelps(command));
        //    Console.ResetColor();
        //}
    }
}
