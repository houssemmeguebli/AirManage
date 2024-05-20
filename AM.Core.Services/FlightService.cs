using AM.Core.Domain;
using AM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class FlightService:Service<Flight> ,IFlightService
    //{    IRepository<Flight> repo;
    //    readonly IUnitOfWork unit;
    { 
        public IList<Flight> Flights { get; set; }
        public FlightService(IUnitOfWork unit):base(unit)
        {
            Flights = GetALL();
            //this.unit = unit;
            //repo=unit.GetRepository<Flight>();
        }
        //public void Add(Flight f)
        //{
        //    repo.Add(f);
        //    unit.Save();
        //        }
        //public void Delete(Flight f)
        //{
        //    repo.Delete(f);
        //    unit.Save();
        //}
        //public IList<Flight> GetAll()
        //{
        //   return repo.GetALL();       }

        public double GetDurationAverage(string dest)
        {
            return Flights.Where(f => f.Destination == dest)
                .Average(f => f.EstimateDuration);
        }

        //Implémenter la méthode GetFlightDates qui retourne la liste des dates de vols pour une destination donnée.  
        public IList<DateTime> GetFlightDates(string destination)
        {
            //IList < DateTime > liste = new List<DateTime>();
            //foreach (Flight flight in Flights)
            //{
            //    if (flight.Destination == destination)
            //        liste.Add(flight.FlightDate);     
            //}
            //return liste;

            //Linq 1 fonction avancee
            //return Flights.Where(f => f.Destination == destination)
            //    .Select(f => f.FlightDate)
            //    .ToList();

            //Linq 2 linq integre
            return (from f in Flights 
                   where f.Destination == destination
                   select f.FlightDate)
                   .ToList();
            
        }

        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
            IList<Flight> liste = new List<Flight>();
            
                switch (filterType)
                {
                    case "Destination":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                            liste.Add(flight);
                    }
                        break;
                    case "Departure":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Departure == filterValue)
                            liste.Add(flight);
                    }
                        break;
                    case "FlightDate":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.FlightDate.ToString() == filterValue)
                            liste.Add(flight);
                    }
                        break;
                    case "FlightId":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.FlightId.ToString() == filterValue)
                            liste.Add(flight);
                    }
                        break;
                    case "EffectiveArrival":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.EffectiveArrival.ToString() == filterValue)
                            liste.Add(flight);
                    }
                        break;
                    case "EstimateDuration":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.EstimateDuration.ToString() == filterValue)
                            liste.Add(flight);
                    }
                        break;
                   

                }
            
            return liste;
        }

        public IList<Passenger> GetThreeOlderTravellers(Flight flight)
        {
            //  return flight.Passengers.OrderByDescending(p => p.Age).Take(3).ToList();
            return null;

        }

        public int GetWeeklyFlightNumber(DateTime date_debut_semaine)
        {
            return Flights.Where(f => f.FlightDate >= date_debut_semaine 
            && f.FlightDate < date_debut_semaine.AddDays(7) )
                .Count();
        }

        public void ShowFlightDetails(Plane plane)
        {
            var vols = Flights.Where(f => f.MyPlane.PlaneId == plane.PlaneId);  
            foreach (var flight in vols)
            {
                Console.WriteLine("destination:"+flight.Destination
                    +";Date:"+flight.FlightDate);   
            }
        }

        public void ShowGroupedFlights()
        {
            var groups = Flights.GroupBy(f => f.Destination);
            foreach (var group in groups)
            {
                Console.WriteLine("group:" + group.Key);
                foreach (var flight in group)
                {
                    Console.WriteLine(flight.ToString());


                }

            }

            
                
        }

        public IList<Flight> SortFlights()
        {
            return Flights.OrderByDescending(f => f.EstimateDuration).ToList();
        }
    }


    
}
