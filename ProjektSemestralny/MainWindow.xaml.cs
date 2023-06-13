using ProjektSemestralny.Classes;
using ProjektSemestralny.Models;
using ProjektSemestralny.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
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

namespace ProjektSemestralny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var page = new HomeView();
            mainFrame.Content = page;
        }
        private void HotelButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new Hotels();
            mainFrame.Content = page;
        }
        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new Customers();
            mainFrame.Content = page;
        }
        private void RoomButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new Rooms();
            mainFrame.Content = page;
        }
        private void ReservationButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new Reservations();
            mainFrame.Content = page;
        }

    }
}
