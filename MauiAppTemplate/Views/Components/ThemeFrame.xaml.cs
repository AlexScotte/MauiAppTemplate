namespace MauiAppTemplate.Views.Components;

public partial class ThemeFrame : ContentView
{
	public static readonly BindableProperty TextProperty =
		BindableProperty.Create(
			nameof(Text),
			typeof(string),
			typeof(ThemeFrame),
			defaultValue: string.Empty);

	public string Text
	{
		get { return (string)GetValue(TextProperty); }
		set { SetValue(TextProperty, value); }
	}

	public static readonly BindableProperty IsSelectedProperty =
	BindableProperty.Create(
		nameof(IsSelected),
		typeof(bool),
		typeof(ThemeFrame),
		defaultValue: false, BindingMode.TwoWay);

	public bool IsSelected
	{
		get { return (bool)GetValue(IsSelectedProperty); }
		set { SetValue(IsSelectedProperty, value); }
	}

	public ThemeFrame()
	{
		InitializeComponent();
	}
}