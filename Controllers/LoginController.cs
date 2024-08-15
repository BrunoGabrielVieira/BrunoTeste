using System.Data;
using BrunoTeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BrunoTeste.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginSubmit(LoginViewModel model)
        {
            var connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BrunoTeste;Integrated Security=True");
            string sql = $"SELECT Username FROM Usuario WHERE Username = '{model.Username}' AND Senha = '{model.Senha}'"; 
            var command = new SqlCommand(sql, connection);
            connection.Open();
            var res = command.ExecuteScalar();
            if (res != null)
            {
                HttpContext.Session.SetString("_username", (string)res);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
