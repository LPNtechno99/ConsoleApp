
namespace ContactManager
{
    using Controllers;
    using Framework;
    using System;
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Contact Manager";
            var app = new Application { Config = Config };
            app.Run();
        }
        private static void Config()
        {
            var controller = new ContactController();
            var _router = Router.Instance;

            _router.Register("list", p => controller.List());
            _router.Register("detail", p => controller.Single(p));
            _router.Register("create", p => controller.Create());
            _router.Register("do create", p => controller.Create(p));
            _router.Register("update", p => controller.Update(p["id"].To<int>()));
            _router.Register("do update", p => controller.Update(p));
            _router.Register("delete", p => controller.Delete(p["id"].To<int>()));
            _router.Register("do delete", p => controller.Delete(p));
            _router.Register("save", p => controller.Save());
            _router.Register("load", p => controller.Load());
        }
    }
}
