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
    /// Логика взаимодействия для UpdateEventsPage.xaml
    /// </summary>
    public partial class UpdateEventsPage : Page
    {
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();
        int id;
        public UpdateEventsPage(int eventID)
        {
            InitializeComponent();
            id = eventID;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            ChEvents updEvents = (from ev in _db.ChEvents
                                  where ev.ID == id
                                  select ev).Single();
            updEvents.EventName = EventNameTextBox.Text;
            updEvents.EventDate = Convert.ToDateTime(EventDateTextBox.Text);
            updEvents.EvCategory = EventCategoryComboBox.Text;
            updEvents.EvType = EventTypeComboBox.Text;
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
