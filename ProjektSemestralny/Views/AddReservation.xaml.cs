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
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Page
    {
        public ObservableCollection<Customer> InitialCustomers { get; } = new ObservableCollection<Customer>();
        public ObservableCollection<Room> InitialRooms { get; } = new ObservableCollection<Room>();
        public AddReservation()
        {
            InitializeComponent();
            using HotelDbContext context = new HotelDbContext();
            var customers = context.Customers.ToList();
            foreach (var customer in customers)
            {
                InitialCustomers.Add(customer);
            }
            var rooms = context.Rooms.ToList();
            foreach (var room in rooms)
            {
                InitialRooms.Add(room);
            }
            CbxIDCustomer.ItemsSource = InitialCustomers;
            CbxIDRoom.ItemsSource = InitialRooms;
        }
        private void ButtonAddNewReservation_Click(object sender, RoutedEventArgs e)
        {
            using HotelDbContext context = new HotelDbContext();
            Reservation reservation = new Reservation()
            {
                DataRezerwacji = ((DatePicker)FindName("DtpcrDataRezerwacji")).SelectedDate ?? DateTime.MinValue,
                DataPrzyjazdu = ((DatePicker)FindName("DtpcrDataPrzyjazdu")).SelectedDate ?? DateTime.MinValue,
                DataWyjazdu = ((DatePicker)FindName("DtpcrDataWyjazdu")).SelectedDate ?? DateTime.MinValue,
                CustomerID = int.TryParse(((ComboBox)FindName("CbxIDCustomer")).Text, out int customerid) ? customerid : 0,
                RoomID = int.TryParse(((ComboBox)FindName("CbxIDRoom")).Text, out int roomid) ? roomid : 0
            };

            context.Reservations.Add(reservation);
            context.SaveChanges();

            Page newPage = new Reservations();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(newPage);

        }
    }
}
