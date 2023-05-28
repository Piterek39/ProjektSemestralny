using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string DaneKontaktowe { get; set; }
    }
}
