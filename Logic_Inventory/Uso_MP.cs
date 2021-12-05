using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Uso_MP
    {
        public int ID_Uso { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public bool Activo { get; set; }

        public Usuario MiUsuario { get; set; }
        public List<Uso_Detalle> UsoListaDetalle;

        public Uso_MP()
        {
            MiUsuario = new Usuario();
            UsoListaDetalle = new List<Uso_Detalle>();
        }


        public ReportDocument Imprimir(ReportDocument repo)
        {
            ReportDocument R = repo;

            Crystal ObjCrytal = new Crystal(R);

            DataTable Datos = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", this.ID_Uso));

            Datos = MiCnn.DMLSelect("SPUsoReporte");

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
            MyCnn.ListadoDeParametros.Add(new SqlParameter("@Detalle", this.Detalle));

            Object Retorno = MyCnn.DMLConRetornoEscalar("SPUsoAgregarEncabezado");
            int IdUsoRecienCreado;

            if (Retorno != null)
            {
                try
                {
                    IdUsoRecienCreado = Convert.ToInt32(Retorno.ToString());
                    this.ID_Uso = IdUsoRecienCreado;
                    int Acumulador = 0;

                    foreach (Uso_Detalle item in this.UsoListaDetalle)
                    {
                        Conexion MyCnnDetalle = new Conexion();

                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@ID_Materia", item.MiMateria.ID_Materia));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@ID_Uso", this.ID_Uso));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Total", item.Total));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Cantidad", item.Cantidad));

                        MyCnnDetalle.DMLUpdateDeleteInsert("SPUsoAgregarDetalle");

                        Materia_Prima MiMat = new Materia_Prima();
                        MiMat.RestarAStock(item.MiMateria.ID_Materia, item.Cantidad);

                        Acumulador += 1;
                    }
                    if (Acumulador == this.UsoListaDetalle.Count)
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
            R = MyCnn.DMLSelect("SPUsosListarEnDetalle");
            return R;
        }

        public DataTable AsignarEsquemaDetalle()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPUsoDetalleSchema", true);
            R.PrimaryKey = null;
            return R;
        }

    }
}
