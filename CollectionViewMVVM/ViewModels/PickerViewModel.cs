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
        private Object selectedMonkey;
        public Object SelectedMonkey
        {
            get
            {
                return this.selectedMonkey;
            }
            set
            {
                this.selectedMonkey = value;
                OnPropertyChanged();
            }
        }

        public ICommand SingleSelectCommand => new Command(OnSingleSelectMonkey);

        async void OnSingleSelectMonkey()
        {
            if (SelectedMonkey != null)
            {
                var navParam = new Dictionary<string, object>()
            {
                { "selectedMonkey",SelectedMonkey}
            };
                //Add goto here to show details
                await Shell.Current.GoToAsync("monkeyDetails", navParam);

                SelectedMonkey = null;
            }
        }


        #endregion

    }
}
