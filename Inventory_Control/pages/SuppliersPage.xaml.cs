using Inventory_Control.utilities;
using Inventory_Control.windows;
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

namespace Inventory_Control.pages
{
    /// <summary>
    /// Lógica de interacción para SuppliersPage.xaml
    /// </summary>
    public partial class SuppliersPage : Page
    {
        DataBaseQuery SupplierQuery = new DataBaseQuery();
        public SuppliersPage()
        {
            InitializeComponent();
            SupplierQuery.GetAllSuppliers(out List<Supplier> suppliersData);
            CreateUser(suppliersData);
        }

        private void CreateUser(List<Supplier> suppliers)
        {
            foreach (Supplier supplier in suppliers)
            {
                StackPanel newSupplier = new StackPanel
                {
                    Name = "user",
                    Orientation = Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Top,
                    MaxHeight = 150
                };
                Border border = new Border
                {
                    BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FFDDDDDD"),
                    BorderThickness = new Thickness(2),
                    Margin = new Thickness(10),
                    Padding = new Thickness(10),
                    CornerRadius = new CornerRadius(4),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Top,
                    Background = (Brush)new BrushConverter().ConvertFromString("#FFEFEFEF"),
                    MaxHeight = 150
                };
                Image imageSupplier = new Image
                {
                    Width = 150,
                    Source = new BitmapImage(new Uri(supplier.Image, UriKind.Absolute)),
                };
                Label idLabel = new Label
                {
                    MinWidth = 80,
                    Padding = new Thickness(0, 5, 0, 0),
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("Segoe UI Semibold"),
                    Background = Brushes.Transparent,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    FontSize = 14,
                    Foreground = (Brush)Application.Current.Resources["TertiaryBrush"],
                    Content = "ID: "
                };
                TextBlock idUser = new TextBlock
                {
                    Text = $"{supplier.ID}",
                    Padding = new Thickness(15, 5, 15, 0),
                    FontSize = 14,
                    MinWidth = 50,
                    TextAlignment = TextAlignment.Left
                };
                StackPanel idPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxHeight = 120
                };
                idPanel.Children.Add(idLabel);
                idPanel.Children.Add(idUser);
                Label nameLabel = new Label
                {
                    MinWidth = 80,
                    FontFamily = new FontFamily("Segoe UI Semibold"),
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Background = Brushes.Transparent,
                    FontSize = 14,
                    Foreground = (Brush)Application.Current.Resources["TertiaryBrush"],
                    Content = "Nombre: "
                };
                TextBlock nameUser = new TextBlock
                {
                    Text = supplier.Name,
                    Padding = new Thickness(15, 5, 15, 0),
                    FontSize = 14,
                    MinWidth = 250,
                    TextAlignment = TextAlignment.Left

                };
                StackPanel namePanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxHeight = 120
                };
                namePanel.Children.Add(nameLabel);
                namePanel.Children.Add(nameUser);
                Label rfcLabel = new Label
                {
                    MinWidth = 80,
                    FontFamily = new FontFamily("Segoe UI Semibold"),
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Background = Brushes.Transparent,
                    FontSize = 14,
                    Foreground = (Brush)Application.Current.Resources["TertiaryBrush"],
                    Content = "R.F.C.: "
                };
                TextBlock rfc = new TextBlock
                {
                    Text = supplier.RFC,
                    Padding = new Thickness(15, 5, 15, 0),
                    FontSize = 14,
                    MinWidth = 250,
                    TextAlignment = TextAlignment.Left

                };
                StackPanel rfcPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxHeight = 120
                };
                rfcPanel.Children.Add(rfcLabel);
                rfcPanel.Children.Add(rfc);
                Label addressLabel = new Label
                {
                    MinWidth = 80,
                    FontFamily = new FontFamily("Segoe UI Semibold"),
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Background = Brushes.Transparent,
                    FontSize = 14,
                    Foreground = (Brush)Application.Current.Resources["TertiaryBrush"],
                    Content = "Dirección: "
                };
                TextBlock address = new TextBlock
                {
                    Text = supplier.Address,
                    Padding = new Thickness(15, 5, 15, 0),
                    FontSize = 14,
                    MinWidth = 500,
                    TextAlignment = TextAlignment.Left

                };
                StackPanel addressPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxHeight = 120
                };
                addressPanel.Children.Add(addressLabel);
                addressPanel.Children.Add(address);
                StackPanel card = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxHeight = 120
                };
                card.Children.Add(idPanel);
                card.Children.Add(namePanel);
                card.Children.Add(rfcPanel);
                card.Children.Add(addressPanel);
                Label contactLabel = new Label
                {
                    MinWidth = 80,
                    FontFamily = new FontFamily("Segoe UI Semibold"),
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Background = Brushes.Transparent,
                    FontSize = 14,
                    Foreground = (Brush)Application.Current.Resources["TertiaryBrush"],
                    Content = "Contacto: "
                };
                TextBlock contact = new TextBlock
                {
                    Text = supplier.Contact,
                    Padding = new Thickness(15, 5, 15, 0),
                    FontSize = 14,
                    MinWidth = 250,
                    TextAlignment = TextAlignment.Left

                };
                StackPanel contactPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxHeight = 120
                };
                contactPanel.Children.Add(contactLabel);
                contactPanel.Children.Add(contact);
                Label emailLabel = new Label
                {
                    MinWidth = 80,
                    FontFamily = new FontFamily("Segoe UI Semibold"),
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Background = Brushes.Transparent,
                    FontSize = 14,
                    Foreground = (Brush)Application.Current.Resources["TertiaryBrush"],
                    Content = "Email: "
                };
                TextBlock emailUser = new TextBlock
                {
                    Text = supplier.Email,
                    Padding = new Thickness(15, 5, 15, 0),
                    FontSize = 14,
                    MinWidth = 250,
                    TextAlignment = TextAlignment.Left

                };
                StackPanel emailPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxHeight = 120
                };
                emailPanel.Children.Add(emailLabel);
                emailPanel.Children.Add(emailUser);
                Label phoneLabel = new Label
                {
                    MinWidth = 80,
                    FontFamily = new FontFamily("Segoe UI Semibold"),
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Background = Brushes.Transparent,
                    FontSize = 14,
                    Foreground = (Brush)Application.Current.Resources["TertiaryBrush"],
                    Content = "Teléfono: "
                };
                TextBlock phone = new TextBlock
                {
                    Text = supplier.Phone,
                    Padding = new Thickness(15, 5, 15, 0),
                    FontSize = 14,
                    MinWidth = 150,
                    TextAlignment = TextAlignment.Left

                };
                StackPanel phonePanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxHeight = 120
                };
                phonePanel.Children.Add(phoneLabel);
                phonePanel.Children.Add(phone);
                StackPanel cardTwo = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxHeight = 120
                };
                cardTwo.Children.Add(contactPanel);
                cardTwo.Children.Add(emailPanel);
                cardTwo.Children.Add(phonePanel);
                Image imageEditUser = new Image
                {
                    Width = 25,
                    Height = 25,
                    Source = new BitmapImage(new Uri("/assets/edit.png", UriKind.Relative)),
                    Opacity = 0.5
                };
                Button editUser = new Button
                {
                    Content = imageEditUser,
                    Margin = new Thickness(5, 0, 5, 0),
                    Padding = new Thickness(10, 0, 10, 0),
                    Visibility = Visibility.Hidden,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Style = (Style)Application.Current.Resources["TransparentButton"],
                    Cursor = Cursors.Hand,
                    ToolTip = "Editar proveedor"

                };
                Image imageDelete = new Image
                {
                    Width = 24,
                    Height = 24,
                    Source = new BitmapImage(new Uri("/assets/delete.png", UriKind.Relative)),
                    Opacity = 0.7
                };
                Button deleteUser = new Button
                {
                    Content = imageDelete,
                    Margin = new Thickness(0, 0, 15, 0),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Visibility = Visibility.Hidden,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Style = (Style)Application.Current.Resources["TransparentButton"],
                    Cursor = Cursors.Hand,
                    ToolTip = "Eliminar proveedor"

                };
                border.Child = newSupplier;
                newSupplier.Children.Add(imageSupplier);
                newSupplier.Children.Add(card);
                newSupplier.Children.Add(cardTwo);
                //newSupplier.Children.Add(emailUser);
                //newSupplier.Children.Add(phone);
                newSupplier.Children.Add(editUser);
                newSupplier.Children.Add(deleteUser);
                suppliersTable.Children.Add(border);

                border.MouseEnter += new MouseEventHandler(MouseOver_User);
                border.MouseLeave += new MouseEventHandler(MouseLeave_User);

                deleteUser.Click += new RoutedEventHandler(Handle_DeleteSupplier);
                editUser.Click += new RoutedEventHandler(Handle_EditSupplier);
            }
        }

        private void MouseOver_User(object sender, EventArgs e)
        {
            Border newBorder = sender as Border;
            newBorder.Background = (Brush)new BrushConverter().ConvertFromString("#FFE9E9E9");
            newBorder.BorderBrush = (Brush)Application.Current.Resources["ButtonBrush"];
            StackPanel stackPanelUser = newBorder.Child as StackPanel;
            Button buttoEdit = stackPanelUser.Children[3] as Button;
            Button buttoDelete = stackPanelUser.Children[4] as Button;
            buttoEdit.Visibility = Visibility.Visible;
            buttoDelete.Visibility = Visibility.Visible;
        }
        private void MouseLeave_User(object sender, EventArgs e)
        {
            Border newBorder = sender as Border;
            newBorder.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FFDDDDDD");
            newBorder.Background = (Brush)new BrushConverter().ConvertFromString("#FFEFEFEF");
            StackPanel stackPanelUser = newBorder.Child as StackPanel;
            Button buttoEdit = stackPanelUser.Children[3] as Button;
            Button buttoDelete = stackPanelUser.Children[4] as Button;
            buttoEdit.Visibility = Visibility.Hidden;
            buttoDelete.Visibility = Visibility.Hidden;
        }

        private void Handle_DeleteSupplier(object sender, EventArgs e)
        {
            Button editButton = sender as Button;
            StackPanel panel = editButton.Parent as StackPanel;
            StackPanel panelInfo = panel.Children[1] as StackPanel;
            StackPanel panelID = panelInfo.Children[0] as StackPanel;
            StackPanel panelName = panelInfo.Children[1] as StackPanel;
            TextBlock id = panelID.Children[1] as TextBlock;
            TextBlock name = panelName.Children[1] as TextBlock;
            string userName = name.Text;
            int supplierID = Convert.ToInt32(id.Text);
            MessageBoxResult result = MessageWindow.ShowWindow($"Desea eliminar al proveedor: '{userName}' de la base de datos? No se podra recuperar", "Eliminar Proveedor", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            Effect = null;
            if (result == MessageBoxResult.Yes)
            {
                SupplierQuery.DeleteUser(supplierID);
                int numberSuppliers = suppliersTable.Children.Count;
                for (int index = 0; index < numberSuppliers; index++)
                {
                    suppliersTable.Children.Remove(suppliersTable.Children[0] as Border);
                }
                SupplierQuery.GetAllSuppliers(out List<Supplier> suppliersData);
                CreateUser(suppliersData);
            }
        }

        private void Handle_EditSupplier(object sender, EventArgs e)
        {
            Button editButton = sender as Button;
            StackPanel panel = editButton.Parent as StackPanel;
            StackPanel panelInfo = panel.Children[1] as StackPanel;
            StackPanel panelID = panelInfo.Children[0] as StackPanel;
            TextBlock id = panelID.Children[1] as TextBlock;
            int supplierID = Convert.ToInt32(id.Text);
            EditNewSuplierWindow editSupplierWindow = new EditNewSuplierWindow(supplierID);
            editSupplierWindow.ShowDialog();
            int numberSuppliers = suppliersTable.Children.Count;
            for (int index = 0; index < numberSuppliers; index++)
            {
                suppliersTable.Children.Remove(suppliersTable.Children[0] as Border);
            }
            SupplierQuery.GetAllSuppliers(out List<Supplier> suppliersData);
            CreateUser(suppliersData);
        }

        private void Handle_AddSupplier(object sender, RoutedEventArgs e)
        {
            EditNewSuplierWindow editSupplierWindow = new EditNewSuplierWindow(0);
            editSupplierWindow.ShowDialog();
            int numberSuppliers = suppliersTable.Children.Count;
            for (int index = 0; index < numberSuppliers; index++)
            {
                suppliersTable.Children.Remove(suppliersTable.Children[0] as Border);
            }
            SupplierQuery.GetAllSuppliers(out List<Supplier> suppliersData);
            CreateUser(suppliersData);
        }

    }
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string RFC { get; set; }
        public string Address { get; set; }
        public string Colonia { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
    }

}
