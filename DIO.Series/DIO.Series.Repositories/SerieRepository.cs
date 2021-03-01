using DIO.Series.Domain.Entities;

using DIO.Series.Interfaces;
using System.Collections.Generic;

namespace DIO.Series.Repositories
{
    public class SerieRepository : IRepositoryBase<Serie>
    {
        private readonly List<Serie> serieList = new List<Serie>();

        public void Delete(int id)
        {
            serieList[id].Excluir();
        }

        public List<Serie> GetAll()
        {
            return serieList;
        }

        public Serie GetById(int id)
        {
            return serieList[id];
        }

        public void Insert(Serie entity)
        {
            serieList.Add(entity);
        }

        public int NextId()
        {
            return serieList.Count;
        }

        public void Update(Serie entity, int id)
        {
            serieList[id] = entity;
        }
    }
}