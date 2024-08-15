using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BrunoTeste.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BrunoTeste.Controllers
{
    public class BaseController : Controller
    {
        protected string? _username;
        protected bool _logado;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _username = HttpContext.Session.GetString("_username");
            _logado = _username != null;
        }
    }
}
