using AM.Core.Domain;
using AM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class PlaneService: Service<Plane>, IPlaneService
    {
        public PlaneService(IUnitOfWork  unitOfWork) : base(unitOfWork) { }

        public IList<Flight> GetFlights(int nbPlane)
        {
            return GetALL().OrderByDescending(p => p.ManufactureDate)
                .Take(nbPlane)
                .SelectMany(p => p.Flights)
                .OrderByDescending(f => f.FlightDate)
                .ToList();
        }

        public IList<Passenger> GetPassengers(Plane p) {
        
            return p.Flights.SelectMany(f=>f.Reservations)
                             .Select(r=>r.MyPassenger)
                             .Distinct()
                             .ToList();
        
        
        }
        
    }
}
