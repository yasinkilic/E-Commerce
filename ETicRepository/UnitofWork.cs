using ETicContext;
using System;

namespace ETicRepository
{
    public class UnitofWork : IUnitofWork
    {
        private ProjectContext db=new ProjectContext();
      
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepositoryBase<T> GetRepository<T>() where T : class
        {
            return new RepositoryBase<T>(db);
        }

        public int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch
            {

                throw;
            }
        }
    }
}
