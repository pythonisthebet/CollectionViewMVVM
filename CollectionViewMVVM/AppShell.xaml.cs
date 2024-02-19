namespace CollectionViewMVVM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            Routing.RegisterRoute("monkeyDetails", typeof(Views.MonkeyDetailsView));
            Routing.RegisterRoute("monkeyFilter", typeof(Views.MonkeyMenuView));
        }
    }
}