namespace MauiAppTemplate.Views.Components;

public partial class ComboBox : ContentView
{
    public static readonly BindableProperty ItemsProperty =
    BindableProperty.Create(
        nameof(Items),
        typeof(List<ComboBox.Item>),
        typeof(ComboBox),
        defaultValue: null);

    public List<ComboBox.Item> Items
    {
        get { return (List<ComboBox.Item>)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }


    public bool IsExpanded { get; set; }
    public string SelectedItem { get; set; }


    public ComboBox()
	{
		InitializeComponent();
        Items = new List<Item>();
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

    public class Item
    {
        public string Image { get; set; }
        public string Label { get; set; }
        public bool IsEnabled { get; set; }
    }
}