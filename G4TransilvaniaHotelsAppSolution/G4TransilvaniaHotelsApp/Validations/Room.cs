using FluentValidation;
using G4TransilvaniaHotelsApp.Models;

namespace G4TransilvaniaHotelsApp.Validations
{
    public class Room : AbstractValidator<RoomModel>
    {
        public Room()
        {
            RuleFor(room => room.roomNumber)
                .NotNull().WithMessage("El numero de la habitacion no debe de estar vacio")
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(10);
;
            RuleFor(room => room.roomPrice)
                .NotNull().WithMessage("El precio no debe estar vacio")
                .GreaterThan(0).WithMessage("Precio mayor a cero");
        }
    }
}
