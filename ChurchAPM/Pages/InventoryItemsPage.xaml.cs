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
    /// Логика взаимодействия для InventoryItemsPage.xaml
    /// </summary>
    public partial class InventoryItemsPage : Page
    {
        EmptyPage emptyPage = new EmptyPage();
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        public InventoryItemsPage()
        {
            InitializeComponent();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertInventoryItemsPage invItemsInsPage = new InsertInventoryItemsPage();
            InvItemsMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(invItemsInsPage);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (inventoryItemsDataGrid.SelectedItem == null)
                return;

            int invItemsID = ((InventoryItems)inventoryItemsDataGrid.SelectedItem).ID;

            var removeInvItem = _db.InventoryItems.Where(ii => ii.ID == invItemsID).Single();

            _db.InventoryItems.Remove(removeInvItem);
            _db.SaveChanges();
            inventoryItemsDataGrid.ItemsSource = _db.InventoryItems.ToList();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int invItemsID = (inventoryItemsDataGrid.SelectedItem as InventoryItems).ID;
            UpdateInventoryItemsPage updateInvItemsPage = new UpdateInventoryItemsPage(invItemsID);
            InvItemsMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(updateInvItemsPage);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < inventoryItemsDataGrid.Items.Count; i++)
            {
                var filtered = _db.InventoryItems.Where(ev => ev.InvType.StartsWith(SearchTextBox.Text));

                inventoryItemsDataGrid.ItemsSource = filtered.ToList();
            }
        }

        private void DefaultButton_Click(object sender, RoutedEventArgs e)
        {
            inventoryItemsDataGrid.ItemsSource = _db.ChEvents.ToList();
        }
    }
}
