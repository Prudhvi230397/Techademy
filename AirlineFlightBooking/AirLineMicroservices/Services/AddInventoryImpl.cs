using AirLineMicroservices.Interface;
using AirLineMicroservices.Models;
using AirLineMicroservices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineMicroservices.Services
{
    public class AddInventoryImpl : IAddInventory
    {
        AirLineInventoryDBContext db;
        public AddInventoryImpl(AirLineInventoryDBContext _db)
        {
            db = _db;

        }
        public bool AddInventory(Schedule _schedule)
        {
            try
            {
                FlightSchedule schedule = new FlightSchedule();
                schedule.FlightNo = _schedule.FlightNo;
                schedule.AirlineId = _schedule.AirlineId;
                schedule.BoardingPlace = _schedule.BoardingPlace;
                schedule.Destination = _schedule.Destination;
                schedule.StartDateTime = _schedule.StartDateTime;
                schedule.EndDateTime = _schedule.EndDateTime;
                schedule.EconomySeats = _schedule.EconomySeats;
                schedule.BusinessClassSeats = _schedule.BusinessClassSeats;
                schedule.VacantEconomySeats = _schedule.EconomySeats;
                schedule.VacantBusinessSeats = _schedule.BusinessClassSeats;
                schedule.TicketCost = _schedule.TicketCost;
                schedule.ScheduledDaysId = _schedule.ScheduledDaysId;
                schedule.InstrumentUsed = _schedule.InstrumentUsed;
                schedule.MealId = _schedule.MealId;
                schedule.NoOfRows = _schedule.NoOfRows;
                db.FlightSchedules.Add(schedule);
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
