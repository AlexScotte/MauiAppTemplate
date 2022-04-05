using MauiAppTemplate.Enums;
using MauiAppTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiAppTemplate.Common.ViewModels;
using MauiAppTemplate.Views.Components;
using MauiAppTemplate.Extensions;
using MauiAppTemplate.Common;
using System.Globalization;

namespace MauiAppTemplate.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public bool IsSystemThemeSelected => (int)Theme.System == (int)SettingsHelper.Theme;
        public bool IsLightThemeSelected => (int)Theme.Light == (int)SettingsHelper.Theme;
        public bool IsDarkThemeSelected => (int)Theme.Dark == (int)SettingsHelper.Theme;

        public ICommand OnThemeTappedCommand => new Command<string>(OnThemeTapped);
        public ICommand LanguageChangedCommand => new Command<ComboBox.Item>(OnLanguageChanged);

        private IList<ComboBox.Item> _languages;
        public IList<ComboBox.Item> Languages
        {
            get => _languages;
            set => SetProperty(ref _languages, value);
        }

        private ComboBox.Item _selectedLanguage;
        public ComboBox.Item SelectedLanguage
        {
            get => _selectedLanguage;
            set => SetProperty(ref _selectedLanguage, value);
        }

        public SettingsPageViewModel()
        {
            LoadAvailableLanguages();
        }

        private void LoadAvailableLanguages()
        {
            Languages = new List<ComboBox.Item>();

            foreach (Languages language in (Languages[])Enum.GetValues(typeof(Languages)))
            {
                Languages.Add(new()
                {
                    Data = language,
                    Label = $"{IsoCountryCodeToFlagEmoji(language.ToString())}   {language.GetDisplayAttribute(AttributeProperty.Name)}",
                });
            }

            SelectedLanguage = Languages.FirstOrDefault(l => l.Data.ToString() == SettingsHelper.LanguagePreference);
        }

        public string IsoCountryCodeToFlagEmoji(string countryCode) => string.Concat(countryCode.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));

        private void OnLanguageChanged(ComboBox.Item arg)
        {
            if(arg != null && arg.Data is Languages newLanguage)
            {
                SettingsHelper.LanguagePreference = newLanguage.ToString();
                ResourceLoader.Instance.SetCultureInfo(new CultureInfo(newLanguage.GetDisplayAttribute(AttributeProperty.Description)));
            }
        }

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
