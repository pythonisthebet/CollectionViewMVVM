using CollectionViewMVVM.ViewModels;
namespace CollectionViewMVVM.Views;

public partial class MonkeyMenuView : ContentPage
{
	public MonkeyMenuView()
	{
		InitializeComponent();
		BindingContext = new ShowMonkeyListViewModel();
	}
}