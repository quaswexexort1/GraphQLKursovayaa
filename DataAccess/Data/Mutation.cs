using GraphQLKursovayaa.DataAccess.DAO;
using GraphQLKursovayaa.DataAccess.Entity;
using HotChocolate.Subscriptions;

namespace GraphQLKursovayaa.DataAccess.Data
{
    public class Mutation
    {
        public async Task<Client> CreateClient(
                   [Service] ClientRepository clientRepository,
                   [Service] ITopicEventSender eventSender,
                   string name,
                   string address = "",
                   string phone = "",
                   string email = "")
        {
            var client = new Client
            {
                Name = name,
                Address = address,
                Phone = phone,
                Email = email
            };
            var createdClient = await clientRepository.CreateClient(client);
            await eventSender.SendAsync("Клиент создан", createdClient);
            return createdClient;
        }




        public async Task<Advokat> CreateAdvokat(
            [Service] AdvokatRepository advokatRepository,
            [Service] ITopicEventSender eventSender,
            string name,
            string specialization = "",
            string licenseNumber = "",
            decimal hourlyRate = 0)
        {
            var advokat = new Advokat
            {
                Name = name,
                Specialization = specialization,
                LicenseNumber = licenseNumber,
                HourlyRate = hourlyRate
            };
            var createdAdvokat = await advokatRepository.CreateAdvokat(advokat);
            await eventSender.SendAsync("AdvokatCreated", createdAdvokat);
            return createdAdvokat;
        }



        public async Task<Case> CreateCase(
            [Service] CaseRepository caseRepository,
            [Service] ITopicEventSender eventSender,
            string title,
            string description = "",
            decimal nominalCost = 0,
            decimal premiumPercent = 0,
            int clientId = 0)
        {
            var caseItem = new Case
            {
                Title = title,
                Description = description,
                NominalCost = nominalCost,
                PremiumPercent = premiumPercent,
                ClientId = clientId,
                StartDate = DateTime.Now
            };
            var createdCase = await caseRepository.CreateCase(caseItem);
            await eventSender.SendAsync("CaseCreated", createdCase);
            return createdCase;
        }

        public async Task<Entity.Action> CreateAction(
            [Service] ActionRepository actionRepository,
           [Service] ITopicEventSender eventSender,
             string title,
             string description = "",
             decimal cost = 0,
             bool isCompleted = false,
            int caseId = 0)
        {
            var action = new Entity.Action
            {
                Title = title,
                Description = description,
                Cost = cost,
                IsCompleted = isCompleted,
                DatePerformed = DateTime.Now,
                CaseId = caseId
            };
            var createdAction = await actionRepository.CreateAction(action);
            await eventSender.SendAsync("ActionCreated", createdAction);
            return createdAction;
        }
    }
}
