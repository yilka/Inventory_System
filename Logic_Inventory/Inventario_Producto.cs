using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            R = MyCnn.DMLSelect("SPProdDetalleSchema", true);
            R.PrimaryKey = null;
            return R;
        }

    }
}
