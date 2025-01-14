﻿using CollectionViewMVVM.Models;
using CollectionViewMVVM.Services;
using ShellLesson.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                OnSingleSelectMonkey();
            }
        }


        async void OnSingleSelectMonkey()
        {
            if (selectedFilter != null)
            {
                List<Monkey> list = new List<Monkey>();
                List<Monkey> lst = new List<Monkey>();
                MonkeyService service = new MonkeyService();
                if (SelectedFilter == "all")
                {
                    lst = await service.GetMonkeys();

                }
                else
                {
                    list = await service.GetMonkeys();
                    lst = new List<Monkey>();
                    foreach (Monkey monkey in list)
                    {
                        if (monkey.Location.Contains(selectedFilter))
                        {
                            lst.Add(monkey);
                        }
                    }
                }
                    var navParam = new Dictionary<string, object>()
            {
                { "selectedFilter",lst}
            };
                    //Add goto here to show details
                    await Shell.Current.GoToAsync("monkeyFilter", navParam);
                
            }
            
        }


        #endregion

    }
}
