using BDProjeto.aplicacao;
using BDProjeto.Dominio;
using System;
using System.Data.SqlClient;

namespace DOS

{
    public class Program
    {
        static void Main(string[] args)
        {

            var app = UsuarioAplicacaoConstrutor.UsuarioApADO();

            SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-CB92455\SQLEXPRESS;Initial Catalog=ExemploBD;User ID=sa;Password=123123");             
            conexao.Open();

            //string sqlUPDATE = "UPDATE usuarios SET nome = 'fabio' WHERE usuarioId = 1";
            //SqlCommand cmdUPDATE = new SqlCommand(sqlUPDATE, conexao);
            //cmdUPDATE.ExecuteNonQuery();

            //string sqlDELETE = "DELETE usuarios WHERE usuarioId = 1";
            //SqlCommand cmdDELETE = new SqlCommand(sqlDELETE, conexao);
            //cmdDELETE.ExecuteNonQuery();

            Console.Write("Digite o nome do usuario: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o cargo do usuario: ");
            string cargo = Console.ReadLine();

            Console.Write("Digite a data do cadastro: ");
            string data = Console.ReadLine();

            var usuarios = new Usuarios() {

                Nome = nome,  //o campo nome da minha entidade vai receber o nome q vem do console
                Cargo = cargo, //o campo cargo da minha entidade vai receber o cargo q vem do console
               Data = DateTime.Parse(data)  //o campo data da minha entidade vai receber o data q vem do console
            };

            //usuarios.Id = 9;

            app.Salvar(usuarios); //se tiver id ele altera, se nao tiver ele salva
            //new UsuarioAplicacao().Excluir(9);


            var dados = app.ListarTodos();
            //executereader ele faz uma consulta e retorna o valor da tabela

            foreach (var usuario in dados)
            {
                Console.WriteLine("Id:{0}, Nome: {1}, Cargo: {2}, Data: {3}", usuario.Id, usuario.Nome, usuario.Cargo, usuario.Data);
            }
             
        }
    }
}