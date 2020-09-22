using CadastroPessoa.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CadastroPessoa.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroPessoa.API
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            services.AddDbContext<CadastroPessoaContext>(configure => configure.UseInMemoryDatabase("cadastro_pessoa"));

            services.AddScoped<IPessoaRepository, PessoaRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseRouting();
            app.UseEndpoints(configure => configure.MapControllers());
        }
    }
}