using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ChurchAPM.Pages
{
    /// <summary>
    /// Логика взаимодействия для EventsPage.xaml
    /// </summary>
    public partial class EventsPage : Page
    {
        EmptyPage emptyPage = new EmptyPage();
        ChurchDataBaseEntities _db = new ChurchDataBaseEntities();

        public EventsPage()
        {
            InitializeComponent();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertEventsPage eventsInsPage = new InsertEventsPage();
            EventsMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(eventsInsPage);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (eventsDataGrid.SelectedItem == null)
                return;

            int eventID = ((ChEvents)eventsDataGrid.SelectedItem).ID;

            var removeEvent = _db.ChEvents.Where(ev => ev.ID == eventID).Single();

            _db.ChEvents.Remove(removeEvent);
            _db.SaveChanges();
            eventsDataGrid.ItemsSource = _db.ChEvents.ToList();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            int evID = (eventsDataGrid.SelectedItem as ChEvents).ID;
            UpdateEventsPage updateEventsPage = new UpdateEventsPage(evID);
            EventsMainFrame.Content = emptyPage;
            this.NavigationService.Navigate(updateEventsPage);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < eventsDataGrid.Items.Count; i++)
            {
                var filtered = _db.ChEvents.Where(ev => ev.EventName.StartsWith(SearchTextBox.Text));

                eventsDataGrid.ItemsSource = filtered.ToList();
            }
        }

        private void DefaultButton_Click(object sender, RoutedEventArgs e)
        {
            eventsDataGrid.ItemsSource = _db.ChEvents.ToList();
        }
    }
}
