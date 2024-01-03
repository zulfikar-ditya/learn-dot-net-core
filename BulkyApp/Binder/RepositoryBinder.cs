using BulkyApp.DataAccess.Repository;
using BulkyApp.DataAccess.Repository.Interfaces;

namespace BulkyApp.Binder
{
    public class RepositoryBinder
    {
        private readonly WebApplicationBuilder _builder;
        public RepositoryBinder(WebApplicationBuilder builder)
        {
            _builder = builder;
        }


        public void bind()
        {
            _builder.Services.AddScoped<CategoryRepositoryInterface, CategoryRepository>();
        }
    }
}
