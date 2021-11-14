using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Inventario_MP
    {
        public int ID_InventarioMP { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }

        public Usuario MiUsuario { get; set; }
        public List<MP_Detalle> MPListaDetalle;

        public Inventario_MP()
        {
            MiUsuario = new Usuario();
            MPListaDetalle = new List<MP_Detalle>();
        }


        public bool Agregar()
        {
            bool R = false;

            Conexion MyCnn = new Conexion();

            MyCnn.ListadoDeParametros.Add(new SqlParameter("@Fecha", this.Fecha));
            MyCnn.ListadoDeParametros.Add(new SqlParameter("@IdUsuario", this.MiUsuario.ID_Usuario));

            Object Retorno = MyCnn.DMLConRetornoEscalar("SPInventarioMPAgregarEncabezado");
            int IdInventarioRecienCreado;

            if (Retorno != null)
            {
                try
                {
                    IdInventarioRecienCreado = Convert.ToInt32(Retorno.ToString());
                    this.ID_InventarioMP = IdInventarioRecienCreado;
                    int Acumulador = 0;

                    foreach(MP_Detalle item in this.MPListaDetalle)
                    {
                        Conexion MyCnnDetalle = new Conexion();

                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@IdMateria", item.MiMateria.ID_Materia));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@IdInventarioMP", this.ID_InventarioMP));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Total", item.Total));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Cantidad", item.Cantidad));

                        MyCnnDetalle.DMLUpdateDeleteInsert("SPInventarioMPAgregarDetalle");

                        Acumulador += 1;
                    }
                    if(Acumulador == this.MPListaDetalle.Count)
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
            R = MyCnn.DMLSelect("SPMPDetalleSchema", true);
            R.PrimaryKey = null;
            return R; 
        }

    }
    }
