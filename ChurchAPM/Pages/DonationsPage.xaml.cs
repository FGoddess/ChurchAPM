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

namespace ChurchAPM.Pages
{
    /// <summary>
    /// Логика взаимодействия для DonationsPage.xaml
    /// </summary>
    public partial class DonationsPage : Page
    {
        EmptyPage emptyPage = new EmptyPage();
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();

        public DonationsPage()
        {
            InitializeComponent();
        }


        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertDonationsPage donInsPage = new InsertDonationsPage();
            DonationsMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(donInsPage);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (donationsDataGrid.SelectedItem == null)
                return;

            int donationsID = ((Donations)donationsDataGrid.SelectedItem).ID;

            var removeDonation = _db.Donations.Where(d => d.ID == donationsID).Single();

            _db.Donations.Remove(removeDonation);
            _db.SaveChanges();
            donationsDataGrid.ItemsSource = _db.Donations.ToList();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int donationID = (donationsDataGrid.SelectedItem as Donations).ID;
            UpdateDonationsPage updateDonationsPage = new UpdateDonationsPage(donationID);
            DonationsMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(updateDonationsPage);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < donationsDataGrid.Items.Count; i++)
            {
                var filtered = _db.Donations.Where(d => d.DonationType.StartsWith(SearchTextBox.Text));

                donationsDataGrid.ItemsSource = filtered.ToList();
            }
        }

        private void DefaultButton_Click(object sender, RoutedEventArgs e)
        {
            donationsDataGrid.ItemsSource = _db.Donations.ToList();
        }
    }
}
