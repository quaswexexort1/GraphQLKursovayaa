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

        public async Task<Client?> UpdateClient(
            [Service] ClientRepository clientRepository,
            [Service] ITopicEventSender eventSender,
            int id,
            string name,
            string address,
            string phone,
            string email)
        {
            var client = await clientRepository.GetClientById(id);
            if (client == null)
                return null;

            client.Name = name;
            client.Address = address;
            client.Phone = phone;
            client.Email = email;

            var updated = await clientRepository.UpdateClient(client);
            await eventSender.SendAsync("ClientUpdated", updated);
            return updated;
        }

        public async Task<bool> DeleteClient(
            [Service] ClientRepository clientRepository,
            [Service] ITopicEventSender eventSender,
            int id)
        {
            await clientRepository.DeleteClient(id);
            await eventSender.SendAsync("ClientDeleted", id);
            return true;
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


        public async Task<Advokat?> UpdateAdvokat(
            [Service] AdvokatRepository advokatRepository,
            [Service] ITopicEventSender eventSender,
            int id,
            string name,
            string specialization,
            string licenseNumber,
            decimal hourlyRate)
        {
            var advokat = await advokatRepository.GetAdvokatByIdAsync(id);
            if (advokat == null)
                return null;

            advokat.Name = name;
            advokat.Specialization = specialization;
            advokat.LicenseNumber = licenseNumber;
            advokat.HourlyRate = hourlyRate;

            var updated = await advokatRepository.UpdateAdvokat(advokat);
            await eventSender.SendAsync("AdvokatUpdated", updated);
            return updated;
        }

        public async Task<bool> DeleteAdvokat(
          [Service] AdvokatRepository advokatRepository,
         [Service] ITopicEventSender eventSender,
              int id)
        {
            await advokatRepository.DeleteAdvokat(id);
            await eventSender.SendAsync("AdvokatDeleted", id);
            return true;
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

        public async Task<Case?> UpdateCase(
            [Service] CaseRepository caseRepository,
            [Service] ITopicEventSender eventSender,
            int id,
            string title,
            string description,
            decimal nominalCost,
            decimal premiumPercent,
            bool isWon)
        {
            var caseItem = await caseRepository.GetCaseByIdAsync(id);
            if (caseItem == null)
                return null;

            caseItem.Title = title;
            caseItem.Description = description;
            caseItem.NominalCost = nominalCost;
            caseItem.PremiumPercent = premiumPercent;
            caseItem.IsWon = isWon;
            if (isWon || caseItem.IsWon)
                caseItem.EndDate = DateTime.Now;

            var updated = await caseRepository.UpdateCase(caseItem);
            await eventSender.SendAsync("CaseUpdated", updated);
            return updated;
        }

        public async Task<bool> DeleteCase(
            [Service] CaseRepository caseRepository,
            [Service] ITopicEventSender eventSender,
            int id)
        {
            await caseRepository.DeleteCase(id);
            await eventSender.SendAsync("CaseDeleted", id);
            return true;
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

        public async Task<Entity.Action?> EditAction(
           [Service] ActionRepository actionRepository,
           [Service] ITopicEventSender eventSender,
           int id,
           string title,
           string description,
           decimal cost,
           bool isCompleted)
        {
            var action = await actionRepository.GetActionByIdAsync(id);
            if (action == null)
                return null;

            action.Title = title;
            action.Description = description;
            action.Cost = cost;

            if (!action.IsCompleted && isCompleted)
            {
                action.IsCompleted = true;
                action.EndDate = DateTime.Now;
            }
            else
            {
                action.IsCompleted = isCompleted;
            }

            var updated = await actionRepository.EditAction(action);
            await eventSender.SendAsync("ActionUpdated", updated);
            return updated;
        }

        public async Task<bool> DeleteAction(
            [Service] ActionRepository actionRepository,
            [Service] ITopicEventSender eventSender,
            int id)
        {
            await actionRepository.DeleteAction(id);
            await eventSender.SendAsync("ActionDeleted", id);
            return true;
        }

    }
}
