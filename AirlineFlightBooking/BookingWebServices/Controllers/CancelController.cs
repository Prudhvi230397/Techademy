using BookingWebServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancelController : ControllerBase
    {


        ICancelTicket cancelTicket;
        public CancelController(ICancelTicket _cancelTicket)
        {
            cancelTicket = _cancelTicket;
        }
        [HttpDelete]
        [Route("{pnr}")]
        public IActionResult getpnrDetails([FromRoute] string pnr)
        {
            if(cancelTicket.CancelTicket(pnr))
            return Ok("Ticket Cancelled");
            return BadRequest();
        }
    }
}
