using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Usuario_Rol
    {
        public int ID_Rol { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }


        public DataTable Listar()
        {
            DataTable R = new DataTable();
            return R;
        }

    }
}
