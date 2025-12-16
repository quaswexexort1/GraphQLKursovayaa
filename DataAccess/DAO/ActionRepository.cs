using GraphQLKursovayaa.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLKursovayaa.DataAccess.DAO
{
    public class ActionRepository
    {
        private readonly SampleAppDbContext _context;

        public ActionRepository(SampleAppDbContext context)
        {
            _context = context;
        }
        public List<Entity.Action> GetAllActions()
        {
            return _context.Actions
                .Include(a => a.Case)
                .ThenInclude(c => c.Client)
                .Include(a => a.Case)
                .ThenInclude(c => c.Advokats)
                .ToList();
        }

        public List<Entity.Action> GetActionsByCase(int caseId)
        {
            return _context.Actions
                .Where(a => a.CaseId == caseId)
                .Include(a => a.Case)
                .ThenInclude(c => c.Client)
                .ToList();
        }

        public List<Entity.Action> GetCompletedActionsByCase(int caseId)
        {
            return _context.Actions
                .Where(a => a.CaseId == caseId && a.IsCompleted)
                .Include(a => a.Case)
                .ToList();
        }

        public async Task<Entity.Action> CreateAction(Entity.Action action)
        {
            await _context.Actions.AddAsync(action);
            await _context.SaveChangesAsync();
            return action;
        }

        public async Task<Entity.Action> UpdateAction(Entity.Action action)
        {
            _context.Actions.Update(action);
            await _context.SaveChangesAsync();
            return action;
        }

        public async Task DeleteAction(int id)
        {
            var action = await _context.Actions.FindAsync(id);
            if (action != null)
            {
                _context.Actions.Remove(action);
                await _context.SaveChangesAsync();
            }
        }
    }
}
