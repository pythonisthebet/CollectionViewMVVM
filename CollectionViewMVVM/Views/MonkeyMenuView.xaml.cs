using CollectionViewMVVM.ViewModels;
namespace CollectionViewMVVM.Views;

public partial class MonkeyMenuView : ContentPage
{
    public MonkeyMenuView(MonkeyViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm; 
	}
}