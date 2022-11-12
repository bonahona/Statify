using Statify.Lib.Messages;

namespace Statify.Example.Entities.TestEntity.Messages
{
    public class DecreaseValueMessage : IMessage
    {
        public Guid EntityId { get; set; }
    }
}
