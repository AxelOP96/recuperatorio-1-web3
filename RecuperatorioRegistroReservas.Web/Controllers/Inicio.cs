using Microsoft.AspNetCore.Mvc;

namespace RecuperatorioRegistroReservas.Web.Controllers
{
    public class Inicio : Controller
    {
        public IActionResult Bienvenida()
        {
            return View();
        }
    }
}
