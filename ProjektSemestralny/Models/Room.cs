using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public string NumerPokoju { get; set; }
        public string TypPokoju { get; set; }
        public bool Dostępność { get; set; }
    }
}
