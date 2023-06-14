using ProjektSemestralny.Classes;
using ProjektSemestralny.Models;
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

namespace ProjektSemestralny.Views
{
    /// <summary>
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Page
    {
        public ObservableCollection<Hotel> InitialHotels { get; } = new ObservableCollection<Hotel>();
        public AddRoom()
        {
            InitializeComponent();
            using HotelDbContext context = new HotelDbContext();
            var hotels=context.Hotels.ToList();
            foreach(var hotel in hotels)
            {
                InitialHotels.Add(hotel);
            }
            CbxIDHotel.ItemsSource = InitialHotels;
        }
        private void ButtonAddNewRoom_Click(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            Room room = new Room()
            {
                NumerPokoju = ((TextBox)FindName("TbxNumerPokoju")).Text ?? "Empty",
                TypPokoju = ((ComboBox)FindName("CbxTypPokoju")).Text ?? "1-osobowy",
                //Dostepnosc = ((ComboBox)FindName("CbxDostepnosc")).SelectedValue.ToString().Contains("Niedostepny") ? "Niedostepny": "Dostepny",
                Dostepnosc = ((ComboBox)FindName("CbxDostepnosc")).Text ?? "Niedostepny",
                HotelID = int.TryParse(((ComboBox)FindName("CbxIDHotel")).Text, out int hotelid) ? hotelid : 0
            };

            context.Rooms.Add(room);
            context.SaveChanges();

            Page newPage = new Rooms();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);

        }
    }
}
