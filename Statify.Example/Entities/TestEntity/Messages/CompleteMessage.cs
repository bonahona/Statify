using Statify.Lib.Messages;

namespace Statify.Example.Entities.TestEntity.Messages
{
    public class CompleteAttackMessage : IMessage
    {
        public Guid EntityId { get; set; }
    }
}
