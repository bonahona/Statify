using Statify.Lib.Messages;

namespace Statify.Example.Entities.TestEntity.Messages
{
    public class ActivateAttackMessage : IMessage
    {
        public Guid EntityId { get; set; }
    }
}
