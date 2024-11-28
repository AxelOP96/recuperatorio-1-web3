using Microsoft.AspNetCore.Mvc;
using RecuperatorioRegistroReservas.Entidades;
using RecuperatorioRegistroReservas.Logica;
using RecuperatorioRegistroReservas.Web.Models;
namespace RecuperatorioRegistroReservas.Web.Controllers
{
    public class ReservasController : Controller
    {
        
            private readonly IReservaLogica _reservaLogica;
            public ReservasController(IReservaLogica reservaLogica)
            {
                _reservaLogica = reservaLogica;
            }
            [HttpGet]
            public IActionResult RegistrarReserva()
            {
                return View();
            }
            [HttpPost]
            public IActionResult RegistrarReserva(ReservaViewModel reserva)
            {
                if (!ModelState.IsValid)
                {
                    return View(reserva);
                }
                _reservaLogica.RegistrarReserva(ReservaViewModel.ToReserva(reserva));
                return RedirectToAction("Listado");
            }
            [HttpGet]
            public IActionResult Listado()
            {
                var reservas = _reservaLogica.Listado(); 
                if (reservas == null || !reservas.Any())
                {
                reservas = new List<Reserva>();
                }


            var reservasViewModel = reservas.Select(reserva => new ReservaViewModel
            {
               
                Nombre = reserva.Nombre,
                CantidadPasajeros = reserva.CantidadPasajeros,
                FechaInicio = reserva.FechaInicio,
                FechaFin = reserva.FechaFin

            }).ToList();
            return View(reservasViewModel);
        }

    }
}
