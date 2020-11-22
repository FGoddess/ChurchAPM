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
    /// Логика взаимодействия для InsertFixedAssets.xaml
    /// </summary>
    public partial class InsertFixedAssets : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        public InsertFixedAssets()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            FixedAssets newFA = new FixedAssets()
            {
                InitialCost = Convert.ToInt32(InitialCostTextBox.Text),
                DateOfEntry = Convert.ToDateTime(DateofEntryDatePicker.Text),
                ExpirationDate = Convert.ToDateTime(ExpirationDateDatePicker.Text),
                GroupName = GroupNameComboBox.Text,
                AnnualDepreciationRate = Convert.ToInt32(AnnualDepreciationRateTextBox.Text)
            };

            _db.FixedAssets.Add(newFA);
            _db.SaveChanges();
            MenuWindow.fADataGrid.ItemsSource = _db.FixedAssets.ToList();
            this.NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
