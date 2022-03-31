using MauiAppTemplate.ViewModels;

namespace MauiAppTemplate;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
		BindingContext = new MainPageViewModel();
		InitializeComponent();
	}
}

