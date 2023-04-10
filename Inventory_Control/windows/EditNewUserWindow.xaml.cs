using Inventory_Control.constants;
using Inventory_Control.pages;
using Inventory_Control.utilities;
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

namespace Inventory_Control.windows
{
    /// <summary>
    /// Lógica de interacción para EditNewUserWindow.xaml
    /// </summary>
    public partial class EditNewUserWindow : Window
    {
        DataBaseQuery EditQuery = new DataBaseQuery();
        private int UserID = 0;
        public EditNewUserWindow(int IdUser)
        {
            UserID = IdUser;
            DataContext = new Permissions();
            InitializeComponent();
            if (IdUser == 0)
            {
                TitleWindow.Content = "Agregar usuario";
            }
            else
            {
                TitleWindow.Content = "Editar usuario";
                EditQuery.GetUser(IdUser, out Array userData);
                userName.Text = userData.GetValue(1).ToString();
                userEmail.Text = userData.GetValue(2).ToString();
                userPermission.Text = userData.GetValue(3).ToString();
            }


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (UserID == 0)
            {
                User newUser = new User
                {
                    Name = userName.Text,
                    Email = userEmail.Text,
                    Permission = userPermission.Text,
                };
                EditQuery.AddUser(newUser);
            }
            else
            {
                User newUser = new User
                {
                    Name = userName.Text,
                    Email = userEmail.Text,
                    Permission = userPermission.Text,
                };
                EditQuery.EditUser(UserID, newUser);
            }
            Close();
        }
    }
}
