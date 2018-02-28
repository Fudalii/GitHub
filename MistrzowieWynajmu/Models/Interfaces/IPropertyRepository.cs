using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models.Interfaces
{
    public interface IPropertyRepository
    {
        List<Property> GetAllProperty();  // pobiera wszystko

        Property GetProperty(int PropertyId);  // pobiera jeden rekord po ID

        int AddProperty(Property property, Address addres, Owner owner); // Dodaje POST

        int EditProperty(Property Property); // PUT - update rekordu o danym ID

        void DeleteProperty(Property property, Address addres, Owner owner);  // Delete o dnym ID

    }
}
