using MauiAppTemplate.ViewModels;

namespace MauiAppTemplate;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}

