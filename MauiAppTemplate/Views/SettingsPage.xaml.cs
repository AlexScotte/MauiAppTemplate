using MauiAppTemplate.Enums;
using MauiAppTemplate.Helpers;

namespace MauiAppTemplate.Views;

public partial class SettingsPage : ContentPage
{
    public bool IsSystemThemeSelected => (int)Theme.System == (int)SettingsHelper.Theme;
    public bool IsLightThemeSelected => (int)Theme.Light == (int)SettingsHelper.Theme;
    public bool IsDarkThemeSelected => (int)Theme.Dark == (int)SettingsHelper.Theme;

    public SettingsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private void OnThemeTapped(object sender, EventArgs e)
    {
        if (e is TappedEventArgs tapEventArg)
        {
            var val = (Theme)Enum.Parse(typeof(Theme), tapEventArg.Parameter.ToString());

            switch (val)
            {
                case Theme.System:
                    SettingsHelper.Theme = (int)Theme.System;
                    break;
                case Theme.Light:
                    SettingsHelper.Theme = (int)Theme.Light;
                    break;
                case Theme.Dark:
                    SettingsHelper.Theme = (int)Theme.Dark;
                    break;
            }

            ThemeHelper.SetTheme();

            OnPropertyChanged(nameof(IsSystemThemeSelected));
            OnPropertyChanged(nameof(IsLightThemeSelected));
            OnPropertyChanged(nameof(IsDarkThemeSelected));
        }
    }
}