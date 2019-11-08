using BDProjeto.Dominio;
using BDProjeto.Dominio.contrato;
using BDProjeto.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.RepositorioADO

{
    public class UsuarioAplicacaoADO:IRepositorio<Usuarios>

    {
        private bd bd;

        private void Inserir(Usuarios usuarios)
        {
            var sql = "";
            sql += "INSERT INTO usuarios(nome, cargo, data)";
            sql += string.Format("VALUES('{0}','{1}','{2}')", usuarios.Nome, usuarios.Cargo, usuarios.Data
            );
            
            using (bd = new bd())
            {
                bd.ExecutarComando(sql);
            }
        }

        private void Alterar(Usuarios usuarios)
        {
            var sql = "";
            sql += "UPDATE usuarios SET ";
            sql += string.Format("nome = '{0}',", usuarios.Nome);
            sql += string.Format("cargo = '{0}',", usuarios.Cargo);
            sql += string.Format("data = '{0}'", usuarios.Data);
            sql += string.Format("WHERE Id = {0} ", usuarios.Id);

            using (bd = new bd())
            {
                bd.ExecutarComando(sql);
            }
        }

        public void Salvar(Usuarios usuarios)
        {
            if (usuarios.Id > 0)
            {
                Alterar(usuarios);
            }
            else
            {
                Inserir(usuarios);
            }
        }

        public void Excluir(Usuarios usuario)
        {
            using (bd = new bd())
            {
                var sql = string.Format(" DELETE FROM usuarios WHERE Id = {0}", usuario.Id);
                  
                bd.ExecutarComando(sql);
            }
        }

        public IEnumerable<Usuarios> ListarTodos()
        {
            var bd = new bd();

            var sql = "SELECT * FROM usuarios";
            var retorno = bd.ExecutaComandoComRetorno(sql);
            return ReaderEmLista(retorno);
        }

        public Usuarios ListarPorId(string id)
        {
            var bd = new bd();

            var sql = string.Format("SELECT * FROM usuarios WHERE Id = {0}", id);
            var retorno = bd.ExecutaComandoComRetorno(sql);
            return ReaderEmLista(retorno).FirstOrDefault();
        }

        private List<Usuarios>ReaderEmLista(SqlDataReader reader)
        {
            var usuarios = new List<Usuarios>();
            while (reader.Read()) //para funcionar no reader, todos objetos tem q ser string
            {
                var tempoObjeto = new Usuarios()
                {
                    Id = int.Parse(reader["Id"].ToString()), //informando que meu campo Id, vai receber o Id do meu banco
                    Nome = reader["nome"].ToString(),
                    Cargo = reader["cargo"].ToString(),
                    Data = DateTime.Parse(reader["data"].ToString())                  
                };
                usuarios.Add(tempoObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}
