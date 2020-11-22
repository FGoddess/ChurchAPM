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
    /// Логика взаимодействия для UpdateFixedAssets.xaml
    /// </summary>
    public partial class UpdateFixedAssets : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        int id;
        public UpdateFixedAssets(int faID)
        {
            InitializeComponent();
            id = faID;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            FixedAssets updFA = (from fa in _db.FixedAssets
                                 where fa.ID == id
                                 select fa).Single();
            updFA.InitialCost = Convert.ToInt32(InitialCostTextBox.Text);
            updFA.DateOfEntry = Convert.ToDateTime(DateofEntryDatePicker.Text);
            updFA.ExpirationDate = Convert.ToDateTime(ExpirationDateDatePicker.Text);
            updFA.GroupName = GroupNameComboBox.Text;
            updFA.AnnualDepreciationRate = Convert.ToInt32(AnnualDepreciationRateTextBox.Text);
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
