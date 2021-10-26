using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Logic_Inventory
{
    public class Perdidas
    {
        public int ID_Perdida { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public bool Activo { get; set; }

        public Usuario MiUsuario { get; set; }
        public List<Perdidas_Detalle> PerdListaDetalle;

        public Perdidas()
        {
            MiUsuario = new Usuario();
            PerdListaDetalle = new List<Perdidas_Detalle>();
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
