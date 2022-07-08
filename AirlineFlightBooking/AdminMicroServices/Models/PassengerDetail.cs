using System;
using System.Collections.Generic;

#nullable disable

namespace AdminMicroServices.Models
{
    public partial class PassengerDetail
    {
        public decimal Id { get; set; }
        public string FlightNo { get; set; }
        public string Pnr { get; set; }
        public string PassengerName { get; set; }
        public int? NoOfSeats { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string SeatNo { get; set; }
        public string Meal { get; set; }
        public string EmailId { get; set; }
        public bool? IsCancelled { get; set; }
    }
}
