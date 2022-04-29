using Business.Dtos.Game;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Game
{
    public class GameDtoValidator : AbstractValidator<GameDto>
    {
        public GameDtoValidator()
        {
            RuleFor(x => x.Result).NotEmpty();
            RuleFor(x => x.PlayedOn).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
