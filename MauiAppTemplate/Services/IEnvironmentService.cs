using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTemplate.Services
{
    public interface IEnvironmentService
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
