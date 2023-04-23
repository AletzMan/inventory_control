using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Control.constants
{
    public class StatesNames : ObservableCollection<string>
    {
        public StatesNames()
        {
            Add("Aguascalientes");
            Add("Baja California");
            Add("Baja California Sur");
            Add("Campeche");
            Add("Coahuila");
            Add("Colima");
            Add("Chiapas");
            Add("Chihuahua");
            Add("Ciudad de Mexico");
            Add("Durango");
            Add("Guanajuato");
            Add("Guerrero");
            Add("Hidalgo");
            Add("Jalisco");
            Add("Estado de Mexico");
            Add("Michoacan");
            Add("Morelos");
            Add("Nayarit");
            Add("Nuevo Leon");
            Add("Oaxaca");
            Add("Puebla");
            Add("Queretaro");
            Add("Quintana Roo");
            Add("San Luis Potosi");
            Add("Sinaloa");
            Add("Sonora");
            Add("Tabasco");
            Add("Tamaulipas");
            Add("Tlaxcala");
            Add("Veracruz");
            Add("Yucatan");
            Add("Zacatecas");
        }
    }
}
