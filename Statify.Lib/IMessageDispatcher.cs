using Statify.Lib.Entities;
using Statify.Lib.Messages;

namespace Statify.Lib
{
    public interface IMessageDispatcher
    {
        IEntity RegisterEntity(IEntity entity);
        void Publish(IMessage message);
    }
}