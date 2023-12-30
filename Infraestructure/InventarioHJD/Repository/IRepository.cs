using System.Linq.Expressions;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IQueryable<T> AsQueryable();
        List<T> where(Expression<Func<T, bool>> query);

        T? FirstOrDefault(Expression<Func<T, bool>> query);
    }
}
