using Business.Dtos.Position;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Validator
{
    public class PositionDtoValidator : AbstractValidator<PositionDto>
    {
        public PositionDtoValidator()
        {
            RuleFor(x => x.FEN).NotEmpty();

            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.Solution).NotEmpty();
        }
    }
}
