using MauiAppTemplate.Helpers;
using MauiAppTemplate.Views;

namespace MauiAppTemplate;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new ShellPage();

        ThemeHelper.SetTheme();
    }
}
