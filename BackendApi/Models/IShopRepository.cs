using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Models
{
    public interface IShopRepository
    {
        Task<Shop> AddShop(Shop shop);
    }
}
