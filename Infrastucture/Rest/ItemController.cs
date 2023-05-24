using bootcamp_store_backend.Application.Dtos;
using bootcamp_store_backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace bootcamp_store_backend.Infrastucture.Rest
{
    [Route("store/[controller]")]
    [ApiController]
    public class ItemController : GenericCrudController<ItemDto>
    {
        public ItemController(IItemService service) : base(service)
        {
        }
    }
}
