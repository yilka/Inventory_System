using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Pedido
    {

        public int ID_Pedido { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre_Cliente { get; set; }
        public bool Activo { get; set; }

        public Usuario MiUsuario { get; set; }
        public List<Pedido_Detalle> PedListaDetalle;

        public Pedido()
        {
            MiUsuario = new Usuario();
            PedListaDetalle = new List<Pedido_Detalle>();
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
