using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Proveedor
    {
        public int ID_Proveedor { get; set; }
        public string Nombre { get; set; }
        public string Cedula_juridica { get; set; }
        public string Email { get; set; }
        public string Contacto_Directo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }


        public bool Agregar()
        {
            bool R = false;
            return R;
        }


        public bool Editar()
        {
            bool R = false;
            return R;
        }


        public bool Desactivar()
        {
            bool R = false;
            return R;
        }


        public bool ConsultarPorID()
        {
            bool R = false;
            return R;
        }


        public bool ConsultarPorCedula()
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
