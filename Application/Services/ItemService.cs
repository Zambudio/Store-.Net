﻿using AutoMapper;
using bootcamp_store_backend.Application.Dtos;
using bootcamp_store_backend.Domain.Entities;
using bootcamp_store_backend.Domain.Persistence;

namespace bootcamp_store_backend.Application.Services
{
    public class ItemService : GenericService<Item, ItemDto>, IItemService
    {
        public ItemService(IItemReposity repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public List<ItemDto> GetAllByCategoryId(long categoryId)
        {
            var items = ((IItemReposity)_repository).GetByCategoryId(categoryId);
            return items;
        }
    }
}
