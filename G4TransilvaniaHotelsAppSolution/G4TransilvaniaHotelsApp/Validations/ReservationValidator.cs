using FluentValidation;
using G4TransilvaniaHotelsApp.Models;

namespace G4TransilvaniaHotelsApp.Validations
{
    public class ReservationValidator : AbstractValidator<ReservationModel>
    {
        public ReservationValidator()
        {
            RuleFor(reservations => reservations.startDate)
                .NotNull().WithMessage("Ingrese la fecha inicio");

            RuleFor(reservations => reservations.endDate)
                 .NotNull().WithMessage("Ingrese la fecha");

            RuleFor(reservations => reservations.roomId)
                .NotNull().WithMessage("ID habitacion");

            RuleFor(reservations => reservations.clientId)
                .NotNull().WithMessage("ID cliente");

            RuleFor(reservations => reservations.reservationPrice)
                .NotNull().WithMessage("Precio reservacion");

            RuleFor(reservations => reservations.paidReservation)
                .NotNull().WithMessage("Estado de la reservacion");
        }
    }
}
