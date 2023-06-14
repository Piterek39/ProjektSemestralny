using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ProjektSemestralny.Classes;
using ProjektSemestralny.Models;
using ProjektSemestralny.Views;

namespace ProjektSemestralny.Views
{
    /// <summary>
    /// Interaction logic for Hotel.xaml
    /// </summary>
    public partial class Hotels : Page
    {
        
        public Hotels()
        {
            InitializeComponent();       
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            var hotels = await context.Hotels.ToListAsync();
            Hotel.ItemsSource = hotels;
        }

        private async void ButtonDeleteHotel_Click(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            Hotel selectedHotel = Hotel.SelectedItem as Hotel;
            if (context.Entry(selectedHotel).State == EntityState.Detached)
            {
                context.Attach(selectedHotel);
            }
            context.Hotels.Remove(selectedHotel);
            context.SaveChanges();
            var hotels = await context.Hotels.ToListAsync();
            Hotel.ItemsSource = hotels;

        }
        private void AddHotelButton_Click(object sender, RoutedEventArgs e)
        {
            AddHotel newPage = new AddHotel();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }
    }
}
