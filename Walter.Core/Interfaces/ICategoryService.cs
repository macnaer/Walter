using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.DTO_s.Category;
using Walter.Core.Services;

namespace Walter.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GettAll();
        Task<CategoryDto> Get(int id);
        Task<ServiceResponse> GetByName(CategoryDto model);
        Task Create(CategoryDto model);
        Task Update(CategoryDto model);
        Task Delete(int id);
    }
}
