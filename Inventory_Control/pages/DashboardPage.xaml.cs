using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection WeeklySales { get; set; }
        public string[] Labels { get; set; }
        public string[] WeeklyLabels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public DashboardPage()
        {
            InitializeComponent();
            CreateGraphics();


        }

        private void CreateGraphics()
        {
            WeeklySales = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Abril 2 - Abril 8",
                    Values = new ChartValues<double> { 10000, 7000, 8000, 9500, 5000, 8500, 12000 }
                }
            };
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2023",
                    Values = new ChartValues<double> { 120000, 130000, 150000, 45000 }
                }
            };


            DataContext = this;
            Labels = new[] { "Enero", "Feberero", "Marzo", "Abril" };
            WeeklyLabels = new[] { "Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" };
            Formatter = value => value.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
        }

      
    }

}
