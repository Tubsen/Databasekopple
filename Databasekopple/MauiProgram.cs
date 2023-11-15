using Databasekopple.Data;
using Microsoft.Extensions.Logging;

namespace Databasekopple
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

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "run.db");

            builder.Services.AddSingleton(s =>
                ActivatorUtilities.CreateInstance<RunRepository>(s, dbPath));


#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}