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
    /// Логика взаимодействия для UpdateDonationsPage.xaml
    /// </summary>
    public partial class UpdateDonationsPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        int id;
        public UpdateDonationsPage(int donID)
        {
            InitializeComponent();
            id = donID;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Donations updDonation = (from d in _db.Donations
                                     where d.ID == id
                                     select d).Single();
            updDonation.DonationSum = Convert.ToInt32(DonationSumTextBox.Text);
            updDonation.DonationDate = Convert.ToDateTime(DonationDateDatePicker.Text);
            updDonation.DonationType = DonationTypeComboBox.Text;
            _db.SaveChanges();
            MenuWindow.donDataGrid.ItemsSource = _db.Donations.ToList();
            this.NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
