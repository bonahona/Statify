using Statify.Example.Entities.MessageManager.Messages;
using Statify.Example.Entities.TestEntity.Messages;
using Statify.Lib;
using Statify.Lib.Attributes;
using Statify.Lib.Entities;

namespace Statify.Example.Entities.TestEntity
{
    public class AttackEntity : IEntity<TestEntityState, TestEntityState>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public TestEntityState State { get; set; } = TestEntityState.Idle;

        public TestEntityState Project() => State;

        [HandleMessage(typeof(ActivateAttackMessage))]
        public void ActivateAttack(IMessageDispatcher dispatcher, ActivateAttackMessage _)
        {
            dispatcher.Publish(new PostMessage(this, "Testing"));
            State = TestEntityState.Activated;
        }

        [HandleMessage(typeof(CompleteAttackMessage))]
        public void CompleteAttack(IMessageDispatcher dispatcher, CompleteAttackMessage _)
        {
            State = TestEntityState.Completed;
        }

        [HandleMessage(typeof(ExpireAttackMessage))]
        public void ExpireAttack(IMessageDispatcher dispatcher, ExpireAttackMessage _)
        {
            State = TestEntityState.Completed;
        }
    }
}
