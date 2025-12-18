using GraphQLKursovayaa.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLKursovayaa.DataAccess.DAO
{
    public class AdvokatRepository
    {
        private readonly SampleAppDbContext _context;

        public AdvokatRepository(SampleAppDbContext context)
        {
            _context = context;
        }

        public List<Advokat> GetAllAdvokats()
        {
            return _context.Advokats.ToList();
        }

        public List<Advokat> GetAllAdvokatsWithCases()
        {
            return _context.Advokats
                .Include(l => l.Cases)
                .ThenInclude(c => c.Client)
                .ThenInclude(c => c.Cases)
                .ToList();
        }

        public List<Case> GetCasesByAdvokat(int advokatId)
        {
            return _context.Advokats
                .Where(l => l.AdvokatId == advokatId)
                .Include(l => l.Cases)
                .ThenInclude(c => c.Client)
                .SelectMany(l => l.Cases)
                .ToList();
        }
        public async Task<Advokat> GetAdvokatByIdAsync(int id)
        {
            return await _context.Advokats
                .Include(a => a.Cases)
                .FirstOrDefaultAsync(a => a.AdvokatId == id);
        }

        public async Task<Advokat> CreateAdvokat(Advokat advokat)
        {
            await _context.Advokats.AddAsync(advokat);
            await _context.SaveChangesAsync();
            return advokat;
        }

        public async Task<Advokat> UpdateAdvokat(Advokat advokat)
        {
            _context.Advokats.Update(advokat);
            await _context.SaveChangesAsync();
            return advokat;
        }

        public async Task DeleteAdvokat(int id)
        {
            var advokat = await _context.Advokats.FindAsync(id);
            if (advokat != null)
            {
                _context.Advokats.Remove(advokat);
                await _context.SaveChangesAsync();
            }
        }
    }

}
