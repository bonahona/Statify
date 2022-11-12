using Statify.Example.Entities.TestEntity.Messages;
using Statify.Lib.Attributes;
using Statify.Lib.Entities;

namespace Statify.Example.Entities.TestEntity
{
    public class TestEntity : IEntity<TestEntityState, int>
    {
        public Guid Id { get; set; }

        public TestEntityState State { get; set; } = new TestEntityState();

        public int Project() => State.Value;

        [HandleMessage(typeof(IncreaseValueMessage))]
        public void IncreaseValue(IncreaseValueMessage _)
        {
            State.Value++;
        }

        [HandleMessage(typeof(DecreaseValueMessage))]
        public void DecreaseValue(IncreaseValueMessage _)
        {
            State.Value++;
        }
    }
}
