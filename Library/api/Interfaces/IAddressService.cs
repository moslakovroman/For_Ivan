using System.Collections.Generic;
using model.db;

namespace api.Interfaces
{
    public interface IAddressService
    {
        List<Address> GetAddressInfo();
        Address DbAddress(Address model);
        Address AddHouse(Address house);
    }
}