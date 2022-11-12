using Statify.Example.Entities.TestEntity;
using Statify.Example.Entities.TestEntity.Messages;
using Statify.Lib;

var dispatcher = new MessageDispatcher();
dispatcher.RegisterTypes();

var entity = new AttackManagerEntity {  Id = Guid.NewGuid() };
dispatcher.RegisterEntity(entity);

dispatcher.Publish(new CreateAttackMessage { EntityId = entity.Id });

dispatcher.Run(new CancellationToken());

while(true) {
    dispatcher.Publish(new CreateAttackMessage { EntityId = entity.Id });
    await Task.Delay(1000);
}



