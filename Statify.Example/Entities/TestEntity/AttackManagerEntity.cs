using Statify.Example.Entities.TestEntity.Messages;
using Statify.Lib;
using Statify.Lib.Attributes;
using Statify.Lib.Entities;
using Statify.Lib.Messages;

namespace Statify.Example.Entities.TestEntity
{
    public class AttackManagerEntity : IEntity
    {
        public Guid Id { get; set; }

        [HandleMessage(typeof(CreateAttackMessage))]
        public MessageHandleResult HandleCreateAttackMessage(IMessageDispatcher dispatcher, CreateAttackMessage message)
        {
            dispatcher.RegisterEntity(new AttackEntity());
            return MessageHandleResult.Handled;
        }
    }
}
