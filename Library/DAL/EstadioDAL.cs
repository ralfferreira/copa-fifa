using Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class EstadioDAL
    {
        public int Insert(Estadio e)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TB_ESTADIO ");
                sql.AppendLine("(DS_ESTADIO, DS_CIDADE, DS_CAPACIDADE) ");
                sql.AppendLine("VALUES (@DS_ESTADIO, @DS_CIDADE, @DS_CAPACIDADE) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY();");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DS_ESTADIO", e.Nome);
                    cmd.Parameters.AddWithValue("@DS_CIDADE", e.Cidade);
                    cmd.Parameters.AddWithValue("@DS_CAPACIDADE", e.Capacidade);

                    con.Open();
                    e.Id = Convert.ToInt32(cmd.ExecuteNonQuery());
                    con.Close();
                }
                return reg;
            }
        }

        public List<Estadio> GetAll()
        {
            List<Estadio> listaEstadios = new List<Estadio>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT e.ID_ESTADIO, e.DS_ESTADIO, e.DS_CIDADE, e.DS_CAPACIDADE ");
                sql.AppendLine("FROM TB_ESTADIO e");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Estadio e = new Estadio();

                                e.Id = Convert.ToInt32(dr["ID_ESTADIO"]);
                                e.Nome = dr["DS_ESTADIO"].ToString();
                                e.Cidade = dr["DS_CIDADE"].ToString();
                                e.Capacidade = Convert.ToInt32(dr["DS_CAPACIDADE"]);

                                listaEstadios.Add(e);
                            }
                        }

                        return listaEstadios;
                    }
                }
            }
        }

        public Estadio GetById(int id)
        {
            Estadio e = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT e.ID_ESTADIO, e.DS_ESTADIO, e.DS_CIDADE, e.DS_CAPACIDADE ");
                sql.AppendLine("FROM TB_ESTADIO e ");
                sql.AppendLine("WHERE e.ID_ESTADIO = @ID_ESTADIO");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@ID_ESTADIO", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                e = new Estadio();

                                e.Id = Convert.ToInt32(dr["ID_ESTADIO"]);
                                e.Nome = dr["DS_ESTADIO"].ToString();
                                e.Cidade = dr["DS_CIDADE"].ToString();
                                e.Capacidade = Convert.ToInt32(dr["DS_CAPACIDADE"]);
                            }
                        }

                        return e;
                    }
                }
            }
        }

        public int Update(Estadio e)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("UPDATE TB_ESTADIO SET ");
                sql.AppendLine("DS_ESTADIO = @DS_ESTADIO, ");
                sql.AppendLine("DS_CIDADE = @DS_CIDADE, ");
                sql.AppendLine("DS_CAPACIDADE = @DS_CAPACIDADE ");
                sql.AppendLine("WHERE ID_ESTADIO = @ID_ESTADIO");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DS_ESTADIO", e.Nome);
                    cmd.Parameters.AddWithValue("@DS_CIDADE", e.Cidade);
                    cmd.Parameters.AddWithValue("@DS_CAPACIDADE", e.Capacidade);
                    cmd.Parameters.AddWithValue("@ID_ESTADIO", e.Id);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }

                return linhasAfetadas;
            }
        }

        public int Delete(int id)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.StrConexao))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("DELETE FROM TB_ESTADIO ");
                sql.AppendLine("WHERE ID_ESTADIO = @ID_ESTADIO ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_ESTADIO", id);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }

                return linhasAfetadas;
            }
        }
    }
}
