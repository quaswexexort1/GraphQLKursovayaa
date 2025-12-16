using GraphQLKursovayaa.DataAccess.DAO;
using GraphQLKursovayaa.DataAccess.Entity;
using HotChocolate.Subscriptions;

namespace GraphQLKursovayaa.DataAccess.Data
{
    public class Mutation
    {
        public async Task<Entity.Action> CreateAction([Service] ActionRepository actionRepository, [Service] ITopicEventSender
            eventSender, string actName)
        {
            var act = new Entity.Action { Name = actName };
            var createAct = await actionRepository.CreateAction(act);
            await eventSender.SendAsync("ActionCreated", createAct);
        }
        public async Task<Advokat> CreateAdvokat([Service] AdvokatRepository advokatRepository, [Service] ITopicEventSender
            eventSender,string name, string specialization, string licencenumber, decimal hourlyrate)
        {
            Advokat adv = new Advokat
            {
                Name = name,
                Specialization = specialization,
                LicenseNumber = licencenumber,
                HourlyRate = hourlyrate
            };
            var createAdv = await advokatRepository.CreateAdvokat(adv);
            return createAdv;
        }
    }
}
