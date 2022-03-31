using MauiAppTemplate.Enums;
using MauiAppTemplate.Helpers;
using MauiAppTemplate.ViewModels;
using MauiAppTemplate.Resources.Languages;
using System.Globalization;
using MauiAppTemplate.Common;

namespace MauiAppTemplate.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        BindingContext = new SettingsPageViewModel();
        InitializeComponent();
    }
}