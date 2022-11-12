using Statify.Lib.Entities;

namespace Statify.Example.Entities.TestEntity
{
    public enum TestEntityState : byte
    {
        Idle = 0,
        Activated = 1,
        Completed = 2,
        Expired = 3
    }
}
