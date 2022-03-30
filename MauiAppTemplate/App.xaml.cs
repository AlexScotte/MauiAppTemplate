using MauiAppTemplate.Common;
using MauiAppTemplate.Helpers;
using MauiAppTemplate.Resources.Languages;
using MauiAppTemplate.ViewModels;
using System.Reflection;
using System.Resources;

namespace MauiAppTemplate;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();

        new ResourceLoader(typeof(AppResources));

        MainPage = new ShellPage();

        ThemeHelper.SetTheme();
    }
}
