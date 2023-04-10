using Inventory_Control.utilities;
using Inventory_Control.windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
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
        DataBaseQuery PermissionsQuery = new DataBaseQuery();
        public PermissionsPage()
        {
            InitializeComponent();
            PermissionsQuery.GetAllUser(out List<User> usersData);
            CreateUser(usersData);
        }


        private void CreateUser(List<User> users)
        {
            foreach (User user in users)
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
                    Background = (Brush)new BrushConverter().ConvertFromString("#FFEFEFEF"),
                    MaxHeight = 60
                };
                TextBlock idUser = new TextBlock
                {
                    Name = "iduser",
                    Text = $"{user.ID}",
                    Padding = new Thickness(15),
                    FontSize = 14,
                    MinWidth = 50,
                    TextAlignment = TextAlignment.Center
                };
                TextBlock nameUser = new TextBlock
                {
                    Name = "username",
                    Text = user.Name,
                    Padding = new Thickness(15),
                    FontSize = 14,
                    MinWidth = 250,
                    TextAlignment = TextAlignment.Center

                };
                TextBlock emailUser = new TextBlock
                {
                    Name = "emailname",
                    Text = user.Email,
                    Padding = new Thickness(15),
                    FontSize = 14,
                    MinWidth = 250,
                    TextAlignment = TextAlignment.Center

                };
                TextBlock permissionUser = new TextBlock
                {
                    Name = "username",
                    Text = user.Permission,
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
                    Margin = new Thickness(390, 0, 5, 0),
                    Padding = new Thickness(10, 0, 10, 0),
                    Visibility = Visibility.Hidden,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Style = (Style)Application.Current.Resources["TransparentButton"],
                    Cursor = Cursors.Hand,
                    ToolTip = "Editar usuario"

                };
                Image imageDeleteUser = new Image
                {
                    Width = 24,
                    Height = 24,
                    Source = new BitmapImage(new Uri("/assets/delete.png", UriKind.Relative)),
                    Opacity = 0.7
                };
                Button deleteUser = new Button
                {
                    Content = imageDeleteUser,
                    Margin = new Thickness(10, 0, 15, 0),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Visibility = Visibility.Hidden,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Style = (Style)Application.Current.Resources["TransparentButton"],
                    Cursor = Cursors.Hand,
                    ToolTip = "Eliminar usuario"

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
                editUser.Click += new RoutedEventHandler(Handle_EditUser);
            }
        }

        private void MouseOver_User(object sender, EventArgs e)
        {
            Border newBorder = sender as Border;
            newBorder.Background = (Brush)new BrushConverter().ConvertFromString("#FFE9E9E9");
            StackPanel stackPanelUser = newBorder.Child as StackPanel;
            Button buttoEdit = stackPanelUser.Children[4] as Button;
            Button buttoDelete = stackPanelUser.Children[5] as Button;
            buttoEdit.Visibility = Visibility.Visible;
            buttoDelete.Visibility = Visibility.Visible;
        }
        private void MouseLeave_User(object sender, EventArgs e)
        {
            Border newBorder = sender as Border;
            newBorder.Background = (Brush)new BrushConverter().ConvertFromString("#FFEFEFEF");
            StackPanel stackPanelUser = newBorder.Child as StackPanel;
            Button buttoEdit = stackPanelUser.Children[4] as Button;
            Button buttoDelete = stackPanelUser.Children[5] as Button;
            buttoEdit.Visibility = Visibility.Hidden;
            buttoDelete.Visibility = Visibility.Hidden;
        }

        private void Handle_DeleteUser(object sender, EventArgs e)
        {
            Button newButton = sender as Button;
            StackPanel panelUser = newButton.Parent as StackPanel;
            TextBlock userText = panelUser.Children[1] as TextBlock;
            string userName = userText.Text;
            int userID = Convert.ToInt32((panelUser.Children[0] as TextBlock).Text);
            Border borderUser = panelUser.Parent as Border;
            Effect = ((Resources["BlurWindow"] as Style).Setters[0] as Setter).Value as Effect;
            MessageBoxResult result = MessageWindow.ShowWindow($"Desea eliminar al usuario: '{userName}' de la base de datos? No se podra recuperar", "Eliminar Usuario", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            Effect = null;
            if (result == MessageBoxResult.Yes)
            {
                PermissionsQuery.DeleteUser(userID);
                int numberUsers = usersTable.Children.Count;
                for (int index = 0; index < numberUsers; index++)
                {
                    usersTable.Children.Remove(usersTable.Children[0] as Border);
                }
                PermissionsQuery.GetAllUser(out List<User> usersData);
                CreateUser(usersData);
            }
        }

        private void Handle_EditUser(object sender, EventArgs e)
        {
            Button newButton = sender as Button;
            StackPanel panelUser = newButton.Parent as StackPanel;
            TextBlock userText = panelUser.Children[0] as TextBlock;
            int userID = Convert.ToInt32(userText.Text);
            EditNewUserWindow editUserWindow = new EditNewUserWindow(userID);
            editUserWindow.ShowDialog();
            int numberUsers = usersTable.Children.Count;
            for (int index = 0; index < numberUsers; index++)
            {
                usersTable.Children.Remove(usersTable.Children[0] as Border);
            }
            PermissionsQuery.GetAllUser(out List<User> usersData);
            CreateUser(usersData);
        }

        private void Handle_AddUser(object sender, RoutedEventArgs e)
        {
            EditNewUserWindow editUserWindow = new EditNewUserWindow(0);
            editUserWindow.ShowDialog();
            int numberUsers = usersTable.Children.Count;
            for (int index = 0; index < numberUsers; index++)
            {
                usersTable.Children.Remove(usersTable.Children[0] as Border);
            }
            PermissionsQuery.GetAllUser(out List<User> usersData);
            CreateUser(usersData);
        }

    }
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Permission { get; set; }
    }

}