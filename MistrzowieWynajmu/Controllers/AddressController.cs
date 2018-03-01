using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MistrzowieWynajmu.Models;
using MistrzowieWynajmu.Models.Interfaces;

namespace MistrzowieWynajmu.Controllers
{
    [Produces("application/json")]
    [Route("api/Address")]
    public class AddressController : Controller
    {


        private readonly IAddressRepository _addressRepository;


        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet("{addressId}")]
        public IActionResult GetAddress(int addressId)
        {
            return new JsonResult(_addressRepository.GetAddress(addressId));
            
        }

       
        [HttpPost("[action]")]
        public IActionResult AddAddress([FromBody] Address address)
        {
            return new JsonResult(_addressRepository.AddAddress(address));
        
        }




    }
}