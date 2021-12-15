using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Logic_Inventory
{
    public class Producto
    {
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public string Codigo_Barras { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEnStock { get; set; }
        public bool Activo { get; set; }

        public Producto_Categoria Categoria { get; set; }
        public Producto_Sabores MiSabor { get; set; }

        public Producto()
        {
            Categoria = new Producto_Categoria();
            MiSabor = new Producto_Sabores();
            Activo = true;
        }




        public ReportDocument Imprimir(ReportDocument repo)
        {
            ReportDocument R = repo;

            Crystal ObjCrytal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", this.ID_Producto));

            Datos = MiCnn.DMLSelect("SPProductoReporte");

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

            Datos = MiCnn.DMLSelect("SPTodosProductos");

            if (Datos != null && Datos.Rows.Count > 0)
            {
                ObjCrytal.Datos = Datos;

                R = ObjCrytal.GenerarReporte();
            }

            return R;
        }



        public ReportDocument ImprimirBolis(ReportDocument repo)
        {
            ReportDocument R = repo;

            Crystal ObjCrytal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            Datos = MiCnn.DMLSelect("SPTodosBolis");

            if (Datos != null && Datos.Rows.Count > 0)
            {
                ObjCrytal.Datos = Datos;

                R = ObjCrytal.GenerarReporte();
            }

            return R;
        }


        public ReportDocument ImprimirPaletas(ReportDocument repo)
        {
            ReportDocument R = repo;

            Crystal ObjCrytal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            Datos = MiCnn.DMLSelect("SPTodosPaletas");

            if (Datos != null && Datos.Rows.Count > 0)
            {
                ObjCrytal.Datos = Datos;

                R = ObjCrytal.GenerarReporte();
            }

            return R;
        }



        public ReportDocument ImprimirPalillo(ReportDocument repo)
        {
            ReportDocument R = repo;

            Crystal ObjCrytal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            Datos = MiCnn.DMLSelect("SPTodosPalillo");

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
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCategoria", this.Categoria.ID_PCategoria));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDSabor", this.MiSabor.ID_Sabores));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Codigo_Barras", this.Codigo_Barras));

                int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoAgregar");

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

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Producto));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", this.Nombre));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Precio", this.Precio));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Descripcion", this.Descripcion));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@CantidadEnStock", this.CantidadEnStock));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCategoria", this.Categoria.ID_PCategoria));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDSabor", this.MiSabor.ID_Sabores));


                int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoEditar");
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
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Producto));
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoDesactivar");

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
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Producto));
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoActivar");

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


        public Producto Consultar(int ID_Producto)
        {
            Producto R = new Producto();
            Conexion MyCnn = new Conexion();

            MyCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Producto", ID_Producto));

            DataTable DatosProducto = new DataTable();
            DatosProducto = MyCnn.DMLSelect("SPProductoConsultar");

            if (DatosProducto.Rows.Count > 0)
            {
                DataRow MiFila = DatosProducto.Rows[0];

                R.ID_Producto = Convert.ToInt32(MiFila["ID_Producto"]);
                R.Nombre = Convert.ToString(MiFila["Nombre"]);
                R.Precio = Convert.ToDecimal(MiFila["Precio"]);
                R.Descripcion = Convert.ToString(MiFila["Descripcion"]);
                R.CantidadEnStock = Convert.ToInt32(MiFila["CantidadEnStock"]);
                R.Activo = Convert.ToBoolean(MiFila["Activo"]);
                R.Codigo_Barras = Convert.ToString(MiFila["Codigo_Barras"]);
                R.Categoria.ID_PCategoria = Convert.ToInt32(MiFila["ID_PCategoria"]);
                R.Categoria.Categoria = Convert.ToString(MiFila["Categoria"]);
                R.MiSabor.ID_Sabores = Convert.ToInt32(MiFila["ID_Sabores"]);
                R.MiSabor.Sabor = Convert.ToString(MiFila["Sabor"]);
            }
            return R;
        }

        public bool ConsultarPorID()
        {
            bool R = false;

            try
            {
                Conexion MyCnn = new Conexion();
                MyCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_Producto));
                DataTable retorno = MyCnn.DMLSelect("SPProductoConsultarPorID");

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
                DataTable retorno = MyCnn.DMLSelect("SPProductoConsultarPorCodigo");

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

            R = MyCnn.DMLSelect("SPProductoListar");
            return R;

        }


        public DataTable ListarEnDetalle()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPProductoListarEnDetalle");
            return R;
        }


        public DataTable ListarTodos()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPProductoListarReportes");
            return R;
        }


        public bool SumarAStock(int IdMateria, int Cantidad)
        {
            bool R = false;
            try
            {
                Conexion MiCnn = new Conexion();

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", IdMateria));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cant", Cantidad));



                int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoSumarStock");
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



        public bool RestarAStock(int IdMateria, int Cantidad)
        {
            bool R = false;
            try
            {
                Conexion MiCnn = new Conexion();

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", IdMateria));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cant", Cantidad));



                int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoRestarStock");
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

    }
}
