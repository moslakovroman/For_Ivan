using System;
using System.Data;
using ServiceStack.OrmLite;

namespace api.Repositories.ORMLite
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbConnection DB { get; private set; }
        public IDbTransaction Transaction { get; private set; }
        private bool disposed = false;

        public UnitOfWork(IDbConnectionFactory dbFactory, IsolationLevel isolevel)
        {
            DB = dbFactory.OpenDbConnection();
            Transaction = DB.OpenTransaction(isolevel);
        }

        public UnitOfWork(IDbConnectionFactory dbFactory)
        {
            DB = dbFactory.OpenDbConnection();
            Transaction = DB.OpenTransaction();
        }

        public virtual void Save()
        {
            Transaction.Commit();
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }

        public void Dispose()
        {
            if (disposed) return;

            if (Transaction != default(IDbTransaction))
                Transaction.Dispose();
            if (DB != default(IDbConnection))
                DB.Dispose();

            disposed = true;
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose();
        }
    }
}
