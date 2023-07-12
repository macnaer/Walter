using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.DTO_s.User;

namespace Walter.Core.Validation.User
{
    public class LoginUserValidation : AbstractValidator<LoginUserDto>
    {
        public LoginUserValidation()
        {
            RuleFor(r => r.Email).NotEmpty().WithMessage("Field must not be empty.").EmailAddress().WithMessage("Wrong email format.");
            RuleFor(r => r.Password).NotEmpty().WithMessage("Field must not be empty.").MinimumLength(6).WithMessage("Password must be at least 6 characters.");
        }
    }
}
