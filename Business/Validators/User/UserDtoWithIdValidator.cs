using Business.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.User
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Password).Matches("(?=.*?[0-9])(?=.*?[A-Z])(?=.*?[a-z])(?=.*[!@#$%^&*]).+").WithMessage("Invalid password");
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
