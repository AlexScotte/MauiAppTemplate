using MauiAppTemplate.Enums;
using MauiAppTemplate.Helpers;
using MauiAppTemplate.ViewModels;

namespace MauiAppTemplate.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}