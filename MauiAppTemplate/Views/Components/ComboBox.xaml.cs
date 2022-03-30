namespace MauiAppTemplate.Views.Components;

public partial class ComboBox : ContentView
{
    #region Bindable properties

    public new static readonly BindableProperty BackgroundColorProperty =
    BindableProperty.Create(
        nameof(BackgroundColor),
        typeof(Color),
        typeof(ComboBox),
        defaultValue: Colors.White);

    public new Color BackgroundColor
    {
        get { return (Color)GetValue(BackgroundColorProperty); }
        set { SetValue(BackgroundColorProperty, value); }
    }

    public static readonly BindableProperty SelectorBackgroundColorProperty =
BindableProperty.Create(
    nameof(SelectorBackgroundColor),
    typeof(Color),
    typeof(ComboBox),
    defaultValue: Colors.White);

    public Color SelectorBackgroundColor
    {
        get { return (Color)GetValue(SelectorBackgroundColorProperty); }
        set { SetValue(SelectorBackgroundColorProperty, value); }
    }

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(ComboBox),
            defaultValue: Colors.Black);

    public Color TextColor
    {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }

    public static readonly BindableProperty SelectorTextColorProperty =
        BindableProperty.Create(
            nameof(SelectorTextColor),
            typeof(Color),
            typeof(ComboBox),
            defaultValue: Colors.Black);

    public Color SelectorTextColor
    {
        get { return (Color)GetValue(SelectorTextColorProperty); }
        set { SetValue(SelectorTextColorProperty, value); }
    }

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

    public static readonly BindableProperty SelectedItemProperty =
        BindableProperty.Create(
            nameof(SelectedItem),
            typeof(ComboBox.Item),
            typeof(ComboBox),
            defaultValue: null);

    public ComboBox.Item SelectedItem
    {
        get { return (ComboBox.Item)GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }
    #endregion

    public bool IsExpanded { get; set; }

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
        SelectedItem = e.SelectedItem as ComboBox.Item;

        OnPropertyChanged(nameof(IsExpanded));
        OnPropertyChanged(nameof(SelectedItem));
    }

    public class Item
    {
        public string Image { get; set; }
        public string Label { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}