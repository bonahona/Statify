using Statify.Lib.Entities;

namespace Statify.Example.Entities.TestEntity
{
    public class TestEntityState : IState
    {
        public void Load()
        {
            throw new NotImplementedException();
        }

        public bool Persist()
        {
            throw new NotImplementedException();
        }

        public int Value { get; set; }
    }
}
