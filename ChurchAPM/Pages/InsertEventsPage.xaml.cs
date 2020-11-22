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
    /// Логика взаимодействия для InsertEventsPage.xaml
    /// </summary>
    public partial class InsertEventsPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        public InsertEventsPage()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            ChEvents newEvent = new ChEvents()
            {
                EventName = EventNameTextBox.Text,
                EventDate = Convert.ToDateTime(EventDateTextBox.Text),
                EvType = EventTypeComboBox.Text,
                EvCategory = EventCategoryComboBox.Text
            };

            _db.ChEvents.Add(newEvent);
            _db.SaveChanges();
            MenuWindow.dataGrid.ItemsSource = _db.ChEvents.ToList();
            this.NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
