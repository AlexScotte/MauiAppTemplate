using MauiAppTemplate.Resources.Languages;
using CommunityToolkit.Maui;
using MauiAppTemplate.Services;
using System.Globalization;
using MauiAppTemplate.ViewModels;
using MauiAppTemplate.Enums;

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
				fonts.AddFont("fa-brands-400.ttf", IconFontFamily.FAB.ToString());
				fonts.AddFont("fa-regular-400.ttf", IconFontFamily.FAR.ToString());
				fonts.AddFont("fa-solid-900.ttf", IconFontFamily.FAS.ToString());
				fonts.AddFont("MaterialIcons-Regular.ttf", IconFontFamily.MDR.ToString());
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
