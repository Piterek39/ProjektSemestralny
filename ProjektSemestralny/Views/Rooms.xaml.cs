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
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Page
    {
        public Rooms()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            var rooms = await context.Rooms.ToListAsync();
            Room.ItemsSource = rooms;
        }
        private async void ButtonDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            Room selectedRoom = Room.SelectedItem as Room;
            if (context.Entry(selectedRoom).State == EntityState.Detached)
            {
                context.Attach(selectedRoom);
            }
            context.Rooms.Remove(selectedRoom);
            context.SaveChanges();
            var rooms = await context.Rooms.ToListAsync();
            Room.ItemsSource = rooms;
        }
        private void ButtonUpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            Room selectedRoom = Room.SelectedItem as Room;
            if (selectedRoom != null)
            {
                UpdateRoom updateRoomPage = new UpdateRoom();
                updateRoomPage.SelectedRoom = selectedRoom;
                NavigationService?.Navigate(updateRoomPage);
            }
        }
        private void AddRoomButton_Click(object sender, RoutedEventArgs e)
        {
            AddRoom newPage = new AddRoom();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }
    }
}
