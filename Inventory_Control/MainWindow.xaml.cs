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
using Inventory_Control.pages;

namespace Inventory_Control
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            LoadDashboard();
            //ResetBackgroundButtons();
            //Button Children = NavigationMenu.Children[2] as Button;

        }

        private void LoadDashboard()
        {
            viewPage.NavigationService.Navigate(new DashboardPage());
        }

        private void ResetBackgroundButtons(Button sender)
        {
            int ChildrenCount = NavigationMenu.Children.Count;
            for (int i = 1; i < ChildrenCount; i++)
            {
                Button menuItem = NavigationMenu.Children[i] as Button;
                menuItem.Background = (Brush)Application.Current.Resources["TertiaryBrush"];
            }
            Button button = sender as Button;
            button.Background = (Brush)Application.Current.Resources["PrimaryBrush"];
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            viewPage.NavigationService.Navigate(new DashboardPage());
            Console.WriteLine(NavigationMenu.Children);
            ResetBackgroundButtons(sender as Button);

        }

        private void PermissionButton_Click(object sender, RoutedEventArgs e)
        {
            viewPage.NavigationService.Navigate(new PermissionsPage());
            //Button button = sender as Button;
            //button.Background = (Brush)Application.Current.Resources["PrimaryBrush"];
            ResetBackgroundButtons(sender as Button);
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            viewPage.NavigationService.Navigate(new CategoriesPage());
            ResetBackgroundButtons(sender as Button);
        }

        private void SupplierButton_Click(object sender, RoutedEventArgs e)
        {
            viewPage.NavigationService.Navigate(new SuppliersPage());
            ResetBackgroundButtons(sender as Button);
        }

        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            viewPage.NavigationService.Navigate(new SalesPage());
            ResetBackgroundButtons(sender as Button);
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            viewPage.NavigationService.Navigate(new InventoryPage());
            ResetBackgroundButtons(sender as Button);
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            viewPage.NavigationService.Navigate(new ReportPage());
            ResetBackgroundButtons(sender as Button);
        }

        private void MenuButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Opacity = 0.7;
        }
        private void MenuButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Opacity = 1;
        }
    }
}
