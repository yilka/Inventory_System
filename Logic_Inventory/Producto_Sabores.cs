using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Producto_Sabores
    {
        public int ID_Sabores { get; set; }
        public string Sabor { get; set; }



        public DataTable Listar()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPSaboresListar");
            return R;
        }
    }
}
