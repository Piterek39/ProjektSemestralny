﻿using Microsoft.EntityFrameworkCore;
using ProjektSemestralny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Classes
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=master;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Hotel");
                entityTypeBuilder.HasKey(h => h.HotelID);
                entityTypeBuilder.Property(h => h.Nazwa);
                entityTypeBuilder.Property(h => h.Adres);
                entityTypeBuilder.Property(h => h.LiczbaPokoi);               
            });

            modelBuilder.Entity<Room>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Room");
                entityTypeBuilder.HasKey(r => r.RoomID);
                entityTypeBuilder.Property(r => r.HotelID);
                entityTypeBuilder.Property(r => r.NumerPokoju);
                entityTypeBuilder.Property(r => r.TypPokoju);
                entityTypeBuilder.Property(r => r.Dostepnosc);
            });

            modelBuilder.Entity<Customer>(entityTypeBuilder =>
                {
                    entityTypeBuilder.ToTable("Customer");
                    entityTypeBuilder.HasKey(c => c.CustomerID);
                    entityTypeBuilder.Property(c => c.Imie);
                    entityTypeBuilder.Property(c => c.Nazwisko);
                    entityTypeBuilder.Property(c => c.Adres);
                    entityTypeBuilder.Property(c => c.NumerTelefonu);
                });
            modelBuilder.Entity<Reservation>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Reservation");
                entityTypeBuilder.HasKey(v => v.ReservationID);
                entityTypeBuilder.Property(v => v.CustomerID);
                entityTypeBuilder.Property(v => v.RoomID);
                entityTypeBuilder.Property(v => v.DataRezerwacji);
                entityTypeBuilder.Property(v => v.DataPrzyjazdu);
                entityTypeBuilder.Property(v => v.DataWyjazdu);
            });


        }
    }
}
