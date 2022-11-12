using Statify.Example.Entities.TestEntity;
using Statify.Example.Entities.TestEntity.Messages;
using Statify.Lib;

var dispatcher = new MessageDispatcher();
dispatcher.RegisterType<TestEntity>();

var entity = new TestEntity {  Id = Guid.NewGuid() };
dispatcher.RegisterEntity(entity);

dispatcher.Enqueue(new IncreaseValueMessage { EntityId = entity.Id });
dispatcher.Enqueue(new IncreaseValueMessage { EntityId = entity.Id });
dispatcher.Enqueue(new IncreaseValueMessage { EntityId = entity.Id });
dispatcher.Enqueue(new IncreaseValueMessage { EntityId = entity.Id });
dispatcher.Enqueue(new IncreaseValueMessage { EntityId = entity.Id });
dispatcher.Enqueue(new IncreaseValueMessage { EntityId = entity.Id });


dispatcher.Run();

Console.ReadLine();