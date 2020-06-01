using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Mvvm;
using Xamarin.Forms;

namespace XFTest.Models
{
    public class CalenderClass : BindableBase
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string _MonthYear;
        public string MonthYear
        {

            get { return _MonthYear; }
            set
            {
                _MonthYear = value;
                RaisePropertyChanged("MonthYear");
            }
        }
        public ObservableCollection<MonthDayDate> ListOfMonthDetails { get; set; }

     
    }

    public class MonthDayDate  : BindableBase
    {
        public int Date { get; set; }
        public DateTime ShownDate { get; set; }
        public string Day { get; set; }
        public bool IsSelected { get; set; }
        public string _IsSelectedColor = "#25A87B";
        public string IsSelectedColor
        {

            get { return _IsSelectedColor; }
            set
            {
                _IsSelectedColor = value;
                RaisePropertyChanged("IsSelectedColor");
            }
        }


        public ICommand ShowDialogCommand { get; set; }

        private ICommand isSelected;

        public ICommand IsSelect
        {
            get
            {
                isSelected = isSelected ?? new Command(ProcessToSelect);
                return isSelected;
            }
        }

        private void ProcessToSelect()
        {
            ShowDialogCommand?.Execute(this);
        }


        //public event PropertyChangedEventHandler PropertyChanged;
        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
