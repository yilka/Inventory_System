using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }


        public Usuario_Rol Rol {get; set;}

        public Usuario()
        {
            Rol = new Usuario_Rol();
            Activo = true;
        }

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


      public Usuario Consultar(int ID_Usuario)
        {
            Usuario R = new Usuario();
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

        public DataTable ListarInactivos()
        {
            DataTable R = new DataTable();
            return R;
        }


        public bool ValidarLogIn()
        {
            bool R = false;
            return R;
        }

    }
}
