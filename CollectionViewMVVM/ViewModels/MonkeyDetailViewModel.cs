using CollectionViewMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewMVVM.ViewModels
{
    [QueryProperty(nameof(SelectedMonkey), "selectedMonkey")]

    public class MonkeyDetailViewModel : ViewModelBase
    {
        private Monkey selectedMonkey;
        public Monkey SelectedMonkey
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
    }
}
