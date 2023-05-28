using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public DateTime DataRezerwacji { get; set; }
        public DateTime DataPrzyjazdu { get; set; }
        public DateTime DataWyjazdu { get; set; }
    }
}
