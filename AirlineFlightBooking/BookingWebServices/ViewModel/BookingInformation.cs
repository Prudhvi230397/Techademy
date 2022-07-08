using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.ViewModel
{
    public class BookingInformation
    {
        public string EmailId { get; set; }
        public int NoOfSeats { get; set; }
        public string FlightNo { get; set; }
        public string Boarding { get; set; }
        public string Destination { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsRoundTrip { get; set; }
        public DateTime RoundTripStartDateTime { get; set; }
        public DateTime RoundTripEndDateTime { get; set; }
        public string RoundTripFlightNo { get; set; }

        public List<Passenger> passenger { get; set; }
    }
}
