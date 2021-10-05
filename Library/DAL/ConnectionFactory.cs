using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ConnectionFactory
    {
        private static string nomeConexao = "ConexaoCasaVini";
        private static string strConexao = ConfigurationManager.ConnectionStrings["ConexaoCasaVini"].ConnectionString.ToString();

        public static string NomeConexao { get => nomeConexao; set => nomeConexao = value; }
        public static string StrConexao { get => strConexao; set => strConexao = value; }

        public bool TestarConexao()
        {
            bool conectado = false;

            try
            {
                using (SqlConnection con = new SqlConnection(StrConexao))
                {
                    con.Open();
                    conectado = (con.State == System.Data.ConnectionState.Open);
                    con.Close();
                    return conectado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao estabelecer a conexão: " + ex.Message);
            }
        }
    }
}
