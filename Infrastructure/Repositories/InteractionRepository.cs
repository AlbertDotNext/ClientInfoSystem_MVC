using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InteractionRepository : EFRepository<Interaction>, IInteractionRepository
    {
        public InteractionRepository(CISDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Interaction>> GetClientInteractionsById(int id)
        {
            var interactions = await _dbContext.Interatctions.Where(i => i.ClientId == id).Include(i => i.Client).Include(i => i.Emp).ToListAsync();

            return interactions;
        }

        public async Task<IEnumerable<Interaction>> GetEmployeeInteractionsById(int id)
        {
            var interactions = await _dbContext.Interatctions.Where(i => i.EmpId == id).Include(i => i.Client).Include(i => i.Emp).ToListAsync();
            return interactions;
        }

        public async Task<IEnumerable<Interaction>> GetInteractions()
        {
            var interactions = await _dbContext.Interatctions.Include(i => i.Client).Include(i => i.Emp).ToListAsync();

            return interactions;
        }
    }
}
