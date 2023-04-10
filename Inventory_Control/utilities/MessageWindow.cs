using Inventory_Control.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inventory_Control.utilities
{
    class MessageWindow
    {

        private static string Title { get; set; }
        private static string Content { get; set; }
        /// <summary>
        /// Asigna el tipo de Alerta de la Ventana<br/>
        /// <br/>
        /// 0 - Error<br/>
        /// 1 - Warning<br/>
        /// 2 - Question<br/>
        /// </summary>
        private static int TypeAlert { get; set; }
        public static MessageBoxResult BoxResult { get; set; }


        public static MessageBoxResult ShowWindow(string Content)
        {
            DialogWindow ErrorWindow = new DialogWindow("", Content, MessageBoxImage.None, MessageBoxButton.OK);
            ErrorWindow.ShowDialog();
            return BoxResult;
        }
        public static MessageBoxResult ShowWindow(string Content, string Title)
        {
            DialogWindow ErrorWindow = new DialogWindow(Title, Content, MessageBoxImage.None, MessageBoxButton.OK);
            ErrorWindow.ShowDialog();
            return BoxResult;
        }
        public static MessageBoxResult ShowWindow(string Content, string Title, MessageBoxImage TypeAlert)
        {
            DialogWindow ErrorWindow = new DialogWindow(Title, Content, TypeAlert, MessageBoxButton.OK);
            ErrorWindow.ShowDialog();
            return BoxResult;
        }

        public static MessageBoxResult ShowWindow(string Content, string Title, MessageBoxButton boxButton)
        {
            DialogWindow ErrorWindow = new DialogWindow(Title, Content, MessageBoxImage.None, MessageBoxButton.OK);
            ErrorWindow.ShowDialog();
            return BoxResult;
        }

        public static MessageBoxResult ShowWindow(string Content, string Title, MessageBoxButton boxButton, MessageBoxImage TypeAlert)
        {
            DialogWindow ErrorWindow = new DialogWindow(Title, Content, TypeAlert, boxButton);
            ErrorWindow.ShowDialog();
            return BoxResult;
        }


        public static void GetMessageValues(out string Title, out string Content, out int TypeAlert)
        {
            Title = MessageWindow.Title;
            Content = MessageWindow.Content;
            TypeAlert = MessageWindow.TypeAlert;
        }
    }
}
