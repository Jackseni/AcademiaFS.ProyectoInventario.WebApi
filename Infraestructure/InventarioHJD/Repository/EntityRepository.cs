using Farsiman.Domain.Core.Standard.Repositories;
using System.Linq.Expressions;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Repository
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly InventarioHjdContext _hjdContext;

        //ctor
        public EntityRepository(InventarioHjdContext hjdContext)
        {
            _hjdContext = hjdContext;
        }
        //prop propiedad clases

        public void Add(TEntity entity)
        {
            _hjdContext.Set<TEntity>().Add(entity);
            _hjdContext.SaveChanges();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _hjdContext.Set<TEntity>().AsQueryable();
        }

        public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> query)
        {

            return _hjdContext.Set<TEntity>().FirstOrDefault();
        }

        public List<TEntity> where(Expression<Func<TEntity, bool>> query)
        {
            return _hjdContext.Set<TEntity>().Where(query).ToList();
        }
    }
}
