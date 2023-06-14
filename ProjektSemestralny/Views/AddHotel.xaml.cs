using ProjektSemestralny.Models;
using ProjektSemestralny.Classes;
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
using System.Xml.Linq;

namespace ProjektSemestralny.Views
{
    /// <summary>
    /// Interaction logic for AddHotel.xaml
    /// </summary>
    public partial class AddHotel : Page
    {
       
        public AddHotel()
        {
            InitializeComponent();
        }
        private void ButtonAddNewHotel_Click(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();      
                Hotel hotel=new Hotel()
                {
                     Nazwa = ((TextBox)FindName("TbxNazwa")).Text ?? "Empty",
                    Adres = ((TextBox)FindName("TbxAdres")).Text ?? "Empty",
                     LiczbaPokoi = int.TryParse(((TextBox)FindName("TbxLiczbaPokoi")).Text, out int liczbapokoi) ? liczbapokoi : 0,
                };
               
                context.Hotels.Add(hotel);
                context.SaveChanges();
          
            Page newPage = new Hotels();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);

        }
    }
}
