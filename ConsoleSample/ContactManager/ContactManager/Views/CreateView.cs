using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Views
{
    using Framework;
    internal class CreateView : ViewBase
    {
        public CreateView()
        {

        }
        public override void Render()
        {
            var id = "ID".Read<int>();
            var name = "Name".Read();
            var firstname = "First name".Read();
            var lastname = "Last name".Read();
            var email = "Email".Read();
            var phone = "Phone".Read();
            var facebook = "Facebook".Read();
            var twitter = "Twitter".Read();
            Router.Forward($"do create ? id={id} & name={name} & firstname={firstname} & lastname={lastname} & email={email} & phone={phone} & facebook={facebook} & twitter={twitter}");

        }
    }
}
