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
    /// Логика взаимодействия для EmployersPage.xaml
    /// </summary>
    public partial class EmployersPage : Page
    {
        EmptyPage emptyPage = new EmptyPage();
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();

        public EmployersPage()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int empID = (employersDataGrid.SelectedItem as Employers).ID;
            UpdateEmployersPage updateEmployersPage = new UpdateEmployersPage(empID);
            EmployersMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(updateEmployersPage);
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertEmployersPage empsInsPage = new InsertEmployersPage();
            EmployersMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(empsInsPage);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (employersDataGrid.SelectedItem == null)
                return;

            int empID = ((Employers)employersDataGrid.SelectedItem).ID;

            var removeEmployers = _db.Employers.Where(emp => emp.ID == empID).Single();

            _db.Employers.Remove(removeEmployers);
            _db.SaveChanges();
            employersDataGrid.ItemsSource = _db.Employers.ToList();
        }

        private void DefaultButton_Click(object sender, RoutedEventArgs e)
        {
            employersDataGrid.ItemsSource = _db.Employers.ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < employersDataGrid.Items.Count; i++)
            {
                var filtered = _db.Employers.Where(emp => emp.FullName.StartsWith(SearchTextBox.Text));

                employersDataGrid.ItemsSource = filtered.ToList();
            }
        }
    }
}
