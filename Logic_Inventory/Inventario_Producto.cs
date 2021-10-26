using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Inventario_Producto
    {

        public int ID_InventarioP { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }

        public Usuario MiUsuario { get; set; }
        public List<Inv_Prod_Detalle> ProdListaDetalle;

        public Inventario_Producto()
        {
            MiUsuario = new Usuario();
            ProdListaDetalle = new List<Inv_Prod_Detalle>();
        }


        public bool Agregar()
        {
            bool R = false;
            return R;
        }


        public bool Anular()
        {
            bool R = false;
            return R;
        }


        public bool ConsultarPorID()
        {
            bool R = false;
            return R;
        }


        public DataTable ListarTodos()
        {
            DataTable R = new DataTable();
            return R;
        }

    }
}
