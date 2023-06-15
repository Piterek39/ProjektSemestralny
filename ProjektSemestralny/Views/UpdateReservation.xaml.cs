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
    /// Interaction logic for UpdateReservation.xaml
    /// </summary>
    public partial class UpdateReservation : Page
    {
        public ObservableCollection<Customer> InitialCustomers { get; } = new ObservableCollection<Customer>();
        public ObservableCollection<Room> InitialRooms { get; } = new ObservableCollection<Room>();
        private Reservation _selectedReservation;
        public Reservation SelectedReservation
        {
            get { return _selectedReservation; }
            set
            {
                _selectedReservation = value;
                DtpcrDataRezerwacji.SelectedDate = _selectedReservation.DataRezerwacji;
                DtpcrDataPrzyjazdu.SelectedDate = _selectedReservation.DataPrzyjazdu;
                DtpcrDataWyjazdu.SelectedDate = _selectedReservation.DataWyjazdu;              
                CbxIDCustomer.Text = _selectedReservation.CustomerID.ToString();
                CbxIDRoom.Text = _selectedReservation.RoomID.ToString();

            }
        }
        public UpdateReservation()
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
        private void UpdateButtonReservation_Click(object sender, RoutedEventArgs e)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                if (!string.IsNullOrEmpty(DtpcrDataRezerwacji.Text) && !string.IsNullOrEmpty(DtpcrDataPrzyjazdu.Text) && !string.IsNullOrEmpty(DtpcrDataWyjazdu.Text) && int.TryParse(CbxIDCustomer.Text, out int idcustomer) && int.TryParse(CbxIDRoom.Text, out int idroom))
                {
                    _selectedReservation.DataRezerwacji = ((DatePicker)FindName("DtpcrDataRezerwacji")).SelectedDate ?? DateTime.MinValue;
                    _selectedReservation.DataPrzyjazdu = ((DatePicker)FindName("DtpcrDataPrzyjazdu")).SelectedDate ?? DateTime.MinValue;
                    _selectedReservation.DataWyjazdu = ((DatePicker)FindName("DtpcrDataWyjazdu")).SelectedDate ?? DateTime.MinValue;
                    _selectedReservation.CustomerID = int.TryParse(((ComboBox)FindName("CbxIDCustomer")).Text, out int customerid) ? customerid : 0;
                    _selectedReservation.RoomID = int.TryParse(((ComboBox)FindName("CbxIDRoom")).Text, out int roomid) ? roomid : 0;
                    context.Entry(_selectedReservation).State = EntityState.Modified;
                    context.SaveChanges();
                }
                Reservations reservationsPage = new Reservations();
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                navigationService.Navigate(reservationsPage);
            }
        }
    }
}
