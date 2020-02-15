using System.Collections.Generic;
using api.Interfaces;
using api.Repositories.ORMLite;
using model.db;


namespace api.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IRepoAddress
    {
        private IRepoAddress _repoAddress;


        public AddressRepository(IUnitOfWorkProvider provider) : base(provider)
        {
            
        }

        

        public List<Address> GetAddressViewModel()
        {
            return new List<Address>();
        }

        public Address DbAddress(Address address)
        {
            return _repoAddress.Save(address);
        }

       
    }
}
