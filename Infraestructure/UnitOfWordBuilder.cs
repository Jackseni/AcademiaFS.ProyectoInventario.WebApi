using AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD;
using Farsiman.Domain.Core.Standard.Repositories;
using Farsiman.Infraestructure.Core.Entity.Standard;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure
{
    public class UnitOfWordBuilder
    {
        readonly IServiceProvider _serviceProvider;
        public UnitOfWordBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public IUnitOfWork BuilderSistemaInventario()
        {
            DbContext dbContext = _serviceProvider.GetService<InventarioHjdContext>() ?? throw new NullReferenceException();
            return new UnitOfWork(dbContext);
        }


    }
}
