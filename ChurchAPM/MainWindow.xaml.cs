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

namespace ChurchAPM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void LogoGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string passwoed = PasswordTextBox.Password;

            if (LoginTextBox.Text.Length < 4)
            {
                LoginTextBox.ToolTip = "Данные введены некорректно!";
                LoginTextBox.Background = Brushes.Red;
            }
            else if (PasswordTextBox.Password.Length < 4)
            {
                PasswordTextBox.ToolTip = "Данные введены некорректно!";
                PasswordTextBox.Background = Brushes.Red;
            }
            else
            {
                LoginTextBox.Background = Brushes.Transparent;
                PasswordTextBox.Background = Brushes.Transparent;
                MenuWindow wm = new MenuWindow();
                wm.Show();
                this.Close();
            }
        }
    }
}
