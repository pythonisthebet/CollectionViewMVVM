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

namespace CollectionViewMVVM.ViewModels
{
    public class MonkeyViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private ObservableCollection<Monkey> monkeys;
        private string selectedNames;
        private ObservableCollection<Object> selectedMonkeys;
        private bool isRefreshing;
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
        public ObservableCollection<Object> SelectedMonkeys
        {
            get
            {
                return this.selectedMonkeys;
            }
            set
            {
                this.selectedMonkeys = value;
                OnPropertyChanged();
            }
        }
        public string SelectedNames
        {
            get
            {
                return this.selectedNames;
            }
            set
            {
                this.selectedNames = value;
                OnPropertyChanged();
            }
        }
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


        private async void ReadMonkeys()
        {
            MonkeyService service = new MonkeyService();
            List<Monkey> list = await service.GetMonkeys();
            this.Monkeys = new ObservableCollection<Monkey>(list);
        }
        public MonkeyViewModel()
        {
            monkeys = new ObservableCollection<Monkey>();
            SelectedNames = "none";
            SelectedMonkeys = new ObservableCollection<Object>();
            IsRefreshing = false;
            ReadMonkeys();
        }
        public ICommand DeleteCommand => new Command<Monkey>(RemoveMonkey);

        public void RemoveMonkey(Monkey monkey)
        {
            if (monkeys.Contains(monkey))
            {
                Monkeys.Remove(monkey);
            }
        }
        public ICommand MultipleSelectCommand => new Command(OnMultipleSelectStudent);

        async void OnMultipleSelectStudent()
        {
            if (SelectedMonkeys.Count == 0)
            {
                SelectedNames = "none";
            }
            else
            {
                string temp = ((Monkey)SelectedMonkeys[0]).Name;
                for (int i = 1; i < SelectedMonkeys.Count; i++)
                {
                    temp += $", {((Monkey)SelectedMonkeys[i]).Name}";
                }
                SelectedNames = temp;
            }
        }

        public ICommand SingleSelectCommand => new Command(OnSingleSelectMonkey);

        async void OnSingleSelectMonkey()
        {
            if (SelectedMonkey == null || !(SelectedMonkey is Monkey))
            {
                SelectedNames = "none";
            }
            else
                SelectedNames = ((Monkey)SelectedMonkey).Name;
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
