using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        //[StringLength(25, MinimumLength = 3, ErrorMessage = "Le prénom doit avoir une longueur minimale de 3 caractères et maximale de 25 caractères.")]
        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        public FullName MyFullName { get; set; }

        [Phone(ErrorMessage = "Invalid Phone!")]
        public string TelNumber { get; set; }
        [EmailAddress(ErrorMessage ="Invalid Email!")]
        public string Email { get; set;}
        [Key]
        [StringLength(7, ErrorMessage = "La clé primaire doit être composée de 7 caractères.")]
        public string Passport { get; set;}
        [Display(Name ="Date Of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date!")]
        public DateTime BirthDate { get; set;}


        public virtual IList<Reservation> Reservations { get; set; }

        //public IList <Flight> Flights { get; set; }
        public int Age { get {
                int age;
               
                age= DateTime.Now.Year - BirthDate.Year;
                if (DateTime.Now < BirthDate.AddYears(Age))
                {
                    age--;
                }
                return age;
            } }



        public override string ToString()
        {
            return "FirstName:" + MyFullName.FirstName
                + "LastName:" + MyFullName.LastName
                + "TelNumber:" + TelNumber
                + "Email:" + Email
                + "Passport:" + Passport
                + "BirthDate:" + BirthDate;
        }

        public bool CheckProfile(string FirstName, string LastName) 
        {
      
            return this.MyFullName.FirstName == FirstName 
                && this.MyFullName.LastName == LastName;

        }

        //public bool CheckProfile(string FirstName, string LastName, string Email)
        //{
            
        //    return this.FirstName == FirstName 
        //        && this.LastName == LastName 
        //        && this.Email == Email;

        //}

        public bool CheckProfile(string FirstName, string LastName, string Email = null)
        {
            if (Email != null)
            {
                return this.MyFullName.FirstName == FirstName
                && this.MyFullName.LastName == LastName
                && this.Email == Email;
            } else
            {
                return this.MyFullName.FirstName == FirstName
                && this.MyFullName.LastName == LastName;
                
            }

        }

        public virtual string GetPassengerType()
        {
            return "I am a passenger";
        }

        //public string GetPassengerType2()
        //{
        //    if (this.GetType() == typeof(Passenger))
        //        return "I am a passenger";
        //    else if (this.GetType() == typeof(Traveller))
        //        return "I am a traveller";
        //    else
        //        return "i am a staff";


        //}
    }
}
