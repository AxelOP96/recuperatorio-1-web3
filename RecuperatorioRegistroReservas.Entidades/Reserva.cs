namespace RecuperatorioRegistroReservas.Entidades
{
    public class Reserva
    {
        public string Nombre { get; set; }
        public int CantidadPasajeros { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        //Costo Total = (Cantidad de Pasajeros * Días del Viaje * 10000). donde Dias del viaje = FechaFin - FechaInicio + 1

        public int CostoTotal
        {
            get
            {
                DateTime fechaInicio = FechaInicio.
                DateTime fechaFin = FechaFin.Date;
                int diasDelViaje = (int)Math.Ceiling((fechaFin - fechaInicio).TotalDays) + 1;
                return CantidadPasajeros * diasDelViaje * 1000;
            }
        }
    }
}
