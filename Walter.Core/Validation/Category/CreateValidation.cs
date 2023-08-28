using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.DTO_s.Category;

namespace Walter.Core.Validation.Category
{
    public class CreateValidation : AbstractValidator<CategoryDto>
    {
        public CreateValidation()
        {
            RuleFor(r => r.Name).NotEmpty();
        }
    }
}
