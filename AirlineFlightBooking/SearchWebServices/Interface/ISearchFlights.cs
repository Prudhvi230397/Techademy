using SearchWebServices.Models;
using SearchWebServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebServices.Interface
{
    public interface ISearchFlights
    {
        List<SearchFlightResults> SearchFlights(SearchFlightDetails search);
    }
}
