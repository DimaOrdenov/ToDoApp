using System.Collections.Generic;
using ToDoApp.Definitions.Entities;

namespace ToDoApp.Services
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        int Create(TEntity entity);

        IEnumerable<TEntity> Get();

        bool Update(TEntity entity);

        bool Delete(int id);
    }
}
