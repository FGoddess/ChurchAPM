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
using System.Windows.Shapes;
using ChurchAPM.Pages;

namespace ChurchAPM
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public static DataGrid dataGrid;
        public static DataGrid admDataGrid;
        public static DataGrid empDataGrid;
        public static DataGrid donDataGrid;
        public static DataGrid fADataGrid;
        public static DataGrid iIDataGrid;
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        EventsPage eventsPage = new EventsPage();
        AdminsPage adminsPage = new AdminsPage();
        EmployersPage employersPage = new EmployersPage();
        FixedAssetsPage fixedAssetsPage = new FixedAssetsPage();
        InventoryItemsPage inventoryItemsPage = new InventoryItemsPage();
        DonationsPage donationsPage = new DonationsPage();
        public MenuWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            adminsPage.adminsDataGrid.ItemsSource = _db.Admins.ToList();
            eventsPage.eventsDataGrid.ItemsSource = _db.ChEvents.ToList();
            employersPage.employersDataGrid.ItemsSource = _db.Employers.ToList();
            fixedAssetsPage.fixedAssetsDataGrid.ItemsSource = _db.FixedAssets.ToList();
            inventoryItemsPage.inventoryItemsDataGrid.ItemsSource = _db.InventoryItems.ToList();
            donationsPage.donationsDataGrid.ItemsSource = _db.Donations.ToList();
            dataGrid = eventsPage.eventsDataGrid;
            admDataGrid = adminsPage.adminsDataGrid;
            empDataGrid = employersPage.employersDataGrid;
            donDataGrid = donationsPage.donationsDataGrid;
            fADataGrid = fixedAssetsPage.fixedAssetsDataGrid;
            iIDataGrid = inventoryItemsPage.inventoryItemsDataGrid;
        }

        private void LogoGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void EventsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = eventsPage;
        }

        private void AdminsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = adminsPage;
        }

        private void EmployerButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = employersPage;
        }

        private void FixedAssetsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = fixedAssetsPage;
        }

        private void InventoryItemsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = inventoryItemsPage;
        }

        private void DonationsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = donationsPage;
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.Help.ShowHelp(null, System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help.chm"));
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
