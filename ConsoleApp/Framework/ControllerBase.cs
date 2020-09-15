using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class ControllerBase
    {
        public virtual void Render(ViewBase view) => view.Render();
        public virtual void Render<T>(ViewBase<T> view) => view.Render();

        public virtual void Render(Message message)
        {
            Render(new MessageView(message));
        }

        public virtual void Success(string text, string label = "SUCCESS")
        {
            Render(new Message { Type = MessageType.Success, Text = text, Label = label });
        }

        public virtual void Inform(string text, string label = "INFORMATION")
        {
            Render(new Message { Type = MessageType.Information, Text = text, Label = label });
        }

        public virtual void Error(string text, string label = "ERROR")
        {
            Render(new Message { Type = MessageType.Error, Text = text, Label = label });
        }

        public virtual void Confirm(string text, string label = "CONFIRMATION")
        {
            Render(new Message { Type = MessageType.Confirmation, Text = text, Label = label });
        }
    }
}
