using BookingWebServices.Interface;
using BookingWebServices.Models;
using BookingWebServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebServices.Services
{
    public class BookFlightImpl : IBookFlight
    {
        AirLineBookingDBContext db;
        public BookFlightImpl(AirLineBookingDBContext _db)
        {
            db = _db;
        }
        public bool UpdatePassengerDetails(BookingInformation Bookinginfo, string pnr, string flightNo)
        {
            try
            {
                    PassengerDetail passengerDetail = new PassengerDetail();
                    BookingDetail booking = new BookingDetail();
                    booking.FlightNo = flightNo;
                    booking.NoOfseats = Bookinginfo.NoOfSeats;
                    booking.EmailId = Bookinginfo.EmailId;
                    booking.StartDateTime = Bookinginfo.StartDateTime;
                    booking.EndDateTime = Bookinginfo.EndDateTime;
                    booking.EmailId = Bookinginfo.EmailId;
                    booking.Destination = Bookinginfo.Destination;
                    booking.Boarding = Bookinginfo.Boarding;
                    booking.IsCancelled = Bookinginfo.IsRoundTrip;
                    booking.IsCancelled = false;
                    booking.Pnr = pnr;

                    foreach (var passenger in Bookinginfo.passenger)
                    { 
                    passengerDetail.Age = passenger.Age;
                    passengerDetail.Gender = passenger.Gender;
                    passengerDetail.PassengerName = passenger.PassengerName;
                    passengerDetail.SeatNo = passenger.SeatNo;
                    passengerDetail.Meal = passenger.Meal;
                    passengerDetail.NationalId = passenger.NationalId;
                    passengerDetail.Pnr = pnr;
                   
                    
                    }

                    if (Bookinginfo.IsRoundTrip)
                    {

                        booking.RoundTripStartDateTime = Bookinginfo.RoundTripStartDateTime;
                        booking.RoundTripEndDateTime = Bookinginfo.RoundTripEndDateTime;
                        booking.RoundTripFlightNo = Bookinginfo.RoundTripFlightNo;
                    }
                    db.PassengerDetails.Add(passengerDetail);
                    db.BookingDetails.Add(booking);
                    db.SaveChanges();
                
                return true;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
