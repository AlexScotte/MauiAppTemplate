using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTemplate.Enums
{
    public enum Languages
    {
        [Display(Name = "Français", Description = "fr-FR")]
        FR,

        [Display(Name = "English", Description = "en-GB")]
        GB,

        [Display(Name = "Deutsch", Description = "de-DE")]
        DE,

        [Display(Name = "Español", Description = "es-ES")]
        ES,
    }
}
