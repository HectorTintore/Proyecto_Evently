using Proyecto_Evently.ViewModels;
using Proyecto_Evently.Views;
using Proyecto_Evently.Services;

using Microsoft.Extensions.Logging;
using Proyecto_Evently.Services.Interfaces;

namespace Proyecto_Evently
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

            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri("http://localhost:3000/almacenes") });

            builder.Services.AddSingleton<ICreateLote, CreateLote>();
            builder.Services.AddSingleton<CreateLoteViewModel>();
            builder.Services.AddSingleton<LotesPrueba>();
            builder.Services.AddSingleton<Ordenes>();
            builder.Services.AddSingleton<IUbicacionAlmacen, UbicacionAlmacenServices /*ApiAlmacenesServicesServices*/>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
