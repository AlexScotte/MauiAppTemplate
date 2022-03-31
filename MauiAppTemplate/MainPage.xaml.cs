using MauiAppTemplate.ViewModels;
using MauiAppTemplate.Views.Components;

namespace MauiAppTemplate;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
		BindingContext = new MainPageViewModel();
		InitializeComponent();
	}
}

