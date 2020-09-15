using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    using Framework;
    using Models;
    using Views;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    internal class ContactController : ControllerBase
    {
        private List<Contact> _contact = new List<Contact>();

        public void List()
        {
            var model = _contact.ToArray();
            var view = new ListView(model);
            Render(view);
        }

        public void Single(Parameter p)
        {
            var id = p["id"].To<int>();
            var model = _contact.FirstOrDefault(c => c.Id == id);
            var view = new SingleView(model);
            Render(view);
        }

        public void Create()
        {
            var view = new CreateView();
            Render(view);
        }

        public void Create(Parameter p)
        {
            var contact = Convert(p);
            _contact.Add(contact);
            Success("New contact has been created!");
        }

        public void Update(int id)
        {
            var model = _contact.FirstOrDefault(c => c.Id == id);
            var view = new UpdateView(model);
            Render(view);
        }

        public void Update(Parameter p)
        {
            var contact = Convert(p);
            var model = _contact.FirstOrDefault(c => c.Id == contact.Id);
            _contact.Remove(model);
            _contact.Add(contact);
            Success("Contact has been updated!");
        }

        public void Delete(int id)
        {
            var model = _contact.FirstOrDefault(c => c.Id == id);
            if(model == null)
            {
                Error("Contact not found!");
                return;
            }
            Confirm("Delete this contact? [y/n] ", $"do delete ? id={id}");
        }

        public void Delete(Parameter p)
        {
            var id = p["id"].To<int>();
            var model = _contact.FirstOrDefault(c=>c.Id == id);
            _contact.Remove(model);
            Success("Contact has been removed!");
        }

        public void Save()
        {
            using (FileStream stream = File.OpenWrite("data.dat"))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream,_contact);
                Inform("Data has been saved!");
            }
        }

        public void Load()
        {
            if(!File.Exists("data.dat"))
            {
                Inform("Data file not exist");
                return;
            }
            using (FileStream stream = File.OpenRead("data.dat"))
            {
                var formatter = new BinaryFormatter();
                _contact = formatter.Deserialize(stream) as List<Contact>;
                Inform($"Data have been loaded. {_contact.Count} item(s) found.");
            }
        }

        public Contact Convert(Parameter p)
        {
            var id = p["id"].To<int>();
            var name = p["name"];
            var firstname = p["firstname"];
            var lastname = p["lastname"];
            var phone = p["phone"];
            var email = p["email"];
            var facebook = p["facebook"];
            var twitter = p["twitter"];

            var contact = new Contact
            {
                Id = id,
                Name = name,
                FirstName = firstname,
                LastName = lastname,
                Phone = phone,
                Email = email,
                Facebook = facebook,
                Twitter = twitter
            };

            return contact;
        }
    }
}
