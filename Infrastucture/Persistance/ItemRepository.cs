using bootcamp_store_backend.Domain.Entities;
using bootcamp_store_backend.Domain.Persistence;

namespace bootcamp_store_backend.Infrastucture.Persistance
{
    public class ItemRepository : GenericRepository<Item>, IItemReposity
    {
        public ItemRepository(StoreContext storeContext) : base(storeContext)
        {
        }
    }
}
