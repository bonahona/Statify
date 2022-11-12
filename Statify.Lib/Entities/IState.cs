namespace Statify.Lib.Entities
{
    public interface IState
    {
        bool Persist();
        void Load();
    }
}
