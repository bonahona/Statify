using Statify.Lib.Messages;

namespace Statify.Example.Entities.TestEntity.Messages
{
    public class CreateAttackMessage : IMessage
    {
        public Guid EntityId { get; set; }
    }
}
