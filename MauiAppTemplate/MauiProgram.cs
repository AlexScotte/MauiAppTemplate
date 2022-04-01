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
				fonts.AddFont("fa-brands-400.ttf", "FAB");
				fonts.AddFont("fa-regular-400.ttf", "FAR");
				fonts.AddFont("fa-solid-900.ttf", "FAS");
				fonts.AddFont("MaterialIcons-Regular.ttf", "MDR");
			});

        #region View model

        //builder.Services.AddTransient<MainPageViewModel>();
		//builder.Services.AddTransient<SettingsPageViewModel>();

		#endregion


		#region Services

		
		#endregion

		return builder.Build();
	}
}
