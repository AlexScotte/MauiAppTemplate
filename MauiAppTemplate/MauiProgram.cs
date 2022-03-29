using MauiAppTemplate.Resources.Languages;
using CommunityToolkit.Maui;
using MauiAppTemplate.Services;
using System.Globalization;
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

        #region View model

        builder.Services.AddTransient<MainPageViewModel>();
		builder.Services.AddTransient<SettingsPageViewModel>();
        builder.Services.AddTransient<SettingsPageViewModel>(); 

		#endregion


		#region Services

		
		#endregion

		return builder.Build();
	}
}
