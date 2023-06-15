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
using Microsoft.EntityFrameworkCore;
using ProjektSemestralny.Classes;
using ProjektSemestralny.Models;
using ProjektSemestralny.Views;

namespace ProjektSemestralny.Views
{
    /// <summary>
    /// Interaction logic for UpdateCustomer.xaml
    /// </summary>
    public partial class UpdateCustomer : Page
    {
        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                TbxImie.Text = _selectedCustomer.Imie;
                TbxNazwisko.Text = _selectedCustomer.Nazwisko;
                TbxAdres.Text = _selectedCustomer.Adres;
                TbxNumerTelefonu.Text = _selectedCustomer.NumerTelefonu;
            }
        }
        public UpdateCustomer()
        {
            InitializeComponent();
        }
        private void UpdateButtonCustomer_Click(object sender, RoutedEventArgs e)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                if (!string.IsNullOrEmpty(TbxImie.Text) && !string.IsNullOrEmpty(TbxNazwisko.Text) && !string.IsNullOrEmpty(TbxAdres.Text) && !string.IsNullOrEmpty(TbxNumerTelefonu.Text))
                {                   
                    _selectedCustomer.Imie = ((TextBox)FindName("TbxImie")).Text;
                    _selectedCustomer.Nazwisko = ((TextBox)FindName("TbxNazwisko")).Text;
                    _selectedCustomer.Adres = ((TextBox)FindName("TbxAdres")).Text;
                    _selectedCustomer.NumerTelefonu = ((TextBox)FindName("TbxNumerTelefonu")).Text;
                    context.Entry(_selectedCustomer).State = EntityState.Modified;
                    context.SaveChanges();
                }
                Customers customersPage = new Customers();
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                navigationService.Navigate(customersPage);
            }
        }
    }
}
