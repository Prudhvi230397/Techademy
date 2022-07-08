using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchWebServices.Interface;
using SearchWebServices.Models;
using SearchWebServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        ISearchFlights searchFlight;
        public SearchController(ISearchFlights _searchFlight)
        {
            searchFlight = _searchFlight;
        }

        [HttpPost]
        public IEnumerable<SearchFlightResults> FindFlight(SearchFlightDetails flightDetails)
        {
            try
            {
                return searchFlight.SearchFlights(flightDetails);
            }
            catch(Exception ex)
            {
                throw  ex;
            }
        }
    }
}
