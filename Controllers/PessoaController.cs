using BrunoTeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BrunoTeste.Controllers
{
    public class PessoaController : BaseController
    {
        private int _id = 0;

        public ActionResult Index()
        {
            if (_logado)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(PessoaViewModel model)
        {
            var connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BrunoTeste;Integrated Security=True");
            connection.Open();

            CadastrarPessoa(model, connection);

            foreach (var endereco in model.Enderecos)
            {
                CadastrarEndereco(endereco, connection);
            }

            foreach (var contato in model.Contatos)
            {
                CadastrarContato(contato, connection);
            }

            connection.Close();

            return View();
        }

        private void CadastrarPessoa(PessoaViewModel model, SqlConnection connection)
        {
            SqlCommand command;
            string query;

            query = 
            "INSERT INTO Pessoa (" +
            "   Nome," +
            "   Sobrenome," +
            "   DataNascimento," +
            "   Email," +
            "   Cpf," +
            "   Rg" +
            ") VALUES (" +
            $"  '{model.Nome}'," +
            $"  '{model.Sobrenome}'," +
            $"  '{model.DataNascimento}'," +
            $"  '{model.Email}'," +
            $"  '{model.Cpf}'," +
            $"  '{model.Rg}'" +
            ")";

            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            query = "SELECT TOP 1 Id FROM Pessoa ORDER BY Id DESC";

            command = new SqlCommand(query, connection);
            _id = (int)command.ExecuteScalar();
        }

        private void CadastrarEndereco(EnderecoViewModel model, SqlConnection connection)
        {
            SqlCommand command;
            string query;

            query = 
            "INSERT INTO Endereco (" +
            "   IdPessoa," +
            "   Cep," +
            "   Estado," +
            "   Cidade," +
            "   Logradouro," +
            "   Numero," +
            "   Complemento" +
            ") VALUES (" +
            $"  {_id}," +
            $"  '{model.Cep}'," +
            $"  '{model.Estado}'," +
            $"  '{model.Cidade}'," +
            $"  '{model.Logradouro}'," +
            $"  {model.Numero}," +
            $"  '{model.Complemento}'" +
            ")";

            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        private void CadastrarContato(ContatoViewModel model, SqlConnection connection)
        {
            SqlCommand command;
            string query;

            query = 
            "INSERT INTO Contato (" +
            "   IdPessoa," +
            "   Nome," +
            "   Tipo," +
            "   Contato" +
            ") VALUES (" +
            $"  {_id}," +
            $"  '{model.Nome}'," +
            $"  '{model.Tipo}'," +
            $"  '{model.Contato}'" +
            ")";

            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}
