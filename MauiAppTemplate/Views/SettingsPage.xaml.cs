using MauiAppTemplate.Enums;
using MauiAppTemplate.Helpers;
using MauiAppTemplate.ViewModels;
using MauiAppTemplate.Resources.Languages;
using System.Globalization;
using MauiAppTemplate.Common;

namespace MauiAppTemplate.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        ResourceLoader.Instance.SetCultureInfo(new CultureInfo("en"));
    }
}