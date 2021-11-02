using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Logic_Inventory
{
    public class Conexion
    {
        String CadenaDeConexion { get; set; }


        public List<SqlParameter> ListadoDeParametros = new List<SqlParameter>();

        public int DMLUpdateDeleteInsert(String NombreSP)
        {
            int Retorno = 0;

            using (SqlConnection MyCnn = new SqlConnection(CadenaDeConexion))

            {
                SqlCommand MyComando = new SqlCommand(NombreSP, MyCnn);
                MyComando.CommandType = CommandType.StoredProcedure;

                if (ListadoDeParametros != null && ListadoDeParametros.Count > 0)
                {
                    foreach (SqlParameter item in ListadoDeParametros)
                    {
                        MyComando.Parameters.Add(item);
                    }
                }

                MyCnn.Open();

                Retorno = MyComando.ExecuteNonQuery();
            }

            return Retorno;
        }

        public DataTable DMLSelect(String NombreSP, bool CargarEsquemaDeTabla = false)
        {
            DataTable Retorno = new DataTable();

            using (SqlConnection MyCnn = new SqlConnection(CadenaDeConexion))
            {
                SqlCommand MyComando = new SqlCommand(NombreSP, MyCnn);
                MyComando.CommandType = CommandType.StoredProcedure;
                if (ListadoDeParametros != null && ListadoDeParametros.Count > 0)
                {
                    foreach (SqlParameter item in ListadoDeParametros)
                    {
                        MyComando.Parameters.Add(item);
                    }
                }
                SqlDataAdapter MyAdaptador = new SqlDataAdapter(MyComando);

                if (CargarEsquemaDeTabla)
                {
                    MyAdaptador.FillSchema(Retorno, SchemaType.Source);
                }
                else
                {
                    MyAdaptador.Fill(Retorno);
                }
            }
            return Retorno;
        }

        public Object DMLConRetornoEscalar(String NombreSP)
        {
            Object Retorno = null;
            using (SqlConnection MyCnn = new SqlConnection(CadenaDeConexion))

            {
                SqlCommand MyComando = new SqlCommand(NombreSP, MyCnn);
                MyComando.CommandType = CommandType.StoredProcedure;

                if (ListadoDeParametros != null && ListadoDeParametros.Count > 0)
                {
                    foreach (SqlParameter item in ListadoDeParametros)
                    {
                        MyComando.Parameters.Add(item);
                    }
                }
                MyCnn.Open();
                Retorno = MyComando.ExecuteScalar();
            }

            return Retorno;
        }

        public Conexion()
        {
            this.CadenaDeConexion = ConfigurationManager.ConnectionStrings["CNNSTR"].ToString();
        }
    }
}
