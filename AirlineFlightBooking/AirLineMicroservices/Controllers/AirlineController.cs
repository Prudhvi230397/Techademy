using AirLineMicroservices.Interface;
using AirLineMicroservices.Models;
using AirLineMicroservices.Services;
using AirLineMicroservices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class AirlineController : ControllerBase
    {
        IRegisterAirline registerAirline;
        IAddInventory addInventory;
        public AirlineController(IAddInventory _addInventory, IRegisterAirline _registerAirline)
        {
            
            registerAirline = _registerAirline;
            addInventory = _addInventory;
    }
       
        [HttpPost("register")]
        public IActionResult RegisterAirline(RegisterAirLineServices _airlines)
        {
            if (registerAirline.RegisterAirline(_airlines))
            return Ok("Airline Registered Successfully");
            return BadRequest();
        }

        [HttpPost("inventory/add")]
        public IActionResult AddInventory(Schedule _schedule )
        {
            
            if(addInventory.AddInventory(_schedule))
            return Ok("Airline Inventory Added Successfully");
            return BadRequest();
        }
    }
}
