using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineMicroservices.ViewModel
{
    public class Schedule
    {
        public string FlightNo { get; set; }
        public int AirlineId { get; set; }
        public string BoardingPlace { get; set; }
        public string Destination { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string ScheduledDaysId { get; set; }
        public string InstrumentUsed { get; set; }
        public int BusinessClassSeats { get; set; }
        public int EconomySeats { get; set; }
        public decimal TicketCost { get; set; }
        public int NoOfRows { get; set; }
        public string MealId { get; set; }
    }
}
