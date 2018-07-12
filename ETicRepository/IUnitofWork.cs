using System;

namespace ETicRepository
{
    public interface IUnitofWork : IDisposable
    {
        IRepositoryBase<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
