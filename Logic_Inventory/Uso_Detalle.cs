using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Inventory
{
    public class Uso_Detalle
    {
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public Materia_Prima MiMateria { get; set; }

        public Uso_Detalle()
        {
            MiMateria = new Materia_Prima();
        }
    }
}
