using CollectionViewMVVM.Services;
using CollectionViewMVVM.ViewModels;
using CollectionViewMVVM.Views;
using Microsoft.Extensions.Logging;

namespace CollectionViewMVVM;

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
            })
            .RegisterDataServices()
            .RegisterPages()
            .RegisterViewModels();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        //--------singleton Pages
        builder.Services.AddSingleton<CollectionViewMVVM.Views.Picker>();

        //--------Transient pages

        builder.Services.AddTransient<MonkeyDetailsView>();
        builder.Services.AddTransient<MonkeyMenuView>();

        return builder;
    }

    public static MauiAppBuilder RegisterDataServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MonkeyService>();
        return builder;
    }
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<PickerViewModel>();

        //--------Transient ViewModels
        builder.Services.AddTransient<MonkeyDetailViewModel>();
        builder.Services.AddTransient<MonkeyViewModel>();

        return builder;
    }
}