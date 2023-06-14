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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        public AddCustomer()
        {
            InitializeComponent();
        }
        private void ButtonAddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            Customer customer = new Customer()
            {
                Imie = ((TextBox)FindName("TbxImie")).Text ?? "Empty",
                Nazwisko = ((TextBox)FindName("TbxNazwisko")).Text ?? "Empty",
                Adres = ((TextBox)FindName("TbxAdres")).Text ?? "Empty",
                NumerTelefonu = ((TextBox)FindName("TbxNumerTelefonu")).Text ?? "Empty",

            };

            context.Customers.Add(customer);
            context.SaveChanges();

            Page newPage = new Customers();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);

        }
    }
}
