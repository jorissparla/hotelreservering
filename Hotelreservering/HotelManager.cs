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
        public void addReservation(int roomnumber, string date)
        {
            Reservation res = new Reservation(nr:getReservationNumber(),date:DateTime.Today,roomnumber:roomnumber);
            reservations.Add(res);
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
        public int person { get => _people; set => _people = value; }

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
        public string nr { get => _nr; set => _nr = value; }
        public Reservation(string nr, DateTime date, int roomnumber)
        {
            _date = date;
            _roomnumber = roomnumber;
            _nr = nr;
        }
    }

}
