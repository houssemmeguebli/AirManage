using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set;}
        public DateTime EffectiveArrival { get; set; }
        public int EstimateDuration { get; set; }
        //------------------------------
        [ForeignKey("PlaneId")]
        public virtual Plane MyPlane { get; set; }

        //ou bien [ForeignKey("MyPlane")]
        //[AllowNull]
        public int? PlaneId { get; set; }
        //------------------------------

        //  public IList <Passenger> Passengers { get; set; }

        public virtual IList<Reservation> Reservations { get; set; }

        public string Comment { get; set; }
        public override string ToString()
        {
            return "Destination:" + Destination
                + "Departure:" + Departure
                + "FlightDate:" + FlightDate
                + "FlightId:" + FlightId
                + "EffectiveArrival:" + EffectiveArrival
                + "EstimateDuration:" + EstimateDuration;
          //      + "MyPlane:" + MyPlane.ToString();
        }
    }
}
