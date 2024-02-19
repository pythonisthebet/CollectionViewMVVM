using CollectionViewMVVM.Models;
using CollectionViewMVVM.Services;
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
            List<Monkey> list;
            MonkeyService service = new MonkeyService();
            if (SelectedFilter == "all")
            {
                list = await service.GetMonkeys();

            }
            else
            {
                list = await service.GetMonkeysByLocation(SelectedFilter);
            }
            if (SelectedFilter != null)
            {
                var navParam = new Dictionary<string, object>()
            {
                { "selectedFilter",list}
            };
                //Add goto here to show details
                await Shell.Current.GoToAsync("monkeyFilter", navParam);
            }
        }


        #endregion

    }
}
