using MistrzowieWynajmu.Models.Database;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OwnerRepository(DatabaseContext databaseContext)
        {

            _databaseContext = databaseContext;

        }

        public Owner GetOwner(int ownerId)
        {
            return _databaseContext.Owners.Where(owner => owner.OwnerId == ownerId).FirstOrDefault();
        }

        public int AddOwner(Owner owner)
        {
            _databaseContext.Owners.Add(owner);
            _databaseContext.SaveChanges();
            return owner.OwnerId;


        }


    }
}
