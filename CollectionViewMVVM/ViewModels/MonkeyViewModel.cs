using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionViewMVVM.Services;
using CollectionViewMVVM.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ShellLesson.ViewModels;

namespace CollectionViewMVVM.ViewModels
{
    [QueryProperty(nameof(SelectedFilter), "selectedFilter")]
    public class MonkeyViewModel: ViewModelBase
    {
        private bool isRefreshing;
        private ObservableCollection<Monkey> monkeys;
        public ObservableCollection<Monkey> Monkeys
        {
            get
            {
                return this.monkeys;
            }
            set
            {
                this.monkeys = value;
                OnPropertyChanged();
            }
        }
        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                this.isRefreshing = value;
                OnPropertyChanged();
            }
        }
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
        private MonkeyService monkeysService;
        public MonkeyViewModel(MonkeyService service)
        {
            this.monkeysService = service;
            monkeys = new ObservableCollection<Monkey>();
            ReadMonkeys();
        }

        private async void ReadMonkeys()
        {
            MonkeyService service = this.monkeysService;
            List<Monkey> list = await service.GetMonkeys();
            foreach (Monkey monkey in list)
            {
                if (monkey.Location != selectedFilter)
                {
                    list.Remove(monkey);
                }
            }
            this.Monkeys = new ObservableCollection<Monkey>(list);
        }


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



        public ICommand DeleteCommand => new Command<Monkey>(RemoveMonkey);

        public void RemoveMonkey(Monkey monkey)
        {
            if (monkeys.Contains(monkey))
            {
                Monkeys.Remove(monkey);
            }
        }

        public ICommand RefreshCommand => new Command(Refresh);
        private async void Refresh()
        {
            Monkeys.Add(new Monkey
            {
                Name = "Monkey",
                Location = "Israel",
                Details = "Born Today!",
                ImageUrl = "new_monkey.png",
                IsFavorite = false
            });
            IsRefreshing = false;
            ReadMonkeys();
        }

        
    }

}
