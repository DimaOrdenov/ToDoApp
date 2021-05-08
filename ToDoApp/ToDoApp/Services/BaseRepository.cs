using System;
using System.Collections.Generic;
using LiteDB;
using ToDoApp.Definitions.Entities;

namespace ToDoApp.Services
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly Lazy<ILiteDatabase> _db;

        protected BaseRepository(Lazy<ILiteDatabase> db)
        {
            _db = db;
        }

        public int Create(TEntity entity)
        {
            if (entity.CreatedAt == default)
            {
                entity.CreatedAt = DateTimeOffset.Now;
            }

            return _db.Value.GetCollection<TEntity>().Insert(entity);
        }

        public IEnumerable<TEntity> Get() =>
            _db.Value.GetCollection<TEntity>().FindAll();

        public bool Update(TEntity entity)
        {
            if (entity.UpdatedAt == default)
            {
                entity.UpdatedAt = DateTimeOffset.Now;
            }

            return _db.Value.GetCollection<TEntity>().Update(entity);
        }

        public bool Delete(int id) =>
            _db.Value.GetCollection<TEntity>().Delete(id);
    }
}
