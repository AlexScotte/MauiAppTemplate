using MauiAppTemplate.Enums;
using MauiAppTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiAppTemplate.Common.ViewModels;

namespace MauiAppTemplate.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public bool IsSystemThemeSelected => (int)Theme.System == (int)SettingsHelper.Theme;
        public bool IsLightThemeSelected => (int)Theme.Light == (int)SettingsHelper.Theme;
        public bool IsDarkThemeSelected => (int)Theme.Dark == (int)SettingsHelper.Theme;

        public ICommand OnThemeTappedCommand => new Command<string>(OnThemeTapped);

        private void OnThemeTapped(string newThemeIndex)
        {
            var newTheme = (Theme)Enum.Parse(typeof(Theme), newThemeIndex);

            switch (newTheme)
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
