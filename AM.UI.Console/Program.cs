// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;
using AM.Data;
/*
Plane p3 = new Plane()
{
    MyPlaneType = PlaneType.Boing,
    Capacity = 35,
    ManufactureDate = new DateTime(1999, 05, 25)
};

Passenger p = new Passenger()
{   Passport = "88888",
    BirthDate = new DateTime(1999, 02, 12),
    Email = "shadha@gmail.com",
    MyFullName = new FullName()
    {
        FirstName = "hhh",
        LastName = "hihihi"
    },
    TelNumber = "+216 5555555"
};

 
 Reservation R = new Reservation()
{  Vip = true,
    Price = 12.35f,
    Seat = "122 B",
    MyFlight = f,
    MyPassenger = p   };
Flight f = new Flight()
{   Comment = "test",
    Departure = "tunis",
    Destination = "ariana",
    EffectiveArrival = new DateTime(1999, 05, 25),
    EstimateDuration = 1,
    FlightDate = new DateTime(1999, 05, 24),
    MyPlane = p3 };


AMContext aMContext = new AMContext();

aMContext.Add(f);
aMContext.SaveChanges();
Console.WriteLine(f.ToString());
Console.WriteLine(f.MyPlane.ToString());*/

//Get data from the data base by finding it by the ID
AMContext aMContext = new AMContext();
Flight f = aMContext.Find<Flight>(1);
Console.WriteLine(f.ToString());
Console.WriteLine("******************");

Console.WriteLine(f.MyPlane.ToString());


