using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Proyecto1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Get the database path
            var dbPath = Helpers.FileAccessHelper.GetLocalFilePath("flights.db");

            // Register the DataContext as a service
            builder.Services.AddDbContext<Models.DataContext>(options => options.UseSqlite($"Data Source={dbPath}"));

            // Build the app
            var app = builder.Build();

            using ( var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<Models.DataContext>();
                db.Database.EnsureCreated(); // Create the database if it does not exist
            }

            return app;
        }
    }
}
