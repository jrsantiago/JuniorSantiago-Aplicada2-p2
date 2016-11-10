using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
   public class DbConexion
    {
       
            private SqlConnection conect;
            private SqlCommand comand;

            public DbConexion()
            {
                conect = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDb"].ConnectionString);
                comand = new SqlCommand();
            }
            public bool Ejecutar(String ComandoSql)
            {
                bool retorno = false;

                try
                {
                    conect.Open();
                    comand.Connection = conect;
                    comand.CommandText = ComandoSql;
                    comand.ExecuteNonQuery();
                    retorno = true;

                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    conect.Close();
                }
                return retorno;
            }
            public DataTable ObtenerDatos(String ComandoSql)
            {
                SqlDataAdapter adapter;
                DataTable dt = new DataTable();

                try
                {
                    conect.Open();
                    comand.Connection = conect;
                    comand.CommandText = ComandoSql;

                    adapter = new SqlDataAdapter(comand);
                    adapter.Fill(dt);

                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    conect.Close();
                }
                return dt;
            }
            public Object ObtenerValor(String comandoSql)
            {
                Object retorno = null;
                try
                {
                    conect.Open();
                    comand.Connection = conect;
                    comand.CommandText = comandoSql;
                    retorno = comand.ExecuteScalar();


                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    conect.Close();
                }
                return retorno;
            }

        }
    
}
