using Statify.Lib.Messages;

namespace Statify.Example.Entities.TestEntity.Messages
{
    public class ExpireAttackMessage : IMessage
    {
        public Guid EntityId { get; set; }
    }
}
