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
    /// Lógica de interacción para PermissionsPage.xaml
    /// </summary>
    public partial class PermissionsPage : Page
    {
        public PermissionsPage()
        {
            InitializeComponent();
            CreateUser();
            CreateUser();
        }


        private void CreateUser()
        {
            StackPanel newUser = new StackPanel
            {
                Name = "user",
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Top,
                MaxHeight = 60
            };
            Border borderUser = new Border
            {
                BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FFDDDDDD"),
                BorderThickness = new Thickness(0, 0, 0, 2),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
                Background = (Brush)new BrushConverter().ConvertFromString("#FFE9E9E9"),
                MaxHeight = 60
            };
            TextBlock idUser = new TextBlock
            {
                Name = "iduser",
                Text = "1",
                Padding = new Thickness(15),
                FontSize = 14,
                MinWidth = 50,
                TextAlignment = TextAlignment.Center
            };
            TextBlock nameUser = new TextBlock
            {
                Name = "username",
                Text = "Maria Jose",
                Padding = new Thickness(15),
                FontSize = 14,
                MinWidth = 150,
                TextAlignment = TextAlignment.Center

            };
            TextBlock emailUser = new TextBlock
            {
                Name = "emailname",
                Text = "mariajose@empresa.com",
                Padding = new Thickness(15),
                FontSize = 14,
                MinWidth = 200,
                TextAlignment = TextAlignment.Center

            };
            TextBlock permissionUser = new TextBlock
            {
                Name = "username",
                Text = "Empleado",
                Padding = new Thickness(15),
                FontSize = 14,
                MinWidth = 150,
                TextAlignment = TextAlignment.Center

            };
            Button editUser = new Button
            {
                MinWidth = 100,
                Height = 30,
                Content = "Editar",
                Margin = new Thickness(15, 0, 15, 0),
                Padding = new Thickness(10, 0, 10, 0),                
                Background = (Brush)new BrushConverter().ConvertFromString("#FF00ACB4")
            };
            Button deleteUser = new Button
            {
                MinWidth = 100,
                Height = 30,
                Content = "Eliminar",
                Margin = new Thickness(15, 0, 15, 0),
                Padding = new Thickness(10, 0, 10, 0),
                Background = (Brush)new BrushConverter().ConvertFromString("#FF00ACB4")
            };
            borderUser.Child = newUser;
            newUser.Children.Add(idUser);
            newUser.Children.Add(nameUser);
            newUser.Children.Add(emailUser);
            newUser.Children.Add(permissionUser);
            newUser.Children.Add(editUser);
            newUser.Children.Add(deleteUser);
            usersTable.Children.Add(borderUser);

            borderUser.MouseEnter += new MouseEventHandler(MouseOver_User);
            borderUser.MouseLeave += new MouseEventHandler(MouseLeave_User);

            deleteUser.Click += new RoutedEventHandler(Handle_DeleteUser);

        }

        private void MouseOver_User(object sender, EventArgs e)
        {
            Border newBorder = sender as Border;
            newBorder.Background = (Brush)new BrushConverter().ConvertFromString("#FFDDDDDD");
            
        }
        private void MouseLeave_User(object sender, EventArgs e)
        {
            Border newBorder = sender as Border;
            newBorder.Background = (Brush)new BrushConverter().ConvertFromString("#FFE9E9E9");
        }

        private void Handle_DeleteUser(object sender, EventArgs e)
        {
            Button newButton= sender as Button;
            usersTable.Children.Remove(newButton.Parent as UIElement);
            
        }
    }
}
