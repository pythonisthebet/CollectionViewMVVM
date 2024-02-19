using ShellLesson.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewMVVM.ViewModels
{
    public class PickerViewModel : ViewModelBase
    {
        #region Single Selection

        private string selectedFilter;
        public string SelectedFilter
        {
            get
            {
                return this.selectedFilter;
            }
            set
            {
                this.selectedFilter = value;
                OnPropertyChanged();
            }
        }

        public ICommand SingleSelectCommand => new Command(OnSingleSelectMonkey);

        async void OnSingleSelectMonkey()
        {
            string SelectedFilter = null;

                var navParam = new Dictionary<string, object>()
            {
                { "selectedFilter",SelectedFilter}
            };
                //Add goto here to show details
                await Shell.Current.GoToAsync("monkeyFilter", navParam);
        }


        #endregion

    }
}
