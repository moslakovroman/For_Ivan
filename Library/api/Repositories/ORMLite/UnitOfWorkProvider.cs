using ServiceStack.OrmLite;

namespace api.Repositories.ORMLite
{
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        protected IDbConnectionFactory Factory { get; set; }

        public UnitOfWorkProvider(IDbConnectionFactory factory)
        {
            Factory = factory;
        }

        public virtual IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(Factory);
        }
    }
}
