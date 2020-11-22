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
    /// Логика взаимодействия для InsertDonationsPage.xaml
    /// </summary>
    public partial class InsertDonationsPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        public InsertDonationsPage()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Donations newDonation = new Donations()
            {
                DonationSum = Convert.ToInt32(DonationSumTextBox.Text),
                DonationDate = Convert.ToDateTime(DonationDateDatePicker.Text),
                DonationType = DonationTypeComboBox.Text
            };

            _db.Donations.Add(newDonation);
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
