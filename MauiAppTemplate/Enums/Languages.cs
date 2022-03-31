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
        [Display(Name = "Français")]
        FR,

        [Display(Name = "English")]
        EN,

        //[Display(Name = "Deutsch")]
        //DE,

        //[Display(Name = "Español")]
        //ES,
    }
}
