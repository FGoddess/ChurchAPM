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
    /// Логика взаимодействия для FixedAssetsPage.xaml
    /// </summary>
    public partial class FixedAssetsPage : Page
    {
        EmptyPage emptyPage = new EmptyPage();
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        public FixedAssetsPage()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int faID = (fixedAssetsDataGrid.SelectedItem as FixedAssets).ID;
            UpdateFixedAssets updateFixedAssets = new UpdateFixedAssets(faID);
            FixedAssetsMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(updateFixedAssets);
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertFixedAssets faInsPage = new InsertFixedAssets();
            FixedAssetsMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(faInsPage);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (fixedAssetsDataGrid.SelectedItem == null)
                return;

            int faID = ((FixedAssets)fixedAssetsDataGrid.SelectedItem).ID;

            var removeFA = _db.FixedAssets.Where(fa => fa.ID == faID).Single();

            _db.FixedAssets.Remove(removeFA);
            _db.SaveChanges();
            fixedAssetsDataGrid.ItemsSource = _db.FixedAssets.ToList();
        }

        private void DefaultButton_Click(object sender, RoutedEventArgs e)
        {
            fixedAssetsDataGrid.ItemsSource = _db.FixedAssets.ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < fixedAssetsDataGrid.Items.Count; i++)
            {
                var filtered = _db.FixedAssets.Where(fa => fa.GroupName.StartsWith(SearchTextBox.Text));

                fixedAssetsDataGrid.ItemsSource = filtered.ToList();
            }
        }
    }
}
