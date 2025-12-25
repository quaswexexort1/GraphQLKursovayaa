using GraphQLKursovayaa.DataAccess.Entity;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQLKursovayaa.DataAccess.Data
{
    public class Subscriprtion
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Entity.Action>> OnActionCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancalltionToken)
        {
            return await eventReceiver.SubscribeAsync<Entity.Action>("ActionCreated", cancalltionToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Advokat>> OnAdvokatGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancalltionToken)
        {
            return await eventReceiver.SubscribeAsync<Advokat>("ReturnedAdvokat", cancalltionToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Case>> OnCaseCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancalltionToken)
        {
            return await eventReceiver.SubscribeAsync<Case>("CaseCreated", cancalltionToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Client>> OnClientGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancalltionToken)
        {
            return await eventReceiver.SubscribeAsync<Client>("ReturnedClient", cancalltionToken);
        }

    }
}
