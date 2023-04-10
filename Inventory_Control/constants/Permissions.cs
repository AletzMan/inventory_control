using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Control.constants
{
    public class Permissions : ObservableCollection<string>
    {
        public Permissions()
        {
            Add("Administrador");
            Add("Encargado");
            Add("Empleado");
        }
    }
}
