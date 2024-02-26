using FluentValidation;
using G4TransilvaniaHotelsApp.Models;

namespace G4TransilvaniaHotelsApp.Validations
{
    public class Hotels : AbstractValidator<HotelsModel>
    {
        public Hotels()
        {
            RuleFor(hotels => hotels.hotelName)
                .NotNull().WithMessage("Debe de ingresar el nombre del hotel")
                .NotEmpty()
                .MinimumLength(40)
                .MaximumLength(50);

            RuleFor(hotels => hotels.hotelStars)
                .NotNull().WithMessage("Debe ingresar un numero de estrellas");


            RuleFor(hotels => hotels.hotelAddress)
                .NotNull().WithMessage("Ingrese la direccion")
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(50);

            RuleFor(hotels => hotels.hotelPhone)
                .NotNull().WithMessage("Ingrese el numero de teléfono")
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(20);
        }

    }
}
