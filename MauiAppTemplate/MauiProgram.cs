using CommunityToolkit.Maui;
using MauiAppTemplate.Services;
using MauiAppTemplate.ViewModels;

namespace MauiAppTemplate;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();



		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddTransient<MainPageViewModel>();
		builder.Services.AddTransient<SettingsPageViewModel>();

		return builder.Build();
	}
}
