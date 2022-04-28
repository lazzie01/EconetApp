using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackendApi.Models
{
    public class ShopRepository : IShopRepository
    {
        private readonly AppDbContext appDbContext;

        public ShopRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Shop> AddShop(Shop shop)
        {
            if (shop.Area != null)
            {
                appDbContext.Entry(shop.Area).State = EntityState.Unchanged;
            }
            var result = await appDbContext.Shops.AddAsync(shop);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Shop> GetShopByName(string name)
        {
            return await appDbContext.Shops.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<Shop> GetShop(int shopId)
        {
            return await appDbContext.Shops
                                     .Include(e => e.Area)
                                     .FirstOrDefaultAsync(e => e.Id == shopId);
        }
    }
}
