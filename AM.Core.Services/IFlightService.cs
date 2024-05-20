using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public interface IFlightService:IService<Flight>
    {
        //Implémenter la méthode GetFlightDates qui retourne la liste des dates de vols pour une destination donnée.  
        IList<DateTime> GetFlightDates(string destination);
        IList<Flight> GetFlights(string filterType, string filterValue);

        void ShowFlightDetails(Plane plane);
        int GetWeeklyFlightNumber(DateTime date_debut_semaine);

        double GetDurationAverage(string dest);

        IList<Flight> SortFlights();
        IList<Passenger> GetThreeOlderTravellers(Flight flight);

        void ShowGroupedFlights();



    }








}
