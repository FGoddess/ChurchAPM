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
    /// Логика взаимодействия для UpdateInventoryItemsPage.xaml
    /// </summary>
    public partial class UpdateInventoryItemsPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        int id;
        public UpdateInventoryItemsPage(int invItID)
        {
            InitializeComponent();
            id = invItID;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            InventoryItems updInvItems = (from ii in _db.InventoryItems
                                          where ii.ID == id
                                          select ii).Single();
            updInvItems.Amount = Convert.ToInt32(AmountTextBox.Text);
            updInvItems.Price = Convert.ToInt32(PriceTextBox.Text);
            updInvItems.InvType = InvTypeComboBox.Text;
            _db.SaveChanges();
            MenuWindow.iIDataGrid.ItemsSource = _db.InventoryItems.ToList();
            this.NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
