using NPOI.SS.Formula.Functions;
using SearchWebServices.Interface;
using SearchWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebServices.Services
{
    public class SearchFlightImpl : ISearchFlights
    {

        AirLineInventoryDBContext db;
        public SearchFlightImpl(AirLineInventoryDBContext _db)
        {
            db = _db;
        }

        public List<SearchFlightResults> SearchFlights(SearchFlightDetails searchFlight)
        {
            //var data = db.AirLineSchedules.Where(x => x.BoardingPlace == searchFlight.BoardingPlace && x.Destination == searchFlight.Destination && x.StartDateTime == searchFlight.StartDateTime && x.EndDateTime == searchFlight.EndDateTime && x.IsRoundTrip == searchFlight.IsRoundTrip);
            // return data.ToList();

            var data1 = from s in db.FlightSchedules
                        from a in db.AirLines
                        where (s.AirlineId == a.AirlineId && s.BoardingPlace == searchFlight.BoardingPlace
                             && s.Destination == searchFlight.Destination && s.StartDateTime == searchFlight.StartDateTime
                             && s.EndDateTime == searchFlight.EndDateTime && a.IsBlocked == false)
                        select new { a.AirlineName, a.AirlineLogo, s.BoardingPlace, s.Destination, s.StartDateTime,s.EndDateTime, s.FlightNo, s.TicketCost };
       
            List<SearchFlightResults> searchResultsList = new List<SearchFlightResults>();
            foreach(var results in data1)
            {
                SearchFlightResults searchResults = new SearchFlightResults();
                searchResults.AirlineName = results.AirlineName;
                searchResults.AirlineLogo = results.AirlineLogo;
                searchResults.BoardingPlace = results.BoardingPlace;
                searchResults.Destination = results.Destination;
                searchResults.FlightNo = results.FlightNo;
                searchResults.TicketCost = results.TicketCost;
                searchResults.StartDateTime = results.StartDateTime;
                searchResults.EndDateTime = results.EndDateTime;
                searchResults.RoundTripFlag = false;
                searchResultsList.Add(searchResults);
            }
            if (searchFlight.IsRoundTrip) {
                var data2 = from s in db.FlightSchedules
                            from a in db.AirLines
                            where (s.AirlineId == a.AirlineId && s.BoardingPlace == searchFlight.Destination
                                 && s.Destination == searchFlight.BoardingPlace && s.StartDateTime == searchFlight.RoundStartDateTime
                                 && s.EndDateTime == searchFlight.RoundEndDateTime && a.IsBlocked == false)
                            select new { a.AirlineName, a.AirlineLogo, s.BoardingPlace, s.Destination, s.StartDateTime, s.EndDateTime, s.FlightNo, s.TicketCost };
                
                foreach (var results in data2)
                {
                    SearchFlightResults searchResults = new SearchFlightResults();
                    searchResults.AirlineName = results.AirlineName;
                    searchResults.AirlineLogo = results.AirlineLogo;
                    searchResults.BoardingPlace = results.BoardingPlace;
                    searchResults.Destination = results.Destination;
                    searchResults.FlightNo = results.FlightNo;
                    searchResults.TicketCost = results.TicketCost;
                    searchResults.StartDateTime = results.StartDateTime;
                    searchResults.EndDateTime = results.EndDateTime;
                    searchResults.RoundTripFlag = true;
                    searchResultsList.Add(searchResults);
                }
            }

            return searchResultsList;
        }
    }
}
