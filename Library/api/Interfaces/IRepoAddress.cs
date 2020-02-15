using System.Collections.Generic;
using api.Interfaces.Repositories.Base;
using model.db;

namespace api.Interfaces
{
    public interface IRepoAddress : IBaseRepository<Address>
    {
        List<Address> GetAddressViewModel();
        Address DbAddress(Address model);
        
    }
}