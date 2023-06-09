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
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        public Customers()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            var customers = await context.Customers.ToListAsync();
            Customer.ItemsSource = customers;
        }
        private async void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            Customer selectedCustomer = Customer.SelectedItem as Customer;
            if (context.Entry(selectedCustomer).State == EntityState.Detached)
            {
                context.Attach(selectedCustomer);
            }
            context.Customers.Remove(selectedCustomer);
            context.SaveChanges();
            var customers = await context.Customers.ToListAsync();
            Customer.ItemsSource = customers;
        }
        private void ButtonUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer selectedCustomer = Customer.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                UpdateCustomer updateCustomerPage = new UpdateCustomer();
                updateCustomerPage.SelectedCustomer = selectedCustomer;
                NavigationService?.Navigate(updateCustomerPage);
            }
        }
        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer newPage = new AddCustomer();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);
        }
    }
}
