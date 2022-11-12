using Statify.Lib.Entities;
using Statify.Lib.Messages;

namespace Statify.Example.Entities.MessageManager.Messages
{
    public class PostMessage : IMessage
    {
        public Guid EntityId { get; set; }
        public string Message { get; set; }

        public PostMessage(IEntity reciever, string message)
        {
            EntityId = reciever.Id;
            Message = message;
        }
    }
}
