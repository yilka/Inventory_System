using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Producto_Categoria
    {
        public int ID_PCategoria { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }

        public DataTable Listar()
        {
            DataTable R = new DataTable();
            return R;
        }
    }
}
