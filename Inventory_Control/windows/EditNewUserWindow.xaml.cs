using Inventory_Control.constants;
using Inventory_Control.pages;
using Inventory_Control.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (ValidateFields())
            {
                User newUser = new User
                {
                    Name = userName.Text,
                    Email = userEmail.Text,
                    Permission = userPermission.Text,
                };
                if (UserID == 0)
                {
                    EditQuery.AddUser(newUser);
                }
                else
                {
                    EditQuery.EditUser(UserID, newUser);
                }
                Close();
            }
        }

        private bool ValidateFields()
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|mx|dev)$";
            if (userName.Text == string.Empty)
            {
                userName.BorderBrush = Brushes.Red;
                errorUsername.Visibility = Visibility.Visible;
                errorUsername.Content = "No puede quedar vacío";
                return false;
            }
            if (userEmail.Text == string.Empty)
            {
                userEmail.BorderBrush = Brushes.Red;
                errorEmail.Visibility = Visibility.Visible;
                errorEmail.Content = "No puede quedar vacío";
                return false;
            }
            if (userPermission.Text == string.Empty)
            {
                userPermission.BorderBrush = Brushes.Red;
                errorPermission.Visibility = Visibility.Visible;
                return false;
            }
            if (userName.Text.Length < 4)
            {
                userName.BorderBrush = Brushes.Red;
                errorUsername.Visibility = Visibility.Visible;
                errorUsername.Content = "Elija un nombre de al menos 4 caracteres";
                return false;
            }
            if (!Regex.IsMatch(userName.Text, @"^[a-zA-Z\s]+$"))
            {
                userName.BorderBrush = Brushes.Red;
                errorUsername.Visibility = Visibility.Visible;
                errorUsername.Content = "Elija sólo letras";
                return false;
            }
            if (!Regex.IsMatch(userEmail.Text, regex, RegexOptions.IgnoreCase))
            {
                errorEmail.BorderBrush = Brushes.Red;
                errorEmail.Visibility = Visibility.Visible;
                errorEmail.Content = "Formato de correo no válido";
                return false;
            }
            return true;
        }

        private void UserName_GotFocus(object sender, RoutedEventArgs e)
        {

            var typeObject = sender.GetType();
            if (typeObject.Name == "TextBox")
            {
                TextBox textBoxField = sender as TextBox;
                if (textBoxField.Name == "userName")
                {
                    errorUsername.Visibility = Visibility.Hidden;
                }
                if (textBoxField.Name == "userEmail")
                {
                    errorEmail.Visibility = Visibility.Hidden;
                }
                textBoxField.BorderBrush = (Brush)Application.Current.Resources["OptionalBrush"];
            }
            else if (typeObject.Name == "ComboBox")
            {
                ComboBox comboBoxField = sender as ComboBox;
                comboBoxField.BorderBrush = (Brush)Application.Current.Resources["OptionalBrush"];
                errorPermission.Visibility = Visibility.Hidden;
            }


        }
    }
}
