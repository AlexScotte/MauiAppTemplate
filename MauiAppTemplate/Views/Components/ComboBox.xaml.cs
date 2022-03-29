namespace MauiAppTemplate.Views.Components;

public partial class ComboBox : ContentView
{
    public bool IsExpanded { get; set; }
    public string SelectedItem { get; set; }


    public ComboBox()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        await frame.FadeTo(0.75, 100, Easing.Linear);

        IsExpanded = !IsExpanded;
        OnPropertyChanged(nameof(IsExpanded));

        await frame.FadeTo(1, 100, Easing.Linear);
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        IsExpanded = false;
        SelectedItem = e.SelectedItem.ToString();

        OnPropertyChanged(nameof(IsExpanded));
        OnPropertyChanged(nameof(SelectedItem));

    }
}