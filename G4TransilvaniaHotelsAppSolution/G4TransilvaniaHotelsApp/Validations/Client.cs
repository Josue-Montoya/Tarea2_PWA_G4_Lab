using FluentValidation;
using G4TransilvaniaHotelsApp.Models;

namespace G4TransilvaniaHotelsApp.Validations
{
    public class Client : AbstractValidator<ClientModel>
    {
        public Client()
        {
            RuleFor(clients => clients.clientName)
                .NotNull().WithMessage("Debe de ingresar el nombre ")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Debe de ingresar minimo 3 letras ")
                .MaximumLength(50).WithMessage("Solo se permite ingresar 50 caracteres");


            RuleFor(clients => clients.clientEmail)
                .NotNull().WithMessage("El campo no debe de estar vacio")
                .NotEmpty()
                .MaximumLength(50).WithMessage("Solo se permite ingresar 50 caracteres");;

            RuleFor(clients => clients.clientPhone)
                .NotNull().WithMessage("El teléfono no debe de estar vacio")
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(20);

        }
    }
}
