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
    /// Lógica de interacción para DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        private string TitleWin;
        private string ContentWin;
        private MessageBoxImage TypeAlert;
        private MessageBoxButton buttonSelection;
        private MessageBoxResult buttonResult;
        public DialogWindow(string Title, string Content, MessageBoxImage TypeAlerts, MessageBoxButton boxButton)
        {
            InitializeComponent();
            TitleWin = Title;
            ContentWin = Content;
            TypeAlert = TypeAlerts;
            buttonSelection = boxButton;
            UpdateWindow();
        }
        private void UpdateWindow()
        {
            //MessageWindow.GetMessageValues(out string Title ,out string Content, out int TypeAlert);

            TitleWindow.Content = TitleWin;
            ContentWindow.Text = ContentWin;

            switch (TypeAlert)
            {
                case MessageBoxImage.None:
                    ContentWindow.Margin = new Thickness(14, 58, 14, 45);
                    break;
                case MessageBoxImage.Question:
                    ImageAlert.Source = new BitmapImage(new Uri("/assets/question.png", UriKind.Relative));
                    break;
                case MessageBoxImage.Error:
                    ImageAlert.Source = new BitmapImage(new Uri("/assets/error.png", UriKind.Relative));
                    break;
                case MessageBoxImage.Warning:
                    ImageAlert.Source = new BitmapImage(new Uri("/assets/warning.png", UriKind.Relative));
                    break;
                case MessageBoxImage.Information:
                    ImageAlert.Source = new BitmapImage(new Uri("/assets/information.png", UriKind.Relative));
                    break;
                default:
                    break;
            }

            switch (buttonSelection)
            {
                case MessageBoxButton.OK:
                    buttonOne.Visibility = Visibility.Hidden;
                    buttonTwo.Visibility = Visibility.Hidden;
                    buttonThree.Visibility = Visibility.Visible;
                    buttonThree.Content = "OK";
                    break;
                case MessageBoxButton.OKCancel:
                    buttonOne.Visibility = Visibility.Hidden;
                    buttonTwo.Visibility = Visibility.Visible;
                    buttonThree.Visibility = Visibility.Visible;
                    buttonTwo.Content = "OK";
                    buttonThree.Content = "Cancel";
                    break;
                case MessageBoxButton.YesNoCancel:
                    buttonOne.Visibility = Visibility.Visible;
                    buttonTwo.Visibility = Visibility.Visible;
                    buttonThree.Visibility = Visibility.Visible;
                    buttonOne.Content = /*Strings.buttonYes*/ "Yes";
                    buttonTwo.Content = "No";
                    buttonThree.Content = "Cancel";
                    break;
                case MessageBoxButton.YesNo:
                    buttonOne.Visibility = Visibility.Visible;
                    buttonTwo.Visibility = Visibility.Hidden;
                    buttonThree.Visibility = Visibility.Visible;
                    buttonOne.Content = /*Strings.buttonYes*/ "Yes";
                    buttonThree.Content = "No";
                    break;
                default:
                    break;
            }

            buttonOne.Focus();

        }

        private void EvaluateButtonPressed(string buttonPressed)
        {

            if (buttonPressed == "buttonOne")
            {
                MessageWindow.BoxResult = MessageBoxResult.Yes;
            }
            else if (buttonPressed == "buttonTwo")
            {
                if (buttonSelection == MessageBoxButton.OKCancel)
                {
                    MessageWindow.BoxResult = MessageBoxResult.OK;
                }
                else if (buttonSelection == MessageBoxButton.YesNoCancel)
                {
                    MessageWindow.BoxResult = MessageBoxResult.No;
                }
            }
            else if (buttonPressed == "buttonThree")
            {
                if (buttonSelection == MessageBoxButton.OKCancel)
                {
                    MessageWindow.BoxResult = MessageBoxResult.Cancel;
                }
                else if (buttonSelection == MessageBoxButton.YesNoCancel)
                {
                    MessageWindow.BoxResult = MessageBoxResult.Cancel;
                }
                else if (buttonSelection == MessageBoxButton.OK)
                {
                    MessageWindow.BoxResult = MessageBoxResult.OK;
                }
                else if (buttonSelection == MessageBoxButton.YesNo)
                {
                    MessageWindow.BoxResult = MessageBoxResult.No;
                }
            }
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void Response_Click(object sender, RoutedEventArgs e)
        {
            var buttonPressed = sender as Button;
            EvaluateButtonPressed(buttonPressed.Name);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (buttonOne.IsFocused)
                {
                    EvaluateButtonPressed(buttonOne.Name);
                }
                if (buttonTwo.IsFocused)
                {
                    EvaluateButtonPressed(buttonTwo.Name);
                }
                if (buttonThree.IsFocused)
                {
                    EvaluateButtonPressed(buttonThree.Name);
                }
            }

        }
    }
}
