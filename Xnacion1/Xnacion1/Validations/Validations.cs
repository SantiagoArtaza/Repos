
using FluentValidation;
using Xnacion1.Repository;

namespace Xnacion1.Validations { 
    
    public class Validations:AbstractValidator<TEnvio>
    {
        public Validations()
        {
            RuleFor(a => a.Estado).NotEmpty().WithMessage("El estado es obligatorio.");
            RuleFor(a => a.DniCliente).NotEmpty().WithMessage("dni del cliente");
            RuleFor(a => a.Direccion).NotEmpty().WithMessage("direccion");
            RuleFor(a => a.PalabraSecreta).NotEmpty().WithMessage("palabra secreta");
            RuleFor(a => a.Fecha).NotEmpty().WithMessage("fecha");
            RuleFor(a => a.PalabraSecreta).MaximumLength(11).WithMessage("palabra muy secreta muy larga");
           


        }
    }
}
