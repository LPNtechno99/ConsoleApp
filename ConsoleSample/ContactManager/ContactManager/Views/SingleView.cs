using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Views
{
    using Framework;
    using Models;
    internal class SingleView : ViewBase<Contact>
    {
        public SingleView(Contact model) : base(model)
        {

        }
        public override void Render()
        {
            if(Model == null)
            {
                ViewHelper.WriteLine("Sorry, contact not found", ConsoleColor.Magenta);
                return;
            }
            Model.Name.WriteLine(ConsoleColor.Magenta);
            $"ID:                        {Model.Id}".WriteLine(ConsoleColor.Yellow);
            $"First name:                {Model.FirstName}".WriteLine(ConsoleColor.Yellow);
            $"Last name:                 {Model.LastName}".WriteLine(ConsoleColor.Yellow);
            $"Phone:                     {Model.Phone}".WriteLine(ConsoleColor.Yellow);
            $"Email:                     {Model.Email}".WriteLine(ConsoleColor.Yellow);
            $"Facebook:                  {Model.Facebook}".WriteLine(ConsoleColor.Yellow);
            $"Twitter:                   {Model.Twitter}".WriteLine(ConsoleColor.Yellow);
        }
    }
}
