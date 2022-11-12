using Statify.Lib.Messages;

namespace Statify.Example.Entities.TestEntity.Messages
{
    public class IncreaseValueMessage : IMessage
    {
        public Guid EntityId { get; set; }
    }
}
