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
    /// Логика взаимодействия для InsertAdminsPage.xaml
    /// </summary>
    public partial class InsertAdminsPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        public InsertAdminsPage()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Admins newAdm = new Admins()
            {
                AdmLogin = LoginTextBox.Text,
                AdmPass = PassTextBox.Text,
                Email = EmailTextBox.Text
            };

            _db.Admins.Add(newAdm);
            _db.SaveChanges();
            MenuWindow.admDataGrid.ItemsSource = _db.Admins.ToList();
            LoginTextBox.Text = String.Empty;
            PassTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
            this.NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            LoginTextBox.Text = String.Empty;
            PassTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
            this.NavigationService.GoBack();
        }
    }
}
