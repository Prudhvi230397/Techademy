using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebServices.Services
{
    public class SearchFlightResults
    {
        public string AirlineName { get; set; }
        public byte[] AirlineLogo { get; set; }
        public string BoardingPlace { get; set; }
        public string Destination { get; set; }
        public string FlightNo { get; set; }
        public decimal TicketCost { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool RoundTripFlag { get; set; }

    }
}
