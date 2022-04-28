using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Models
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AppDbContext appDbContext;

        public AreaRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Shop>> Search(string name)
        {
            IQueryable<Shop> query = appDbContext.Shops;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }
            return await query.ToListAsync();
        }
    }
}
