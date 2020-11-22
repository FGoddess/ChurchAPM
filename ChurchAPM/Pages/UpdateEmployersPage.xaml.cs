using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ChurchAPM.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpdateEmployersPage.xaml
    /// </summary>
    public partial class UpdateEmployersPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        int id;
        public UpdateEmployersPage(int empID)
        {
            InitializeComponent();
            id = empID;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Employers updEmployers = (from emp in _db.Employers
                                      where emp.ID == id
                                      select emp).Single();
            updEmployers.FullName = FullNameTextBox.Text;
            updEmployers.Sex = SexComboBox.Text;
            updEmployers.Salary = Convert.ToInt32(SalaryTextBox.Text);
            updEmployers.Birthday = Convert.ToDateTime(BirthdayDatePicker.Text);
            updEmployers.EmpAddress = AddressTextBox.Text;
            updEmployers.EmpProfession = ProfessionComboBox.Text;
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
