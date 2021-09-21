using FluentValidation;
using Nomina2018.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina2018.Infrastructure.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator()
        {
            //RuleFor(employee => employee.SName)
            //    .NotNull()
            //    .Length(10, 50)
            //    .WithMessage("El nombre es obligatorio");
            //RuleFor(employee => employee.SLastName)
            //    .NotNull()
            //    .Length(10, 50)
            //    .WithMessage("El campo apellido es obligatorio");
        }
    }
}
