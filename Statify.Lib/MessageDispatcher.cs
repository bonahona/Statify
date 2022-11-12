using Statify.Lib.Attributes;
using Statify.Lib.Entities;
using Statify.Lib.Extension;
using Statify.Lib.Messages;
using System.Collections.Concurrent;
using System.Reflection;

namespace Statify.Lib
{
    public class MessageDispatcher : IMessageDispatcher
    {
        private ConcurrentDictionary<Guid, IEntity> Entities = new ConcurrentDictionary<Guid, IEntity>();
        private ConcurrentQueue<IMessage> Messages = new ConcurrentQueue<IMessage>();

        private Dictionary<Type, MethodInfo> MessageHandlerMap = new Dictionary<Type, MethodInfo>();

        public void RegisterTypes()
        {
            var entityType = typeof(IEntity);
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.ExportedTypes)
                .Where(t => t.IsPublic && entityType.IsAssignableFrom(t))
                .ForEach(t => RegisterType(t));
        }

        private void RegisterType(Type t) 
        {
            var methods = t.GetMethods()
                .Select(mi => (method: mi, attributes: mi.GetCustomAttributes(true).Where(c => c is HandleMessageAttribute).Cast<HandleMessageAttribute>()))
                .Where(mi => mi.attributes.Any())
                .ForEach(mi => MessageHandlerMap.Add(mi.attributes.First().HandleType, mi.method));
        }

        public IEntity RegisterEntity(IEntity entity)
        {
            if (Entities.ContainsKey(entity.Id)) {
                throw new ArgumentException();
            }

            Entities.TryAdd(entity.Id, entity);
            return entity;
        }

        public void Publish(IMessage message)
        {
            Messages.Enqueue(message);
        }

        public void Run(CancellationToken cancellationToken)
        {
            Task.Run(async () => {
                Console.WriteLine("Start running dispatcher");
                while (true) {
                    while (Messages.Any()) {
                        if (Messages.TryDequeue(out var message)) {
                            HandleMessage(message);
                        }
                    }
                    await Task.Delay(1000);
                }

            }, cancellationToken).ConfigureAwait(false);
        }

        private void HandleMessage(IMessage message)
        {
            if (!Entities.TryGetValue(message.EntityId, out var entity)) {
                return;
            }

            if (!MessageHandlerMap.TryGetValue(message.GetType(), out var handler)) {
                return;
            }

            Console.WriteLine($"Handling {message.GetType()} on {message.EntityId}");
            handler.Invoke(entity, new object[] { message });
        }
    }
}
