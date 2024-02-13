namespace CollectionViewMVVM.Views;

public partial class MonkeyDetailsView : ContentPage
{
	public MonkeyDetailsView(ViewModels.MonkeyDetailViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}