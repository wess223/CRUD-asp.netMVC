using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.Repositorio
{
    public class bd : IDisposable
    {
        private readonly SqlConnection conexao;

        public bd()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXAOBD"].ConnectionString);
            conexao.Open();
        }

        public void ExecutarComando(string sql)
        {
            var cmd = new SqlCommand
            {
                CommandText = sql, //consulta no banco
                CommandType = CommandType.Text, //para executar a minha consulta
                Connection = conexao  //conexao com o banco
            };
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoComRetorno(string sql)
        {
            var cmdComandoSelect = new SqlCommand(sql, conexao);
            return cmdComandoSelect.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
