
namespace api.Repositories.ORMLite
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork GetUnitOfWork();
    }
}
