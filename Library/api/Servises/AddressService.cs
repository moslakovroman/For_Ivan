using System.Collections.Generic;
using System.Linq;
using api.Interfaces;
using model.db;
using model.Filters;


namespace api.Servises
{
    public class AddressService : IAddressService
    {
        private readonly IRepoAddress _repoAddress;
        public AddressService(IRepoAddress repoAddress)
        {
             _repoAddress = repoAddress;


             //_repoAddress.Save(new Address());
        }

        public AddressService()
        {
            
        }


        public List<Address> GetAddressInfo()
        {
            return _repoAddress.GetByFilter(new BaseFilter());
        }

        public Address DbAddress(Address model)
        {
            return _repoAddress.Save(model);
        }

        public Address AddHouse(Address house)
        {
            return _repoAddress.Save(house);
        }
    }
}