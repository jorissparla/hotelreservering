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
            hotelManager.addReservation(1, "20181219");
            hotelManager.addReservation(2, "20181219");
            hotelManager.addReservation(3, "20181219");
            hotelManager.addReservation(4, "20181219");
            foreach(Reservation res in hotelManager.Reservations()) {
                Console.WriteLine("Reservering " + res.nr);
            }
            Console.WriteLine("____________________________");
            Reservation r = hotelManager.Reservations().First();
            hotelManager.RemoveReservation(r.nr);
            foreach (Reservation res in hotelManager.Reservations())
            {
                Console.WriteLine("Reservering " + res.nr);
            }
            Console.Read();
        }
    }
}
