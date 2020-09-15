using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Views
{
    using Framework;
    using Models;

    internal class ListView : ViewBase<Contact[]>
    {
        public ListView(Contact[] model):base(model)
        {

        }
        public override void Render()
        {
            if(Model.Length == 0)
            {
                ViewHelper.WriteLine("Sorry, no contact found", ConsoleColor.Magenta);
                return;
            }

            ViewHelper.WriteLine($"{Model.Length} contact(s) found", ConsoleColor.Green);
            foreach(var c in Model)
            {
                ViewHelper.WriteLine($"[{c.Id}] { c.Name}| {c.FirstName} {c.LastName}");
            }
            ViewHelper.WriteLine($"{Model.Length} contact(s) found", ConsoleColor.Green);
        }
    }
}
