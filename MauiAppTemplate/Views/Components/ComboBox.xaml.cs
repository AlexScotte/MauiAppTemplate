using System.Windows.Input;

namespace MauiAppTemplate.Views.Components;

public partial class ComboBox : ContentView
{
    #region Bindable properties

    #region UI Bindable properties
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

    public static readonly BindableProperty SelectorMaximumHeightRequestProperty =
        BindableProperty.Create(
            nameof(SelectorMaximumHeightRequest),
            typeof(double),
            typeof(ComboBox),
            defaultValue: 1000.0);

    public double SelectorMaximumHeightRequest
    {
        get { return (double)GetValue(SelectorMaximumHeightRequestProperty); }
        set { SetValue(SelectorMaximumHeightRequestProperty, value); }
    }
    #endregion

    public static readonly BindableProperty ItemsProperty =
        BindableProperty.Create(
            nameof(Items),
            typeof(List<ComboBox.Item>),
            typeof(ComboBox),
            defaultValue: new List<ComboBox.Item>());

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

    public static readonly BindableProperty SelectionChangedCommandProperty =
        BindableProperty.Create(
            nameof(SelectionChangedCommand),
            typeof(ICommand),
            typeof(ComboBox),
            defaultValue: null);

    public ICommand SelectionChangedCommand
    {
        get { return (ICommand)GetValue(SelectionChangedCommandProperty); }
        set { SetValue(SelectionChangedCommandProperty, value); }
    }
    #endregion

    public bool IsExpanded { get; set; }

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

    private void SelectedItemChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is ComboBox.Item selectedItem)
        {
            if (!selectedItem.IsEnabled)
                return;

            IsExpanded = false;
            SelectedItem = selectedItem;

            if (SelectionChangedCommand != null)
                SelectionChangedCommand.Execute(SelectedItem);

            OnPropertyChanged(nameof(IsExpanded));
            OnPropertyChanged(nameof(SelectedItem));
        }
    }

    public class Item
    {
        public object Data { get; set; }
        public string Image { get; set; }
        public string Label { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}