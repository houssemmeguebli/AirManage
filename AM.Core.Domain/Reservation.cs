using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Reservation
    {
        public bool Vip { get; set; }
        public string Seat { get; set; }
        public float Price  { get; set; }
        //foreign key 

        public int FlightId { get; set; }
        public string PassengerId { get; set; }


        public virtual Flight MyFlight { get; set; }
       public virtual Passenger MyPassenger { get; set; }

    }
}
