using Statify.Lib.Entities;

namespace Statify.Example.Entities.MessageManager
{
    public class MessageManagerEntity : IEntity<MessageManagerState, List<string>>
    {
        public Guid Id { get; set; }

        public MessageManagerState State { get; set; } = new();

        public List<string> Project() => State.Messages;
    }
}
