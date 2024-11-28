using RecuperatorioRegistroReservas.Entidades;
namespace RecuperatorioRegistroReservas.Logica
{
    public class ReservaLogica : IReservaLogica
    {
        private static List<Reserva> _items = new List<Reserva>();
        0
        public void RegistrarReserva(Reserva reserva)
        {
            _items.Add(reserva);
        }
        public List<Reserva> Listado()
        {
            return _items
            .ToList();
        }

    }
    public interface IReservaLogica
    {
        void RegistrarReserva(Reserva reserva);
        List<Reserva> Listado();
    }

}
