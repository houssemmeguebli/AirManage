using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    //public enum PlaneType
    //{
    //    Boing,
    //    Airbus

    //}

    public class Plane
    {
        [Range(0, int.MaxValue, ErrorMessage = "Capacite doit etre un entier positif!")]
        public int Capacity { get; set; }

        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public  PlaneType MyPlaneType { get; set; }
        public virtual IList <Flight> Flights { get; set; }

        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            MyPlaneType = pt;
            Capacity = capacity;
            ManufactureDate = date;
        }

        public Plane() { }
        public override string ToString()
        {
            return "Capacity:" + Capacity
            + "ManufactureDate:" + ManufactureDate
                + "PlaneId:" + PlaneId
                + "PlaneType:"+ MyPlaneType;
        }

    }
}
