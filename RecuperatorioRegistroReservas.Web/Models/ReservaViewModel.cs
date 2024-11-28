using System.ComponentModel.DataAnnotations;
using RecuperatorioRegistroReservas.Entidades;
namespace RecuperatorioRegistroReservas.Web.Models
{
    public class ReservaViewModel
    {
        [Required(ErrorMessage ="El campo nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El máximo de caracteres es de 50")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo cantidad de pasajeros es obligatorio")]
        public int CantidadPasajeros { get; set; }

        [Required(ErrorMessage = "El campo fecha de inicio es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Fin es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
        
        public DateTime FechaFin { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaFin <= FechaInicio)
            {
                yield return new ValidationResult(
                    "La Fecha de Fin debe ser posterior a la Fecha de Inicio",
                    new[] { nameof(FechaFin) }
                );
            }
        }
        public double CostoTotal { get; set; }
        public static Reserva ToReserva(ReservaViewModel reservaViewModel)
        {
            return new Reserva
            {
         
                Nombre = reservaViewModel.Nombre,
                CantidadPasajeros = reservaViewModel.CantidadPasajeros,
                FechaInicio = reservaViewModel.FechaInicio,
                FechaFin = reservaViewModel.FechaFin
            };
        }
        public static ReservaViewModel FromReserva(ReservaViewModel reserva)
        {
            return new ReservaViewModel
            {
                Nombre = reserva.Nombre,
                CantidadPasajeros = reserva.CantidadPasajeros,
                FechaInicio = reserva.FechaInicio,
                FechaFin = reserva.FechaFin,
                CostoTotal = reserva.CostoTotal
            };
        }


    }
}
