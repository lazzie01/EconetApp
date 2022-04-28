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

        public async Task<IEnumerable<Shop>> Search(string area)
        {
            if (!string.IsNullOrEmpty(area))
            {
                var areaFound = appDbContext.Areas.Include(e => e.Shops)
                    .FirstOrDefault(e => e.Name.Contains(area));

                return areaFound.Shops.ToList();
            }
            return null;
        }
    }
}
