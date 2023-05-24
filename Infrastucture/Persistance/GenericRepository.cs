﻿using bootcamp_store_backend.Domain.Entities;
using bootcamp_store_backend.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace bootcamp_store_backend.Infrastucture.Persistance
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(StoreContext storeContext)
        {
            _context = storeContext;
            _dbSet = _context.Set<T>();
        }

        public void Delete(long id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) throw new ElementNotFoundException();
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList<T>();
        }

        public T GetById(long id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) 
            {
                throw new ElementNotFoundException();
            }
            return entity;
         }

        public T Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }

    }
}