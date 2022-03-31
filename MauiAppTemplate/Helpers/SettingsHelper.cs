using MauiAppTemplate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTemplate.Helpers
{
    public static class SettingsHelper
    {
        const int theme = 0;
        public static int Theme
        {
            get => Preferences.Get(nameof(Theme), theme);
            set => Preferences.Set(nameof(Theme), value);
        }

        static string languagePreference = Languages.FR.ToString().ToLower();
        public static string LanguagePreference
        {
            get => Preferences.Get(nameof(LanguagePreference), languagePreference);
            set => Preferences.Set(nameof(LanguagePreference), value.ToLower());
        }
    }
}
