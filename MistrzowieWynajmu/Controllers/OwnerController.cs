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
    [Route("api/Owner")]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
    
        //konstruktor

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet("{ownerId}")]
        public IActionResult GetOwner (int ownerId)
        {
            return new JsonResult(_ownerRepository.GetOwner(ownerId));
         
        }

        [HttpPost("[action]")]
        public IActionResult AddOwner([FromBody] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return new JsonResult(_ownerRepository.AddOwner(owner));
        }


    }
}