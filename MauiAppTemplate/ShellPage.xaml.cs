using MauiAppTemplate.Common;
using MauiAppTemplate.ViewModels;
using System.ComponentModel;
using System.Globalization;

namespace MauiAppTemplate;

public partial class ShellPage
{
	public ShellPage()
	{
		BindingContext = new ShellPageViewModel();
		InitializeComponent();
    }
}