using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.AutoMapper.Categories;
using Walter.Core.AutoMapper.Posts;
using Walter.Core.AutoMapper.User;
using Walter.Core.Interfaces;
using Walter.Core.Services;

namespace Walter.Core
{
    public static class ServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<EmailService>();
            services.AddScoped<ICategoryService,  CategoryService>();
            services.AddScoped<IPostService,  PostService>();
        }

        public static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperUserProfile));
            services.AddAutoMapper(typeof(AutoMapperCategoryProfile));
            services.AddAutoMapper(typeof(AutoMapperPostProfile));
        }
    }
}
