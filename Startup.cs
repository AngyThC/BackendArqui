using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Este método se llama en tiempo de ejecución. Usa este método para agregar servicios al contenedor.
    public void ConfigureServices(IServiceCollection services)
    {
        // Configuraciones y servicios
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:4200")
                                 .AllowAnyHeader()
                                 .WithExposedHeaders("Authorization")
                                 .AllowAnyMethod()
                                 .AllowCredentials());
        });


        // Otros servicios...
    }

    // Este método se llama en tiempo de ejecución. Usa este método para configurar el pipeline de solicitud HTTP.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // Otras configuraciones...

        app.UseCors("AllowSpecificOrigin");

        // Otras configuraciones...
    }
}
