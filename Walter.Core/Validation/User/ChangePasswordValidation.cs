using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.DTO_s.User;

namespace Walter.Core.Validation.User
{
    public class ChangePasswordValidation : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.OldPassword).NotEmpty().MinimumLength(6);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(r => r.ConfirmPassword).MinimumLength(6).Equal(r => r.Password);
        }
    }
}
