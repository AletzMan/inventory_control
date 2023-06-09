﻿using Inventory_Control.pages;
using Inventory_Control.utilities;
using System;
using Newtonsoft.Json;
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
using System.IO;
using Inventory_Control.constants;

namespace Inventory_Control.windows
{
    /// <summary>
    /// Lógica de interacción para EditNewSuplierWindow.xaml
    /// </summary>
    public partial class EditNewSuplierWindow : Window
    {
        DataBaseQuery EditSupplierQuery = new DataBaseQuery();
        ApiRest apiRest = new ApiRest();
        private int SupplierID = 0;
        IList<string> namesCity;
        public EditNewSuplierWindow(int IdSupplier)
        {
            SupplierID = IdSupplier;
            InitializeComponent();

            DataContext = this;
            if (IdSupplier == 0)
            {
                TitleWindow.Content = "Agregar proveedor";
            }
            else
            {
                TitleWindow.Content = "Editar proveedor";
                EditSupplierQuery.GetSupplier(IdSupplier, out Array userData);
                userName.Text = userData.GetValue(1).ToString();
                rfc.Text = userData.GetValue(2).ToString();
                address.Text = userData.GetValue(3).ToString();
                colonia.Text = userData.GetValue(4).ToString();
                zipCode.Text = userData.GetValue(5).ToString();
                state.Text = userData.GetValue(7).ToString();
                city.Text = userData.GetValue(6).ToString();
                contact.Text = userData.GetValue(8).ToString();
                email.Text = userData.GetValue(9).ToString();
                phone.Text = userData.GetValue(10).ToString();
                urlImage.Text = userData.GetValue(11).ToString();
                logo.Source = new BitmapImage(new Uri(userData.GetValue(11).ToString(), UriKind.Absolute));
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
                Supplier newSupplier = new Supplier
                {
                    Name = userName.Text,
                    RFC = rfc.Text,
                    Address = address.Text,
                    Colonia = colonia.Text,
                    ZipCode = zipCode.Text,
                    City = city.Text,
                    State = state.Text,
                    Contact = contact.Text,
                    Email = email.Text,
                    Phone = phone.Text,
                    Image = urlImage.Text

                };
                if (SupplierID == 0)
                {
                    EditSupplierQuery.AddSupplier(newSupplier);
                }
                else
                {
                    EditSupplierQuery.EditSupplier(SupplierID, newSupplier);
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
            if (contact.Text == string.Empty)
            {
                contact.BorderBrush = Brushes.Red;
                errorContact.Visibility = Visibility.Visible;
                return false;
            }
            if (email.Text == string.Empty)
            {
                email.BorderBrush = Brushes.Red;
                errorEmail.Visibility = Visibility.Visible;
                errorEmail.Content = "No puede quedar vacío";
                return false;
            }
            if (phone.Text == string.Empty)
            {
                phone.BorderBrush = Brushes.Red;
                errorPhone.Visibility = Visibility.Visible;
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
            if (!Regex.IsMatch(email.Text, regex, RegexOptions.IgnoreCase))
            {
                errorEmail.BorderBrush = Brushes.Red;
                errorEmail.Visibility = Visibility.Visible;
                errorEmail.Content = "Formato de correo no válido";
                return false;
            }
            if (!Regex.IsMatch(phone.Text, @"^[0-9\s]+$"))
            {
                phone.BorderBrush = Brushes.Red;
                errorPhone.Visibility = Visibility.Visible;
                errorPhone.Content = "Sólo pueden ser números";
                return false;
            }
            return true;
        }

        private void UserName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBoxField = sender as TextBox;
            if (textBoxField.Name == "userName")
            {
                errorUsername.Visibility = Visibility.Hidden;
            }
            if (textBoxField.Name == "contact")
            {
                errorContact.Visibility = Visibility.Hidden;
            }
            if (textBoxField.Name == "email")
            {
                errorEmail.Visibility = Visibility.Hidden;
            }
            if (textBoxField.Name == "phone")
            {
                errorPhone.Visibility = Visibility.Hidden;
            }
            textBoxField.BorderBrush = (Brush)Application.Current.Resources["OptionalBrush"];
        }

        private void UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length > (sender as TextBox).MaxLength)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, (sender as TextBox).MaxLength);
                (sender as TextBox).Text = (sender as TextBox).Text + "...";
            }
        }

        private void State_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //dynamic results = apiRest.GetData("https://api.datos.gob.mx/v1/condiciones-atmosfericas");
            //string path = Environment.CurrentDirectory + "/utilities/States.json";
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\utilities\\States.json";
            var cities = JsonConvert.DeserializeObject<States>(File.ReadAllText(path));
            int indexCity = state.SelectedIndex;
            var stateSelected = cities.Municipios[indexCity];
            city.ItemsSource = stateSelected;
            city.IsEnabled = true;
        }
    }
}
