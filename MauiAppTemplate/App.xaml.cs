using MauiAppTemplate.Helpers;
using MauiAppTemplate.Resources.Languages;
using MauiAppTemplate.Views;
using System.Reflection;
using System.Resources;

namespace MauiAppTemplate;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        new ResourceLoader(new ResourceManager(ResourceLoader.ResourceId, typeof(App).GetTypeInfo().Assembly));

        MainPage = new ShellPage();

        ThemeHelper.SetTheme();
    }
}
