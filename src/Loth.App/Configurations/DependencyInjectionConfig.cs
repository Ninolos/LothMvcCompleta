using Loth.Business.Interfaces;
using Loth.Data.Context;
using Loth.Data.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace Loth.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<LothDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();            

            return services;
        }
    }
}
