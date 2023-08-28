using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.DTO_s.Category;
using Walter.Core.Entities.Site;
using Walter.Core.Entities.Specifications;
using Walter.Core.Interfaces;

namespace Walter.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _categoryRepo;

        public CategoryService(IMapper mapper, IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public async Task Create(CategoryDto model)
        {
            await _categoryRepo.Insert(_mapper.Map<Category>(model));
            await _categoryRepo.Save();
        }

        public async Task Delete(int id)
        {
            var result = await Get(id);
            if (result != null) return;
            await _categoryRepo.Delete(id);
            await _categoryRepo.Save();
        }

        public async Task<CategoryDto> Get(int id)
        {
            if (id < 0) return null;
            
            var category = await _categoryRepo.GetByID(id);
            if (category == null) return null;

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<ServiceResponse> GetByName(CategoryDto model)
        {
            var result = await _categoryRepo.GetItemBySpec(new CategorySpecification.GetByName(model.Name));
            if (result != null)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "Category exists."
                };
            }
            var category = _mapper.Map<CategoryDto>(result);
            return new ServiceResponse
            {
                Success = true,
                Message = "Category successfully loaded.",
                Payload = category
            };
        }

        public async Task<List<CategoryDto>> GettAll()
        {
            var result = await _categoryRepo.GetAll();
            return _mapper.Map<List<CategoryDto>>(result);
        }

        public async Task Update(CategoryDto model)
        {
            await _categoryRepo.Update(_mapper.Map<Category>(model));
            await _categoryRepo.Save();
        }
    }
}
