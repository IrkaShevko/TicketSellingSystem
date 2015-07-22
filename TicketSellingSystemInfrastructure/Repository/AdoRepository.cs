using System.Linq;

namespace TicketSellingSystemInfrastructure.Repository
{
    public class AdoRepository<TEntity>:IRepository<TEntity>
    {
        public IQueryable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity entityToDelete)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entityToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}