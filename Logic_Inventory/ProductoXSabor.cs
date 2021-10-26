using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Inventory
{
    public class ProductoXSabor
    {
        public Producto Producto{ get; set; }
        public Producto_Sabores Sabores { get; set; }


        public ProductoXSabor()
        {
            Producto = new Producto();
            Sabores = new Producto_Sabores();
        }
    }
}
