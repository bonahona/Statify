namespace Statify.Lib.Entities
{
    public interface IEntity
    {
        public Guid Id { get; }
    }

    public interface IEntity<TState,TProject> : IEntity
    {
        TState State { get; set; }
        TProject Project();
    }
}
