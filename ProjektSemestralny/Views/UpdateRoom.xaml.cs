using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for UpdateRoom.xaml
    /// </summary>
    public partial class UpdateRoom : Page
    {
        public ObservableCollection<Hotel> InitialHotels { get; } = new ObservableCollection<Hotel>();
        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
                TbxNumerPokoju.Text = _selectedRoom.NumerPokoju;
                CbxTypPokoju.Text = _selectedRoom.TypPokoju;
                CbxDostepnosc.Text = _selectedRoom.Dostepnosc;
                CbxIDHotel.Text = _selectedRoom.HotelID.ToString(); ;

            }
        }
        public UpdateRoom()
        {
            InitializeComponent();
            using HotelDbContext context = new HotelDbContext();
            var hotels = context.Hotels.ToList();
            foreach (var hotel in hotels)
            {
                InitialHotels.Add(hotel);
            }
            CbxIDHotel.ItemsSource = InitialHotels;
        }
        private void UpdateButtonRoom_Click(object sender, RoutedEventArgs e)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                if (!string.IsNullOrEmpty(TbxNumerPokoju.Text) && !string.IsNullOrEmpty(CbxTypPokoju.Text) && !string.IsNullOrEmpty(CbxDostepnosc.Text) && int.TryParse(CbxIDHotel.Text, out int idhotel))
                {
                    _selectedRoom.NumerPokoju = ((TextBox)FindName("TbxNumerPokoju")).Text ?? "Empty";
                    _selectedRoom.TypPokoju = ((ComboBox)FindName("CbxTypPokoju")).Text ?? "1-osobowy";
                    _selectedRoom.Dostepnosc = ((ComboBox)FindName("CbxDostepnosc")).Text ?? "Niedostepny";
                    _selectedRoom.HotelID = int.TryParse(((ComboBox)FindName("CbxIDHotel")).Text, out int hotelid) ? hotelid : 0;
                    context.Entry(_selectedRoom).State = EntityState.Modified;
                    context.SaveChanges();
                }
                Rooms roomsPage = new Rooms();
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                navigationService.Navigate(roomsPage);
            }
        }
    }
}
