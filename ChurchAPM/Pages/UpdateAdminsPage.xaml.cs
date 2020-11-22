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
    /// Логика взаимодействия для UpdateAdminsPage.xaml
    /// </summary>
    public partial class UpdateAdminsPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        int id;
        public UpdateAdminsPage(int admID)
        {
            InitializeComponent();
            id = admID;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Admins updAdmins = (from adm in _db.Admins
                                where adm.ID == id
                                select adm).Single();
            updAdmins.AdmLogin = LoginTextBox.Text;
            updAdmins.AdmPass = PassTextBox.Text;
            updAdmins.Email = EmailTextBox.Text;
            _db.SaveChanges();
            MenuWindow.admDataGrid.ItemsSource = _db.Admins.ToList();
            this.NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
