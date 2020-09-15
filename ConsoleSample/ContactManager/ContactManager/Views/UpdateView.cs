using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Views
{
    using Framework;
    using Models;
    internal class UpdateView : ViewBase<Contact>
    {
        public UpdateView(Contact model) : base(model)
        {

        }
        public override void Render()
        {
            if(Model == null)
            {
                ViewHelper.WriteLine("Sorry, no contact found", ConsoleColor.Magenta);
                return;
            }

            var id = "ID".Update(Model.Id);
            var name = "Name".Update(Model.Name);
            var firstname = "First name".Update(Model.FirstName);
            var lastname = "Last name".Update(Model.LastName);
            var email = "Email".Update(Model.Email);
            var phone = "Phone".Update(Model.Phone);
            var facebook = "Facebook".Update(Model.Facebook);
            var twitter = "Twitter".Update(Model.Twitter);
            Router.Forward($"do update ? id={id} & name={name} & firstname={firstname} & lastname={lastname} & email={email} & phone={phone} & facebook={facebook} & twitter={twitter}");
        }
    }
}
