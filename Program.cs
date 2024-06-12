

namespace ExcelGenAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicionar serviços ao contêiner.
            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configurar o pipeline de solicitação HTTP.
            Configure(app, builder.Environment);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            // Configuração do CORS
            services.AddCors(options =>
            {
                options.AddPolicy("corsConfig",
                                  builder => builder
                                  .AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());
            });

            // Adicionando serviços de controle e Swagger
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void Configure(WebApplication app, IHostEnvironment env)
        {
            // Uso do Swagger em ambiente de desenvolvimento
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            // Aplicar a política CORS configurada
            app.UseCors("corsConfig");

            // Mapear controladores
            app.MapControllers();
        }
    }
}
