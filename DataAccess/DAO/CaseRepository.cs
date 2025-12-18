using GraphQLKursovayaa.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLKursovayaa.DataAccess.DAO
{
    public class CaseRepository
    {
        private readonly SampleAppDbContext _context;
        public CaseRepository(SampleAppDbContext context)
        {
            _context = context;
        }

        public List<Case> GetAllCases()
        {
            return _context.Cases
                .Include(c => c.Client)
                .Include(c => c.Advokats)
                .Include(c => c.Actions)
                .ToList();
        }

        public List<Case> GetCasesByClient(int clientId)
        {
            return _context.Cases
                .Where(c => c.ClientId == clientId)
                .Include(c => c.Advokats)
                .Include(c => c.Actions)
                .ToList();
        }

        public List<Advokat> GetAdvokatsByCase(int caseId)
        {
            return _context.Cases
                .Where(c => c.CaseId == caseId)
                .Include(c => c.Advokats)
                .SelectMany(c => c.Advokats)
                .ToList();
        }

        public async Task<Case> GetCaseByIdAsync(int id)
        {
            return await _context.Cases
                .Include(c => c.Client)
                .Include(c => c.Advokats)
                .Include(c => c.Actions)
                .FirstOrDefaultAsync(c => c.CaseId == id);
        }

        public async Task<Case> CreateCase(Case caseItem)
        {
            await _context.Cases.AddAsync(caseItem);
            await _context.SaveChangesAsync();
            return caseItem;
        }
        public async Task<Case> UpdateCase(Case caseItem)
        {
            _context.Cases.Update(caseItem);
            await _context.SaveChangesAsync();
            return caseItem;
        }
        public async Task DeleteCase(int id)
        {
            var caseItem = await _context.Cases.FindAsync(id);
            if (caseItem != null)
            {
                _context.Cases.Remove(caseItem);
                await _context.SaveChangesAsync();
            }
        }
        public List<Case> GetCasesByPeriod(DateTime startDate, DateTime endDate)
        {
            return _context.Cases
                .Where(c => c.StartDate >= startDate && c.StartDate <= endDate)
                .Include(c => c.Client)
                .Include(c => c.Advokats)
                .ToList();
        }
    }
}