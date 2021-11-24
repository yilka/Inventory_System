﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Logic_Inventory
{
    public class Perdidas
    {
        public int ID_Perdida { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public bool Activo { get; set; }

        public Usuario MiUsuario { get; set; }
        public List<Perdidas_Detalle> PerdListaDetalle;

        public Perdidas()
        {
            MiUsuario = new Usuario();
            PerdListaDetalle = new List<Perdidas_Detalle>();
        }


        public bool Agregar()
        {
            bool R = false;

            Conexion MyCnn = new Conexion();

            MyCnn.ListadoDeParametros.Add(new SqlParameter("@Fecha", this.Fecha));
            MyCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Usuario", this.MiUsuario.ID_Usuario));
            MyCnn.ListadoDeParametros.Add(new SqlParameter("@Detalle", this.Detalle));

            Object Retorno = MyCnn.DMLConRetornoEscalar("SPPerdidaAgregarEncabezado");
            int IdInventarioRecienCreado;

            if (Retorno != null)
            {
                try
                {
                    IdInventarioRecienCreado = Convert.ToInt32(Retorno.ToString());
                    this.ID_Perdida = IdInventarioRecienCreado;
                    int Acumulador = 0;

                    foreach (Perdidas_Detalle item in this.PerdListaDetalle)
                    {
                        Conexion MyCnnDetalle = new Conexion();

                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@ID_Producto", item.MiProducto.ID_Producto));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@ID_Perdidas", this.ID_Perdida));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Total", item.Total));
                        MyCnnDetalle.ListadoDeParametros.Add(new SqlParameter("@Cantidad", item.Cantidad));

                        MyCnnDetalle.DMLUpdateDeleteInsert("SPPerdidaAgregarDetalle");

                        Acumulador += 1;
                    }
                    if (Acumulador == this.PerdListaDetalle.Count)
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
            R = MyCnn.DMLSelect("SPPerdiaDetalleSchema", true);
            R.PrimaryKey = null;
            return R;
        }

    }
}
