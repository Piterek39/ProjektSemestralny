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
    /// Interaction logic for UpdateHotel.xaml
    /// </summary>
    public partial class UpdateHotel : Page
    {
        private Hotel _selectedHotel;
        public Hotel SelectedHotel
        {
            get { return _selectedHotel; }
            set
            {
                _selectedHotel = value;
                TbxNazwa.Text = _selectedHotel.Nazwa;
                TbxAdres.Text = _selectedHotel.Adres;
                TbxLiczbaPokoi.Text = _selectedHotel.LiczbaPokoi.ToString();
            }
        }
        public UpdateHotel()
        {
            InitializeComponent();       
        }
        private void UpdateButtonHotel_Click(object sender, RoutedEventArgs e)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                if (!string.IsNullOrEmpty(TbxNazwa.Text) && !string.IsNullOrEmpty(TbxAdres.Text) && int.TryParse(TbxLiczbaPokoi.Text, out int liczbaPokoi))
                {
                    _selectedHotel.Nazwa = ((TextBox)FindName("TbxNazwa")).Text;
                    _selectedHotel.Adres = ((TextBox)FindName("TbxAdres")).Text;                
                    _selectedHotel.LiczbaPokoi = liczbaPokoi = int.TryParse(((TextBox)FindName("TbxLiczbaPokoi")).Text, out int liczbapokoi) ? liczbapokoi : 0;
                    context.Entry(_selectedHotel).State = EntityState.Modified;
                    context.SaveChanges();                                    
                }
                Hotels hotelsPage = new Hotels();
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                navigationService.Navigate(hotelsPage);
            }
        }
    }
}
