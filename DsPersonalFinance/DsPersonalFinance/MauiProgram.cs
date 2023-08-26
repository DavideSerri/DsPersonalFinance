using DsPersonalFinance.DBServices;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;

namespace DsPersonalFinance
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<DBCategoryService>();
            builder.Services.AddSingleton<DBSubCategoryService>();
            builder.Services.AddSingleton<DBTransactionTypeService>();
            builder.Services.AddSingleton<DBTransactionService>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}