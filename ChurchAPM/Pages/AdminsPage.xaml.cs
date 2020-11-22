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
    /// Логика взаимодействия для AdminsPage.xaml
    /// </summary>
    public partial class AdminsPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        InsertAdminsPage insAdmPage = new InsertAdminsPage();
        EmptyPage emptyPage = new EmptyPage();
        public AdminsPage()
        {
            InitializeComponent();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            AdminsMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(insAdmPage);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int admID = (adminsDataGrid.SelectedItem as Admins).ID;
            UpdateAdminsPage updateAdmPage = new UpdateAdminsPage(admID);
            AdminsMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(updateAdmPage);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (adminsDataGrid.SelectedItem == null)
                return;

            int adminID = ((Admins)adminsDataGrid.SelectedItem).ID;

            var removeAdmin = _db.Admins.Where(adm => adm.ID == adminID).Single();

            _db.Admins.Remove(removeAdmin);
            _db.SaveChanges();
            adminsDataGrid.ItemsSource = _db.Admins.ToList();
        }

        private void DefaultButton_Click(object sender, RoutedEventArgs e)
        {
            adminsDataGrid.ItemsSource = _db.Admins.ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < adminsDataGrid.Items.Count; i++)
            {
                var filtered = _db.Admins.Where(ev => ev.AdmLogin.StartsWith(SearchTextBox.Text));

                adminsDataGrid.ItemsSource = filtered.ToList();
            }
        }
    }
}
