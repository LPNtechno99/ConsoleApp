using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationSample
{
    using Framework;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sample App";
            Console.OutputEncoding = Encoding.UTF8;

            var app = new Application
            {
                Config = Config
            };
            app.Run();
        }

        private static void Config()
        {
            var router = Router.Instance;
            router.Register("solve",Solve,"Solve a square equation\r\nsolve ? a=<> & b=<> & c=<>");
            router.Register("fact", Fact, "fact ? n=<>");
        }

        private static void Fact(Parameter parameter)
        {
            var n = parameter["n"].To<int>();
            var f = 1;
            for (var i = 1; i <= n; i++)
                f *= i;
            ViewHelper.WriteLine($"{n}! = {f}", ConsoleColor.Cyan);
        }

        private static void Solve(Parameter parameter)
        {
            var a = parameter["a"].To<double>();
            var b = parameter["b"].To<double>();
            var c = parameter["c"].To<double>();

            var d = b * b - 4 * a * c;
            if(d <0)
            {
                ViewHelper.WriteLine("No real solution found", ConsoleColor.Red);
                return;
            }
            ViewHelper.WriteLine("Solution:", ConsoleColor.Cyan);
            var x1 = (-b + Math.Sqrt(d) / (2 * a));
            var x2 = (-b - Math.Sqrt(d) / (2 * a));
            ViewHelper.WriteLine($"X1 = {x1}");
            ViewHelper.WriteLine($"X2 = {x2}");
        }
    }
}
