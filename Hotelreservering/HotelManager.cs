using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelreservering
{
    class HotelManager
    {
        private List<Room> rooms = new List<Room>();
        private List<Reservation> reservations= new List<Reservation>();

        public HotelManager()
        {
            rooms.Add(new Room(1));
            rooms.Add(new Room(2));
            rooms.Add(new Room(3));
            rooms.Add(new Room(4));
            rooms.Add(new Room(5));
            rooms.Add(new Room(6));
            
        }
        public Random rnd = new Random();
        public string getReservationNumber()
        {
            return rnd.Next(111111,999999).ToString();
        }
        public void addReservation(int roomnumber, DateTime date, Customer customer, int nrpersons)
        {

            try
            {
                List <Room> selectedrooms = rooms.Where(r => r.number == roomnumber).ToList() ;

                if (selectedrooms.Count ==0 )
                {
                    throw new Exception($"Room {roomnumber} does not exist");
                }

                Room room = selectedrooms.First();

                if (room.persons <nrpersons)
                {
                    throw new Exception("Number of persons exceeds Room Capacity");
                }

                Reservation res = new Reservation(nr: getReservationNumber(), date: date, room:room, customer: customer);
                reservations.Add(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString() );
                Console.WriteLine($"Unable to create Reservation for room {roomnumber}");
            }
           
            ;
            
        }

        public List<Room> AvailableRooms (string date)
        {
            List<Room> availableRooms = new List<Room>();
            foreach(Room r in rooms)
            {
                availableRooms.Add(r);
            }
            foreach(Reservation r in reservations.Where(s=> s.date.ToString() ==date))
            {
                //availableRooms.Remove(r.);
            }

            return availableRooms;
        }
        public List<Reservation> Reservations()
        {
            return reservations;
        }
        public void RemoveReservation(string nr)
        {
            Reservation r = reservations.Where( s => s.nr == nr).First();
            reservations.Remove(r);
        }

}
    class Room
    {
        int _number;
        int _people = 4;
        public int number { get => _number; set => _number = value; }
        public int persons { get => _people; set => _people = value; }

        public Room(int number)
        {
            _number = number;
        }
        public Room(int number, int nrpersons)
        {
            _number = number;
            _people = nrpersons;
        }
    }

    class Reservation
    {
        DateTime _date;
        int _roomnumber;
        string _nr;
        public DateTime date { get => _date; set => _date = value; }
        public int roomnumber { get => _roomnumber; set => _roomnumber = value; }
        private Room _room;
        public string nr { get => _nr; set => _nr = value; }
        internal Customer Customer { get => customer; set => customer = value; }
        internal Room Room { get => _room; set => _room = value; }

        private Customer customer;
        public Reservation(string nr, DateTime date, Room room, Customer customer)
        {
            _date = date;
            Room = room;
            _roomnumber = roomnumber;
            _nr = nr;
            Customer = customer;
        }
    }


    class Customer
    {
        private string _name;
        private string _email;

        public Customer(string name, string email)
        {
            Email = email;
            Name = name;
        }

        public string Email { get => _email; set => _email = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
