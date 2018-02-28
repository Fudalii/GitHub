using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models.Interfaces
{
    public interface IOwnerRepository
    {
        Owner GetOwner(int ownerId);

        int AddOwner(Owner owner);

    }
}
