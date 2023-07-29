namespace MAUI_Playground.Controls;

public partial class Chip : ContentView
{
    public static readonly BindableProperty SelectedBackgroundColorProperty =
    BindableProperty.Create("SelectedBackgroundColor", typeof(Color), typeof(Chip), default(Color), propertyChanged: (view, oldValue, newValue) =>
    {
        //Check frame tap gesture recognizer.

        if (!(newValue is Color) || newValue == null)
            return;

        var chip = view as Chip;
        if (chip.IsSelected)
            chip.MainLayout.BackgroundColor = newValue as Color;
    });
    public Color SelectedBackgroundColor
    {
        get => (Color)GetValue(SelectedBackgroundColorProperty);
        set => SetValue(SelectedBackgroundColorProperty, value);
    }
    public static readonly BindableProperty ChipBackgroundColorProperty =
    BindableProperty.Create("ChipBackgroundColor", typeof(Color), typeof(Chip), default(Color), propertyChanged: (view, oldValue, newValue) =>
    {
        if (!(newValue is Color) || newValue == null)
            return;

        var chip = view as Chip;
        if (!chip.IsSelected)
            chip.MainLayout.BackgroundColor = newValue as Color;
    });
    public Color ChipBackgroundColor
    {
        get => (Color)GetValue(ChipBackgroundColorProperty);
        set => SetValue(ChipBackgroundColorProperty, value);
    }
    public static readonly BindableProperty IsSelectedProperty =
    BindableProperty.Create("IsSelected", typeof(bool), typeof(Chip), false, propertyChanged: (view, oldValue, newValue) =>
    {
        if (!(newValue is bool) || newValue == null)
            return;

        var chip = view as Chip;

        if ((bool)newValue)
        {
            chip.MainLayout.BackgroundColor = chip.SelectedBackgroundColor;
        }
        else
        {
            chip.MainLayout.BackgroundColor = chip.ChipBackgroundColor;
        }
    });
    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public Chip()
	{
		InitializeComponent();

        TapGestureRecognizer chipTapped = new TapGestureRecognizer();
        chipTapped.Tapped += (s, e) =>
        {
            IsSelected = !IsSelected;
        };
        this.MainLayout.GestureRecognizers.Add(chipTapped);
    }
}
