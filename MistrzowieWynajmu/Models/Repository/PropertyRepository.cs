using MistrzowieWynajmu.Models.Database;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PropertyRepository (DatabaseContext databaseContext) {

            _databaseContext = databaseContext;

        }

        // Pobierz wszystkie
        public List<Property> GetAllProperty()
        {
            return _databaseContext.Properties.ToList();
        }

        //Pobierz po ID
        public Property GetProperty(int PropertyId)
        {
            return _databaseContext.Properties.Where(property => property.Id == PropertyId).FirstOrDefault();
        }


        public int AddProperty(Property property, Address addres, Owner owner)
        {

            if (property == null || addres == null || owner == null)
            {
                throw new Exception("Nieprawidłowe dane wejściowe");
            }

            property.Id = 0;
            property.Owner = owner;
            property.Address = addres;

            property.Address = addres;
            property.AddressId = addres.AddressId;

            _databaseContext.Properties.Add(property);
            _databaseContext.SaveChanges();

            return property.Id;

        }

        public void DeleteProperty(Property property, Address addres, Owner owner)
        {
            throw new NotImplementedException();
        }

        public int EditProperty(Property Property)
        {
            throw new NotImplementedException();
        }

    }
}
