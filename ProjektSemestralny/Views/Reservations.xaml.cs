﻿using Microsoft.EntityFrameworkCore;
using ProjektSemestralny.Classes;
using ProjektSemestralny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektSemestralny.Views
{
    /// <summary>
    /// Interaction logic for Reservations.xaml
    /// </summary>
    public partial class Reservations : Page
    {
        public Reservations()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            var reservations = await context.Reservations.ToListAsync();
            Reservation.ItemsSource = reservations;
        }
        private async void ButtonDeleteReservation_Click(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            Reservation selectedReservation = Reservation.SelectedItem as Reservation;
            if (context.Entry(selectedReservation).State == EntityState.Detached)
            {
                context.Attach(selectedReservation);
            }
            context.Reservations.Remove(selectedReservation);
            context.SaveChanges();
            var reservations = await context.Reservations.ToListAsync();
            Reservation.ItemsSource = reservations;
        }
        private void ButtonUpdateReservation_Click(object sender, RoutedEventArgs e)
        {
            Reservation selectedReservation = Reservation.SelectedItem as Reservation;
            if (selectedReservation != null)
            {
                UpdateReservation updateReservationPage = new UpdateReservation();
                updateReservationPage.SelectedReservation = selectedReservation;
                NavigationService?.Navigate(updateReservationPage);
            }
        }
        private void AddReservationButton_Click(object sender, RoutedEventArgs e)
        {
            AddReservation newPage = new AddReservation();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }
    }
}
