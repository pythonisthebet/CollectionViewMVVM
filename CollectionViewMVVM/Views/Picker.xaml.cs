using CollectionViewMVVM.ViewModels;

namespace CollectionViewMVVM.Views;

public partial class Picker : ContentPage
{
	public Picker(PickerViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }

    public void clear()
    {
        entry.Text = "";
    }
}