using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        void Insert(TEntity entity);

        void Delete(int id);

        void Update(TEntity entity, int id);

        int NextId();
    }
}