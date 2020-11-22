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
    /// Логика взаимодействия для InsertInventoryItemsPage.xaml
    /// </summary>
    public partial class InsertInventoryItemsPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        public InsertInventoryItemsPage()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            InventoryItems newInvItem = new InventoryItems()
            {
                Amount = Convert.ToInt32(AmountTextBox.Text),
                Price = Convert.ToInt32(PriceTextBox.Text),
                InvType = InvTypeComboBox.Text
            };

            _db.InventoryItems.Add(newInvItem);
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
