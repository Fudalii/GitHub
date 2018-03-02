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


        //Pobierz 1 rekord po ID

        public Property GetProperty(int PropertyId)
        {
            return _databaseContext.Properties.Where(property => property.Id == PropertyId).FirstOrDefault();
        }


        // POST dodanie rekordu

        public int AddProperty(Property property, Address addres, Owner owner)
        {

            if (property == null || addres == null || owner == null)
            {
                throw new Exception("Nieprawidłowe dane wejściowe");
            }

            property.Id = 0;
            property.Owner = owner;
            property.OwnerId = owner.OwnerId;

            property.Address = addres;
            property.AddressId = addres.AddressId;

            _databaseContext.Properties.Add(property);
            _databaseContext.SaveChanges();

            return property.Id;

        }

        // Edit Property

        public int EditProperty(Property property)
        {
            if (property == null)
            {
                throw new Exception("Nieprawidłowe dane wejściowe");
            }

            _databaseContext.Properties.Update(property);
            _databaseContext.SaveChanges();

            return property.Id;
             
        }



    
        // DELETE property

        public void DeleteProperty(Property property, Address address, Owner owner)
        {

            if (property == null || address == null || owner == null)
            {
                throw new Exception("Błąd danych wejściowych");
            }

            _databaseContext.Properties.Remove(property);
            _databaseContext.SaveChanges();

            _databaseContext.Addresses.Remove(address);
            _databaseContext.SaveChanges();

            _databaseContext.Owners.Remove(owner);
            _databaseContext.SaveChanges();

        }

      

    }
}
