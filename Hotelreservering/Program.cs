using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotelreservering;

namespace Hotelreservering
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
            HotelManager hotelManager = new HotelManager();
            Customer customer1 = new Customer("Joris", "joris.sparla@gmail.com");
            Customer customer2 = new Customer("Piet", "joris.sparla@gmail.com");
            Customer customer3 = new Customer("Kees", "joris.sparla@gmail.com");
            Customer customer4 = new Customer("Klaas", "joris.sparla@gmail.com");
            hotelManager.addReservation(11, DateTime.Now, customer1, 4);
            hotelManager.addReservation(1, DateTime.Now, customer1, 14);
            hotelManager.addReservation(2,DateTime.Now, customer2, 3);
            hotelManager.addReservation(3, DateTime.Now.AddDays(1), customer3, 2);
            hotelManager.addReservation(4, DateTime.Now.AddDays(1), customer4, 1);
            foreach(Reservation res in hotelManager.Reservations()) {
                Console.WriteLine("Reservering " + res.nr);
            }
            Console.WriteLine("____________________________");
            Reservation r = hotelManager.Reservations().First();
            hotelManager.RemoveReservation(r.nr);
            foreach (Reservation res in hotelManager.Reservations())
            {
                Console.WriteLine($"Reservering {res.nr} on {res.date}, room {res.roomnumber} for {res.Customer.Name}");
            }
            Console.Read();
        }
    }
}
