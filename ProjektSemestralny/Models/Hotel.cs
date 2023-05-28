﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public string Nazwa { get; set; }
        public string Adres { get; set; }
        public int LiczbaPokoi { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}