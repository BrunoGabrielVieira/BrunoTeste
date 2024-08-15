using BrunoTeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BrunoTeste.Controllers
{
    public class UsuarioController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UsuarioSubmit(UsuarioViewModel model)
        {
            var connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BrunoTeste;Integrated Security=True");
            
            string query =
            "INSERT INTO Usuario (" +
            "   Username," +
            "   Senha," +
            "   Email," +
            "   Telefone" +
            ") VALUES (" +
            $"  '{model.Username}'," +
            $"   '{model.Senha}'," +
            $"   '{model.Email}'," +
            $"   '{model.Telefone}'" +
            ")";

            var command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            return RedirectToAction("Index", "Login");
        }
    }
}
