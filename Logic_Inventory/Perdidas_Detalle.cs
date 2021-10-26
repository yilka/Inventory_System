using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Inventory
{
    public class Perdidas_Detalle
    {
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public Producto MiProducto { get; set; }

        public Perdidas_Detalle()
        {
            MiProducto = new Producto();
        }
    }
}
