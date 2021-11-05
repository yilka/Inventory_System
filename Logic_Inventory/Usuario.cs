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

            try
            {
                Conexion MiCnn = new Conexion();
                Crypto MiEncriptador = new Crypto();

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cedula", this.Cedula));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Direccion", this.Direccion));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Email", this.Email));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@UserName", this.UserName));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDRol", this.Rol.ID_Rol));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Activo", this.Activo));

                string MiPasswordEncriptado = MiEncriptador.EncriptarEnUnSentido(this.Contrasena);
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Pass", MiPasswordEncriptado));

                int retorno = MiCnn.DMLUpdateDeleteInsert("SPUsuarioAgregar");

                if(retorno > 0)
                {
                    R = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return R;
        }



        public bool Editar()
        {
            bool R = false;

            try
            {
                Conexion MiCnn = new Conexion();
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Usuario));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Direccion", this.Direccion));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Email", this.Email));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@UserName", this.UserName));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDRol", this.Rol.ID_Rol));
              

                Crypto MiEncriptador = new Crypto();
                string PasswordEncriptado = "";

                if (!string.IsNullOrEmpty(this.Contrasena))
                {
                    PasswordEncriptado = MiEncriptador.EncriptarEnUnSentido(this.Contrasena);
                }
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Pass", PasswordEncriptado));
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPUsuarioEditar");

                if(retorno > 0)
                {
                    R = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return R;
        }


        public bool Desactivar()
        {
            bool R = false;
            try
            {
                Conexion MiCnn = new Conexion();
                MiCnn.ListadoDeParametros.Add(new SqlParameter("Id", this.ID_Usuario));

                int retorno = MiCnn.DMLUpdateDeleteInsert("SPUsuarioDesactivar");
                if(retorno > 0)
                {
                    R = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return R;
        }


        public bool Activar()
        {
            bool R = false;
            try
            {
                Conexion MiCnn = new Conexion();
                MiCnn.ListadoDeParametros.Add(new SqlParameter("Id", this.ID_Usuario));

                int retorno = MiCnn.DMLUpdateDeleteInsert("SPUsuarioActivar");
                if (retorno > 0)
                {
                    R = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return R;
        }




      public Usuario Consultar(int pID_Usuario)
        {
            Usuario R = new Usuario();
            Conexion MyCnn = new Conexion();

            MyCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Usuario", pID_Usuario));

            DataTable DatosUsuario = new DataTable();
            DatosUsuario = MyCnn.DMLSelect("SPUsuarioConsultar");

            if(DatosUsuario.Rows.Count > 0)
            {
                DataRow MiFila = DatosUsuario.Rows[0];

                R.ID_Usuario = Convert.ToInt32(MiFila["ID_Usuario"]);
                R.Nombre = Convert.ToString(MiFila["Nombre"]);
                R.Cedula = Convert.ToString(MiFila["Cedula"]);
                R.Telefono = Convert.ToString(MiFila["Telefono"]);
                R.Direccion = Convert.ToString(MiFila["Direccion"]);
                R.Email = Convert.ToString(MiFila["Email"]);
                R.UserName = Convert.ToString(MiFila["UserName"]);
                R.Contrasena = Convert.ToString(MiFila["Contrasena"]);
                R.Activo = Convert.ToBoolean(MiFila["Activo"]);
                R.Rol.ID_Rol = Convert.ToInt32(MiFila["ID_Rol"]);
                R.Rol.Rol = Convert.ToString(MiFila["Rol"]);
            }
            return R;
        }

        public bool ConsultarPorID()
        {
            bool R = false;

            try
            {
                Conexion MyCnn = new Conexion();
                MyCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Usuario));
                DataTable retorno = MyCnn.DMLSelect("SPUsuarioConsultarPorID");

                if(retorno.Rows.Count > 0)
                {
                    R = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return R;
        }


      public bool ConsultarPorCedula()
        {
            bool R = false;

            try
            {
                Conexion MyCnn = new Conexion();
                MyCnn.ListadoDeParametros.Add(new SqlParameter("@Cedula", this.Cedula));
                DataTable retorno = MyCnn.DMLSelect("SPUsuarioConsultarPorCedula");

                if(retorno.Rows.Count > 0)
                {
                    R = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return R;
        }


       public bool ConsultarPorUserName()
        {
            bool R = false;

            try
            {
                Conexion MyCnn = new Conexion();
                MyCnn.ListadoDeParametros.Add(new SqlParameter("@UserName", this.Cedula));
                DataTable retorno = MyCnn.DMLSelect("SPUsuarioConsultarPorUserName");

                if (retorno.Rows.Count > 0)
                {
                    R = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return R;
        }



        public DataTable ListarTodos()
        {
            DataTable R = new DataTable();
            Conexion MiConexion = new Conexion();
            R = MiConexion.DMLSelect("SPUsuariosListarTodos");
            return R;
        }

        public DataTable Listar(bool VerActivos = true, string Filtro = "")
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();

            MyCnn.ListadoDeParametros.Add(new SqlParameter("@VerActivos", VerActivos));
            MyCnn.ListadoDeParametros.Add(new SqlParameter("@Filtro", Filtro));

            R = MyCnn.DMLSelect("SPUsuariosListar");
            return R;

        }


        public int ValidarLogIn(string pUsuario, string pPassword)
        {
            int R = 0;

            this.UserName = pUsuario;
            this.Contrasena = pPassword;

            Crypto MiEncriptador = new Crypto();

            string PasswordEncriptado = MiEncriptador.EncriptarEnUnSentido(this.Contrasena);

            Conexion MyCnn = new Conexion();

            MyCnn.ListadoDeParametros.Add(new SqlParameter("@User", this.UserName));
            MyCnn.ListadoDeParametros.Add(new SqlParameter("@Pass", PasswordEncriptado));

            DataTable respuesta = MyCnn.DMLSelect("SPUsuarioValidarLogin");

            if(respuesta != null && respuesta.Rows.Count > 0)
            {
                DataRow MiFila = respuesta.Rows[0];
                R = Convert.ToInt32(MiFila["ID_Usuario"]);
            }
            return R;
        }
    }
}
