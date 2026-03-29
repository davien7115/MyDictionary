using MyDictionaryApp.Components;

namespace MyDictionaryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("http://mydictionaryapi:8080") // API URL
            });

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
           // app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();

            app.Run();
        }
    }
}
