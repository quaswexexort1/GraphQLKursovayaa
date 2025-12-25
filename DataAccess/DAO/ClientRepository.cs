using GraphQLKursovayaa.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLKursovayaa.DataAccess.DAO
{
    public class ClientRepository
    {
        private readonly SampleAppDbContext _context;

        public ClientRepository(SampleAppDbContext context)
        {
            _context = context;
        }

        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public List<Client> GetAllClientsWithCases()
        {
            return _context.Clients
                .Include(c => c.Cases)
                .ThenInclude(c => c.Advokats)
                .ToList();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients
                .Include(c => c.Cases)
                .ThenInclude(c => c.Advokats)
                .FirstOrDefaultAsync(c => c.ClientId == id);
        }

        public async Task<Client> CreateClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
    }
}
