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
                    MaxHeight = 60
                };
                Border border = new Border
                {
                    BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FFDDDDDD"),
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Top,
                    Background = (Brush)new BrushConverter().ConvertFromString("#FFEFEFEF"),
                    MaxHeight = 60
                };
                TextBlock idUser = new TextBlock
                {
                    Text = $"{supplier.ID}",
                    Padding = new Thickness(15),
                    FontSize = 14,
                    MinWidth = 50,
                    TextAlignment = TextAlignment.Center
                };
                TextBlock nameUser = new TextBlock
                {
                    Text = supplier.Name,
                    Padding = new Thickness(15),
                    FontSize = 14,
                    MinWidth = 250,
                    TextAlignment = TextAlignment.Center

                };
                TextBlock contact = new TextBlock
                {
                    Text = supplier.Contact,
                    Padding = new Thickness(15),
                    FontSize = 14,
                    MinWidth = 250,
                    TextAlignment = TextAlignment.Center

                };
                TextBlock emailUser = new TextBlock
                {
                    Text = supplier.Email,
                    Padding = new Thickness(15),
                    FontSize = 14,
                    MinWidth = 250,
                    TextAlignment = TextAlignment.Center

                };
                TextBlock phone = new TextBlock
                {
                    Text = supplier.Phone,
                    Padding = new Thickness(15),
                    FontSize = 14,
                    MinWidth = 150,
                    TextAlignment = TextAlignment.Center

                };
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
                    Margin = new Thickness(150, 0, 5, 0),
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
                    Margin = new Thickness(10, 0, 15, 0),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Visibility = Visibility.Hidden,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Style = (Style)Application.Current.Resources["TransparentButton"],
                    Cursor = Cursors.Hand,
                    ToolTip = "Eliminar proveedor"

                };
                border.Child = newSupplier;
                newSupplier.Children.Add(idUser);
                newSupplier.Children.Add(nameUser);
                newSupplier.Children.Add(contact);
                newSupplier.Children.Add(emailUser);
                newSupplier.Children.Add(phone);
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
            StackPanel stackPanelUser = newBorder.Child as StackPanel;
            Button buttoEdit = stackPanelUser.Children[5] as Button;
            Button buttoDelete = stackPanelUser.Children[6] as Button;
            buttoEdit.Visibility = Visibility.Visible;
            buttoDelete.Visibility = Visibility.Visible;
        }
        private void MouseLeave_User(object sender, EventArgs e)
        {
            Border newBorder = sender as Border;
            newBorder.Background = (Brush)new BrushConverter().ConvertFromString("#FFEFEFEF");
            StackPanel stackPanelUser = newBorder.Child as StackPanel;
            Button buttoEdit = stackPanelUser.Children[5] as Button;
            Button buttoDelete = stackPanelUser.Children[6] as Button;
            buttoEdit.Visibility = Visibility.Hidden;
            buttoDelete.Visibility = Visibility.Hidden;
        }

        private void Handle_DeleteSupplier(object sender, EventArgs e)
        {
            Button editButton = sender as Button;
            StackPanel panel = editButton.Parent as StackPanel;
            TextBlock supplierText = panel.Children[1] as TextBlock;
            string userName = supplierText.Text;
            int supplierID = Convert.ToInt32((panel.Children[0] as TextBlock).Text);
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
            TextBlock supplierText = panel.Children[0] as TextBlock;
            int supplierID = Convert.ToInt32(supplierText.Text);
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
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

}
