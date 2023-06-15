using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string NumerPokoju { get; set; }
        public string TypPokoju { get; set; }
        public string Dostepnosc { get; set; }
        public virtual int? HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
