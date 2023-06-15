using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public DateTime DataRezerwacji { get; set; }
        public DateTime DataPrzyjazdu { get; set; }
        public DateTime DataWyjazdu { get; set; }
        public virtual int? CustomerID { get; set; }
        public virtual int? RoomID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
    }
}
