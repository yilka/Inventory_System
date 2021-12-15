using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
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



        public ReportDocument Imprimir(ReportDocument repo)
        {
            ReportDocument R = repo;

            Crystal ObjCrytal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", this.ID_InventarioP));

            Datos = MiCnn.DMLSelect("SPInventarioProdReporte");

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

            Conexion MyCnn = new Conexion();

            MyCnn.ListadoDeParametros.Add(new SqlParameter("@Fecha", this.Fecha));
            MyCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Usuario", this.MiUsuario.ID_Usuario));

            Object Retorno = MyCnn.DMLConRetornoEscalar("SPInventarioProdAgregarEncabezado");
            int IdInventarioRecienCreado;

            if (Retorno != null)
            {
                try
                {
                    IdInventarioRecienCreado = Convert.ToInt32(Retorno.ToString());
                    this.ID_InventarioP = IdInventarioRecienCreado;
                    int Acumulador = 0;

                    foreach (Inv_Prod_Detalle item in this.ProdListaDetalle)
                    {
                        Conexion MyCnnDetalle = new Conexion();

                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@ID_Producto", item.MiProducto.ID_Producto));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@ID_InventarioP", this.ID_InventarioP));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Total", item.Total));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Cantidad", item.Cantidad));

                        MyCnnDetalle.DMLUpdateDeleteInsert("SPInventarioProdAgregarDetalle");

                        Producto MiProd = new Producto();
                        MiProd.SumarAStock(item.MiProducto.ID_Producto, item.Cantidad);

                        Acumulador += 1;
                    }
                    if (Acumulador == this.ProdListaDetalle.Count)
                    {
                        R = true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return R;
        }


        public bool Anular()
        {
            bool R = false;
            try
            {
                Conexion MiCnn = new Conexion();
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_InventarioP));
                int retorno = MiCnn.DMLUpdateDeleteInsert("SPInventarioPAnular");

                Producto MiProduct = new Producto();
                //MiProduct.RestarAStock(item.MiProducto.ID_Producto, item.Cantidad); 

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


        public bool ConsultarPorID()
        {
            bool R = false;

            try
            {
                Conexion MyCnn = new Conexion();
                MyCnn.ListadoDeParametros.Add(new SqlParameter("@Id", this.ID_InventarioP));
                DataTable retorno = MyCnn.DMLSelect("SPInventarioPConsultarPorID");

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
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPInventarioProdListarEnDetalle");
            return R;
        }

        public DataTable AsignarEsquemaDetalle()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPProdDetalleSchema", true);
            R.PrimaryKey = null;
            return R;
        }

    }
}
