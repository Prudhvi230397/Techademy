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
    public class HistoryController : ControllerBase
    {
        IBookingHistory bookingHistory;
        public HistoryController(IBookingHistory _bookingHistory)
        {
            bookingHistory = _bookingHistory;
        }
        [HttpGet]
        [Route("{email}")]
        public IEnumerable<BookingHistoryInfo> getpnrDetails([FromRoute] string email)
        {
            return bookingHistory.BookingHistory(email);
        }
    }
}
