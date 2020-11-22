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
    /// Логика взаимодействия для InsertEmployersPage.xaml
    /// </summary>
    public partial class InsertEmployersPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        public InsertEmployersPage()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Employers newEmp = new Employers()
            {
                FullName = FullNameTextBox.Text,
                Sex = SexComboBox.Text,
                Salary = Convert.ToInt32(SalaryTextBox.Text),
                Birthday = Convert.ToDateTime(BirthdayDatePicker.Text),
                EmpAddress = AddressTextBox.Text,
                EmpProfession = ProfessionComboBox.Text
            };

            _db.Employers.Add(newEmp);
            _db.SaveChanges();
            MenuWindow.empDataGrid.ItemsSource = _db.Employers.ToList();
            this.NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
