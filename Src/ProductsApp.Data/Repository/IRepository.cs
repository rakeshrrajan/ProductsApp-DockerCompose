using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsApp.Data.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        
    }
}
