using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

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


        public ReportDocument Imprimir(ReportDocument repo)
        {
            ReportDocument R = repo;

            Crystal ObjCrytal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", this.ID_Pedido));

            Datos = MiCnn.DMLSelect("SPPedidoReporte");

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
            MyCnn.ListadoDeParametros.Add(new SqlParameter("@Cliente", this.Nombre_Cliente));

            Object Retorno = MyCnn.DMLConRetornoEscalar("SPPedidoAgregarEncabezado");
            int IdInventarioRecienCreado;

            if (Retorno != null)
            {
                try
                {
                    IdInventarioRecienCreado = Convert.ToInt32(Retorno.ToString());
                    this.ID_Pedido = IdInventarioRecienCreado;
                    int Acumulador = 0;

                    foreach (Pedido_Detalle item in this.PedListaDetalle)
                    {
                        Conexion MyCnnDetalle = new Conexion();

                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@ID_Producto", item.MiProducto.ID_Producto));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@ID_Pedido", this.ID_Pedido));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Total", item.Total));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Cantidad", item.Cantidad));

                        MyCnnDetalle.DMLUpdateDeleteInsert("SPPedidoAgregarDetalle");

                        Producto MiProd = new Producto();
                        MiProd.RestarAStock(item.MiProducto.ID_Producto, item.Cantidad);

                        Acumulador += 1;
                    }
                    if (Acumulador == this.PedListaDetalle.Count)
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


        public DataTable AsignarEsquemaDetalle()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPPedidoDetalleSchema", true);
            R.PrimaryKey = null;
            return R;
        } 

    }
}
