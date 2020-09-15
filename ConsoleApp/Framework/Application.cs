using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Application
    {
        public Action Config { get; set; } // khai báo delegate Action tên Config
        public ControllerAction Help { get; set; } = DefaultHelp;
        public string Prompt { get; set; } = "# Request > ";
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;

        /// <summary>
        /// -Tạo hàm config để đăng ký các Router
        /// -Chạy vòng lặp giúp người dùng nhập dữ liệu
        /// </summary>
        public void Run()
        {
            Config(); // Hàm Config sẽ được định nghĩa tại nơi sử dụng thư viện, đây là hàm void mà delegate action sẽ gọi
            Router.Instance.Register("help", Help);
            while (true)
            {
                ViewHelper.Write(Prompt, Color);
                var request = Console.ReadLine();
                try
                {
                    Router.Instance.Forward(request);
                }
                catch(Exception e)
                {
                    ViewHelper.WriteLine($"ERROR: {e.Message}", ConsoleColor.Red);
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }

        private static void DefaultHelp(Parameter parameter)
        {
            if(parameter==null)
            {
                ViewHelper.WriteLine("SUPPORTED COMMANDS:", ConsoleColor.Magenta);
                ViewHelper.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Yellow);
                Console.WriteLine("type: help ? cmd=<command> to get command details");
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            var command = parameter["cmd"].ToLower();
            Console.WriteLine(Router.Instance.GetHelps(command));
            Console.ResetColor();
        }
    }
}
