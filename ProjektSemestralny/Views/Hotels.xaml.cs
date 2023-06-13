﻿using System;
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
    /// Interaction logic for Hotel.xaml
    /// </summary>
    public partial class Hotels : Page
    {
        public Hotels()
        {
            InitializeComponent();
        }
        private async void ButtonDeleteHotel_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddHotelButton_Click(object sender, RoutedEventArgs e)
        {
            AddHotel newPage = new AddHotel();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }
    }
}
