using MauiAppTemplate.ViewModels;
using MauiAppTemplate.Views.Components;

namespace MauiAppTemplate;

public partial class MainPage : ContentPage
{
	public List<ComboBox.Item> MyItems { get; set; } = new List<ComboBox.Item>();

    public MainPage()
    {
		BindingContext = new MainPageViewModel();
		InitializeComponent();

		MyItems.Add(new() { Label = "Test 1" });
		MyItems.Add(new() { Label = "Test 2" });
		MyItems.Add(new() { Label = "Test 3" });
		MyItems.Add(new() { Label = "Test 4", IsEnabled = false });
		MyItems.Add(new() { Label = "Test 5", IsEnabled = false });
	}
}

