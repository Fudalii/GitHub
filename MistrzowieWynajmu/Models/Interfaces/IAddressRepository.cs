using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models.Interfaces
{
    public interface IAddressRepository
    {
        Address GetAddress(int addressId);

        int AddAddress(Address address);
    }
}
