using Statify.Lib.Attributes;
using Statify.Lib.Entities;
using Statify.Lib.Extension;
using Statify.Lib.Messages;
using System.Collections.Concurrent;
using System.Reflection;

namespace Statify.Lib
{
    public class MessageDispatcher
    {
        private ConcurrentDictionary<Guid, IEntity> Entities = new ConcurrentDictionary<Guid, IEntity>();
        private ConcurrentQueue<IMessage> Messages = new ConcurrentQueue<IMessage>();

        private Dictionary<Type, MethodInfo> MessageHandlerMap = new Dictionary<Type, MethodInfo>();

        public void RegisterType<T>() where T: IEntity
        {
            var methods = typeof(T).GetMethods()
                .Select(mi => (method: mi, attributes: mi.GetCustomAttributes(true).Where(c => c is HandleMessageAttribute).Cast<HandleMessageAttribute>()))
                .Where(mi => mi.attributes.Any())
                .ForEach(mi => MessageHandlerMap.Add(mi.attributes.First().HandleType, mi.method));
        }

        public void RegisterEntity(IEntity entity)
        {
            if(Entities.ContainsKey(entity.Id)) {
                return;
            }

            Entities.TryAdd(entity.Id, entity);
        }

        public void Enqueue(IMessage message)
        {
            Messages.Enqueue(message);
        }

        public void Run()
        {
            Task.Run(async () => {
                while (true) {
                    while (Messages.Any()) {
                        if (Messages.TryDequeue(out var message)) {
                            HandleMessage(message);
                        } else {
                            await Task.Delay(10);
                        }
                    }
                }
            });
        }

        private void HandleMessage(IMessage message)
        {
            if(!Entities.TryGetValue(message.EntityId, out var entity)) {
                return;
            }

            if(!MessageHandlerMap.TryGetValue(message.GetType(), out var handler)) {
                return;
            }

            handler.Invoke(entity, new object[] { message });
        }
    }
}
