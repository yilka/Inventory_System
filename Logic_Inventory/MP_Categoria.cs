using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class MP_Categoria
    {
        public int ID_MPCategoria { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }

        public DataTable Listar()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPMPCategoriaListar");
            return R;
        }
    }
}
