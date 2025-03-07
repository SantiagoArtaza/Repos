using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApi.Models;

namespace WebApi.Validations
{
    public class Validaciones : AbstractValidator<Envio>
    {
        public Validaciones()
        {
            RuleFor(a => a.Estado).NotEmpty().WithMessage("El estado es obligatorio.");
            RuleFor(a => a.Id).NotEmpty().WithMessage("La id es obligario.");
            RuleFor(a => a.DniCliente).NotEmpty().WithMessage("dni del cliente");
            RuleFor(a => a.Direccion).NotEmpty().WithMessage("direccion");
            RuleFor(a => a.PalabraSecreta).NotEmpty().WithMessage("palbra secreta");
            RuleFor(a => a.Fecha).NotEmpty().WithMessage("fecha");
            RuleFor(a => a.PalabraSecreta).MaximumLength(11).WithMessage("palabra muy secreta muy larga");



        }
    }
}