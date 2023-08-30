using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.DTO_s.Post;

namespace Walter.Core.Validation.Post
{
    public class CreateValidation : AbstractValidator<PostDto>
    {
        public CreateValidation()
        {
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.Description).NotEmpty();
            RuleFor(r => r.FullText).NotEmpty();
            RuleFor(r => r.CategoryId).NotEmpty();
        }
    }
}
