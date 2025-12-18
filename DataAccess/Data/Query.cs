using GraphQLKursovayaa.DataAccess.DAO;
using GraphQLKursovayaa.DataAccess.Entity;
using HotChocolate.Subscriptions;

namespace GraphQLKursovayaa.DataAccess.Data
{
    public class Query
    {
        //клиенты
        public List<Client> AllClientsOnly([Service] ClientRepository clientRepository)
            => clientRepository.GetAllClients();

        public List<Client> AllClientsWithCases([Service] ClientRepository clientRepository)
            => clientRepository.GetAllClientsWithCases();

        //Адвокаты
        public List<Advokat> AllAdvokatsOnly([Service] AdvokatRepository advokatRepository)
            => advokatRepository.GetAllAdvokats();

        public List<Advokat> AllAdvokatsWithCases([Service] AdvokatRepository advokatRepository)
            => advokatRepository.GetAllAdvokatsWithCases();

        //Дела
        public List<Case> AllCases([Service] CaseRepository caseRepository)
            => caseRepository.GetAllCases();

        public List<Case> CasesByClient([Service] CaseRepository caseRepository, int clientId)
            => caseRepository.GetCasesByClient(clientId);
        public List<Case> CasesByAdvokat([Service] AdvokatRepository advokatRepository, int advokatId)
            => advokatRepository.GetCasesByAdvokat(advokatId);

        public List<Case> CasesByPeriod([Service] CaseRepository caseRepository, DateTime startDate, DateTime endDate)
            => caseRepository.GetCasesByPeriod(startDate, endDate);

        //Действия
        public List<Entity.Action> AllActions([Service] ActionRepository actionRepository)
            => actionRepository.GetAllActions();

        public List<Entity.Action> ActionsByCase([Service] ActionRepository actionRepository, int caseId)
            => actionRepository.GetActionsByCase(caseId);

        public List<Entity.Action> CompletedActionsByCase([Service] ActionRepository actionRepository, int caseId)
            => actionRepository.GetCompletedActionsByCase(caseId);






        public async Task<Advokat> GetAdvokatById([Service] AdvokatRepository advokatRepository, [Service] ITopicEventSender eventSender, int id)
        {
            var advokat = await advokatRepository.GetAdvokatByIdAsync(id);
            if (advokat != null)
                await eventSender.SendAsync("AdvokatReturned", advokat);
            return advokat;
        }

        public async Task<Case> GetCaseById([Service] CaseRepository caseRepository, [Service] ITopicEventSender eventSender, int id)
        {
            var caseItem = await caseRepository.GetCaseByIdAsync(id);
            if (caseItem != null)
                await eventSender.SendAsync("CaseReturned", caseItem);
            return caseItem;
        }

        public List<Advokat> AdvokatsByCase([Service] CaseRepository caseRepository, int caseId)
            => caseRepository.GetAdvokatsByCase(caseId);
    }
}