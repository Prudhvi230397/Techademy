using BookingWebServices.Interface;
using BookingWebServices.Models;
using BookingWebServices.ViewModel;
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
    public class BookingController : ControllerBase
    {
        IBookFlight bookFlight;
        public BookingController(IBookFlight _bookFlight)
        {
            bookFlight = _bookFlight;
        }
        [HttpPost]
        [Route("{flightNo}")]
        public IActionResult BookTicket([FromRoute] string flightNo, BookingInformation passengerList)
        {
           
            Random random = new Random();
            int pnr = random.Next(1,90000000);
            string msg = "Ticket Booked Successfully with PNR :" + pnr;
            if (bookFlight.UpdatePassengerDetails(passengerList,Convert.ToString(pnr), Convert.ToString(flightNo)))
            return Ok(msg);
            return BadRequest();
         }
    }
}
