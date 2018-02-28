﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MistrzowieWynajmu.Models.Interfaces;
using MistrzowieWynajmu.Models;

namespace MistrzowieWynajmu.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IAddressRepository _addressRepository;

        //konstruktor 
        public PropertyController(
              IPropertyRepository propertyRepository,
              IOwnerRepository ownerRepository,
              IAddressRepository addressRepository)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
            _addressRepository = addressRepository;

        }


        [HttpGet]
        public IActionResult GetProperties ()
        {
            return new JsonResult(_propertyRepository.GetAllProperty());
        }


        // ..../GetBy/1
        [HttpGet("/GetBy/{PropertyId}")]
        public IActionResult GetProperty(int PropertyId)
        {
            return new JsonResult(_propertyRepository.GetProperty(PropertyId));
        }



        [HttpPost ("[action]")]
        public IActionResult AddProperty (Models.Property property)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Nieprawidłowe dane wejściowe");
            }
       
            var owner = _ownerRepository.GetOwner(property.OwnerId);
            if (owner == null)
            {
                return NotFound("Nie odnaleziono");
            }

            var address = _addressRepository.GetAddress(property.AddressId);

            if (address == null)
            {
                return NotFound("Nie odnaleziono");
            }

            _propertyRepository.AddProperty(property, address, owner);

            return new JsonResult(property.Id);

        }






    }
}