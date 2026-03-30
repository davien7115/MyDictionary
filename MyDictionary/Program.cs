using MyDictionary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using System.ComponentModel;
using static System.Net.WebRequestMethods;

namespace MyDictionary
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //cors polyci to allow any origins, methods and headers
            string myAllowSpecificOrigins = "_myPolyci";
            builder.Services.AddCors(options =>
                {
                    options.AddPolicy(name: myAllowSpecificOrigins,
                        policy =>
                        {
                            policy.AllowAnyOrigin()
                                  //.WithOrigins("https://localhost:7260")   // Addition required, web url
                                  .WithMethods("GET", "POST", "PUT", "DELETE")
                                  .AllowAnyHeader();
                        });
                });

            // Add services to the container.
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Encoder =
                        System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                });


            //Swagger --------------
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MyDictionary",
                    Version = "V1",
                    Description = "API for Dictionary Application Swagger documentation",
                    Contact = new OpenApiContact
                    {
                        Name = "Tiber Dávid",
                        Email = "t.david947@gmail.com",
                        Url = new Uri("https://github.com/davien7115")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/license/MIT")
                    }

                });

                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Postgre service -------------------------------
            builder.Services.AddDbContext<LibraryDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyDictionary App V1");
                    c.EnableDeepLinking();
                });
            }

            //app.UseHttpsRedirection();

            // Database initialization and seeding
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<LibraryDbContext>();

                    await context.Database.EnsureCreatedAsync();

                    if (!await context.Words.AnyAsync())
                    {
                        await context.Words.AddRangeAsync(
                            new LibraryModels { word = "Artichoke", mean = "Articsóka" },
                            new LibraryModels { word = "Asparagus", mean = "Spárga" },
                            new LibraryModels { word = "Kohlrabi", mean = "Karalábé" },
                            new LibraryModels { word = "Eggplant", mean = "Padlizsán" },
                            new LibraryModels { word = "Horseradish", mean = "Torma" }
                            );
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Hiba történt az adatbázis inicializálása közben.");
                }
            }

            app.UseCors(myAllowSpecificOrigins);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
