using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Materia_Prima
    {
        public int ID_Materia { get; set; }
        public string Nombre { get; set; }
        public string Codigo_Barras { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        //Cambiar cantidad a decimal
        public decimal CantidadEnStock { get; set; }
        public bool Activo { get; set; }

        public MP_Categoria Categoria { get; set; }
        public Proveedor MiProveedor { get; set; }

        public Materia_Prima()
        {
            Categoria = new MP_Categoria();
            MiProveedor = new Proveedor();
            Activo = true;
        }



        public ReportDocument Imprimir(ReportDocument repo)
        {
            ReportDocument R = repo;

            Crystal ObjCrytal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", this.ID_Materia));

            Datos = MiCnn.DMLSelect("SPMateriaReporte");

            if (Datos != null && Datos.Rows.Count > 0)
            {
                ObjCrytal.Datos = Datos;

                R = ObjCrytal.GenerarReporte();
            }

            return R;
        }


        public ReportDocument ImprimirTodos(ReportDocument repo)
        {
            ReportDocument R = repo;

            Crystal ObjCrytal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            Datos = MiCnn.DMLSelect("SPTodasLasMaterias");

            if (Datos != null && Datos.Rows.Count > 0)
            {
                ObjCrytal.Datos = Datos;

                R = ObjCrytal.GenerarReporte();
            }

            return R;
        }




        public bool Agregar()
        {
            bool R = false;

            try
            {
                Conexion MiCnn = new Conexion();

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Precio", this.Precio));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Descripcion", this.Descripcion));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@CantidadEnStock", this.CantidadEnStock));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Activo", this.Activo));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCategoria", this.Categoria.ID_MPCategoria));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDProveedor", this.MiProveedor.ID_Proveedor));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Codigo_Barras", this.Codigo_Barras));

                //En el SP cambiar cantidad a decimal
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPMateriaAgregar");

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

        public bool SumarAStock(int IdMateria, decimal Cantidad)
        {
            bool R = false;
            try
            {
                Conexion MiCnn = new Conexion();

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", IdMateria));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cant", Cantidad));
               

                //En el SP cambiar cantidad a decimal
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPMateriaSumarStock");
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



        public bool RestarAStock(int IdMateria, decimal Cantidad)
        {
            bool R = false;
            try
            {
                Conexion MiCnn = new Conexion();

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", IdMateria));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cant", Cantidad));


                //En el SP cambiar cantidad a decimal
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPMateriaRestarStock");
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

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Materia));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Precio", this.Precio));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Descripcion", this.Descripcion));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@CantidadEnStock", this.CantidadEnStock));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCategoria", this.Categoria.ID_MPCategoria));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDProveedor", this.MiProveedor.ID_Proveedor));

                //En el SP cambiar cantidad a decimal
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPMateriaEditar");
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


        public bool Desactivar()
        {
            bool R = false;
            try
            {
                Conexion MiCnn = new Conexion();
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Materia));
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPMateriaDesactivar");

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



        public bool Activar()
        {
            bool R = false;
            try
            {
                Conexion MiCnn = new Conexion();
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Materia));
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPMateriaActivar");

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


        public Materia_Prima Consultar(int ID_Materia)
        {
            Materia_Prima R = new Materia_Prima();
            Conexion MyCnn = new Conexion();

            MyCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Materia", ID_Materia));

            DataTable DatosMateria = new DataTable();
            DatosMateria = MyCnn.DMLSelect("SPMateriaConsultar");

            if (DatosMateria.Rows.Count > 0)
            {
                DataRow MiFila = DatosMateria.Rows[0];

                R.ID_Materia = Convert.ToInt32(MiFila["ID_Materia"]);
                R.Nombre = Convert.ToString(MiFila["Nombre"]);
                R.Precio = Convert.ToDecimal(MiFila["Precio"]);
                R.Descripcion = Convert.ToString(MiFila["Descripcion"]);
                //Cambiar cantidad a decimal
                R.CantidadEnStock = Convert.ToDecimal(MiFila["CantidadEnStock"]);
                R.Activo = Convert.ToBoolean(MiFila["Activo"]);
                R.Codigo_Barras = Convert.ToString(MiFila["Codigo_Barras"]);
                R.Categoria.ID_MPCategoria = Convert.ToInt32(MiFila["ID_MPCategoria"]);
                R.Categoria.Categoria = Convert.ToString(MiFila["Categoria"]);
                R.MiProveedor.ID_Proveedor = Convert.ToInt32(MiFila["ID_Proveedor"]);
                R.MiProveedor.Nombre = Convert.ToString(MiFila["Nombre"]);
            }
            return R;
        }

        public bool ConsultarPorID()
        {
            bool R = false;

            try
            {
                Conexion MyCnn = new Conexion();
                MyCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Materia));
                DataTable retorno = MyCnn.DMLSelect("SPMateriaConsultarPorID");

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


        public bool ConsultarPorCodigoBarras()
        {
            bool R = false;

            try
            {
                Conexion MyCnn = new Conexion();
                MyCnn.ListadoDeParametros.Add(new SqlParameter("@Codigo_Barras", this.Codigo_Barras));
                DataTable retorno = MyCnn.DMLSelect("SPMateriaConsultarPorCodigo");

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

            R = MyCnn.DMLSelect("SPMateriaListar");
            return R;

        }


        public DataTable ListarEnDetalle()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPMateriaListarEnDetalle");
            return R;
        }


        public DataTable ListarTodos()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPMateriaListarReportes");
            return R;
        }
    }
}
