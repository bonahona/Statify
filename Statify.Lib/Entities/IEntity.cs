namespace Statify.Lib.Entities
{
    public interface IEntity
    {
        public Guid Id { get; }
    }

    public interface IEntity<TState,TProject> : IEntity where TState : IState
    {
        TState State { get; set; }
        TProject Project();
    }
}
