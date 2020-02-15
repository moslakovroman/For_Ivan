using System;
using System.Data;

namespace api.Repositories.ORMLite
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection DB { get; }

        void Save();

        void Rollback();
    }
}
