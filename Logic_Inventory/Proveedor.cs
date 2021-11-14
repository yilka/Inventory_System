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
        public string Cedula_Juridica { get; set; }
        public string Email { get; set; }
        public string Contacto_Directo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }


        public bool Agregar()
        {
            bool R = false;

            try
            {
                Conexion MiCnn = new Conexion();

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cedula_Juridica", this.Cedula_Juridica));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Email", this.Email));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Contacto_Directo", this.Contacto_Directo));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Direccion", this.Direccion));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Activo", this.Activo));

                int retorno = MiCnn.DMLUpdateDeleteInsert("SPProveedorAgregar");

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


        public bool Editar()
        {
            bool R = false;
            try
            {
                Conexion MiCnn = new Conexion();

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Proveedor));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Email", this.Email));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Contacto_Directo", this.Contacto_Directo));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Direccion", this.Direccion));

                int retorno = MiCnn.DMLUpdateDeleteInsert("SPProveedorEditar");
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
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Proveedor));
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
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Proveedor));
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPProveedorActivar");

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



        public Proveedor Consultar(int pIDProveedor)
        {
            Proveedor R = new Proveedor();
            Conexion MyCnn = new Conexion();

            MyCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Proveedor", pIDProveedor));

            DataTable DatosProveedor = new DataTable();
            DatosProveedor = MyCnn.DMLSelect("SPProveedorConsultar");

            if(DatosProveedor.Rows.Count > 0)
            {
                DataRow MiFila = DatosProveedor.Rows[0];

                R.ID_Proveedor = Convert.ToInt32(MiFila["ID_Proveedor"]);
                R.Nombre = Convert.ToString(MiFila["Nombre"]);
                R.Cedula_Juridica = Convert.ToString(MiFila["Cedula_Juridica"]);
                R.Email = Convert.ToString(MiFila["Email"]);
                R.Contacto_Directo = Convert.ToString(MiFila["Contacto_Directo"]);
                R.Telefono = Convert.ToString(MiFila["Telefono"]);
                R.Direccion = Convert.ToString(MiFila["Direccion"]);
                R.Activo = Convert.ToBoolean(MiFila["Activo"]);
            }
            return R;
        }



        public bool ConsultarPorID()
        {
            bool R = false;

            try
            {
                Conexion MyCnn = new Conexion();
                MyCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Proveedor));
                DataTable retorno = MyCnn.DMLSelect("SPProveedorConsultarPorID");

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


        public bool ConsultarPorCedula()
        {
            bool R = false;

            try
            {
                Conexion MyCnn = new Conexion();
                MyCnn.ListadoDeParametros.Add(new SqlParameter("@Cedula_Juridica", this.Cedula_Juridica));
                DataTable retorno = MyCnn.DMLSelect("SPProveedorConsultarPorCedula");

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


        public DataTable Listar(bool VerActivos = true, string Filtro = "")
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();

            MyCnn.ListadoDeParametros.Add(new SqlParameter("@VerActivos", VerActivos));
            MyCnn.ListadoDeParametros.Add(new SqlParameter("@Filtro", Filtro));

            R = MyCnn.DMLSelect("SPProveedorListar");
            return R;

        }


        public DataTable ListarCombo()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPProveedorListarCombo");
            return R;
        }

        public DataTable ListarTodos()
        {
            DataTable R = new DataTable();
            Conexion MiConexion = new Conexion();
            R = MiConexion.DMLSelect("SPProveedorListarTodos");
            return R;
        }

    }
}
