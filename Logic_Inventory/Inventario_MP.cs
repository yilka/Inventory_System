using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
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




        public ReportDocument Imprimir(ReportDocument repo)
        {
            ReportDocument R = repo;

            Crystal ObjCrytal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", this.ID_InventarioMP));

            Datos = MiCnn.DMLSelect("SPInventarioMPReporte");

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

            Object Retorno = MyCnn.DMLConRetornoEscalar("SPInventarioMPAgregarEncabezado");
            int IdInventarioRecienCreado;

            if (Retorno != null)
            {
                try
                {
                    IdInventarioRecienCreado = Convert.ToInt32(Retorno.ToString());
                    this.ID_InventarioMP = IdInventarioRecienCreado;
                    int Acumulador = 0;

                    foreach (MP_Detalle item in this.MPListaDetalle)
                    {
                        Conexion MyCnnDetalle = new Conexion();

                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@ID_Materia", item.MiMateria.ID_Materia));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@ID_InventarioMP", this.ID_InventarioMP));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Total", item.Total));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Cantidad", item.Cantidad));

                        MyCnnDetalle.DMLUpdateDeleteInsert("SPInventarioMPAgregarDetalle");

                        Materia_Prima MiMP = new Materia_Prima();
                        MiMP.SumarAStock(item.MiMateria.ID_Materia, item.Cantidad);

                        Acumulador += 1;
                    }
                    if (Acumulador == this.MPListaDetalle.Count)
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
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPInventarioMPListarEnDetalle");
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
