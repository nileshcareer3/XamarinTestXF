using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XFTest.Models;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using Acr.UserDialogs;
using XFTest.Comman;
using XFTest.Services;
using XFTest.Utility;
using XFTest.Services.IServices;
using XFTest.Services.Repository;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Globalization;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;

namespace XFTest.ViewModels
{

 
    public class CleaningListViewModel : BindableBase //, INotifyPropertyChanged
    {


        private CarWashListService carWashListService;
        private ICarWashListService CarWashListtRepository;


        readonly IList<CarwashVisitDetails> source;

        public ObservableCollection<CleaningList> Monkeys { get; private set; }


        //readonly ObservableCollection<CarwashVisitDetails> source;

        private ObservableCollection<CarwashVisitDetails> _CarVisitList;
        public ObservableCollection<CarwashVisitDetails> CarVisitList
        {
            get
            {
                return _CarVisitList;
            }
            set
            {
                _CarVisitList = value;
                RaisePropertyChanged("CarVisitList");
            }
        }

        private ObservableCollection<CarwashVisitDetails> _DisplayCarVisitList;
        public ObservableCollection<CarwashVisitDetails> DisplayCarVisitList
        {
            get
            {
                return _DisplayCarVisitList;
            }
            set
            {
                _DisplayCarVisitList = value;
                RaisePropertyChanged("DisplayCarVisitList");
            }
        }

        private bool _IsCalenderShown;
        public bool IsCalenderShown
        {
            get
            {
                return _IsCalenderShown;
            }
            set
            {
                _IsCalenderShown = value;
                RaisePropertyChanged("IsCalenderShown");
            }
        }

        private CalenderClass _calenderClass;
        public CalenderClass CalenderClass
        {
            get
            {
                return _calenderClass;
            }
            set
            {
                _calenderClass = value;
                RaisePropertyChanged("CalenderClass");
            }
        }

        private ObservableCollection<MonthDayDate> _ListOfMonthDetails;
        public ObservableCollection<MonthDayDate> ListOfMonthDetails
        {
            get
            {
                return _ListOfMonthDetails;
            }
            set
            {
                _ListOfMonthDetails = value;
                RaisePropertyChanged("ListOfMonthDetails");
            }
        }


        private ObservableCollection<MonthDayDate> _ListOfSelectedMonthDetails;
        public ObservableCollection<MonthDayDate> ListOfSelectedMonthDetails
        {
            get
            {
                return _ListOfSelectedMonthDetails;
            }
            set
            {
                _ListOfSelectedMonthDetails = value;
                RaisePropertyChanged("ListOfSelectedMonthDetails");
            }
        }

        #region Commands

        private ICommand _ShowDialogCommand;
        public ICommand ShowDialogCommand
        {
            get
            {
                _ShowDialogCommand = _ShowDialogCommand ??  new Command(ProcessToShowCalender);
                return _ShowDialogCommand;
            }
          
        }

        private ICommand _isSelectedDateCommand;
        public ICommand SelectedDateCommand
        {
            get
            {
                _isSelectedDateCommand = _isSelectedDateCommand ?? new Command(ProcessToSelectedDateCommand);
                return _isSelectedDateCommand;
            }

        }

        private ICommand _ShowPreviousMonthCommand;
        public ICommand ShowPreviousMonthCommand
        {
            get
            {
                _ShowPreviousMonthCommand = _ShowPreviousMonthCommand ?? new Command(ProcessToShowPreviousMonthCommand);
                return _ShowPreviousMonthCommand;
            }

        }

       
        private ICommand _ShowNextsMonthCommand;
        public ICommand ShowNextMonthCommand
        {
            get
            {
                _ShowNextsMonthCommand = _ShowNextsMonthCommand ?? new Command(ProcessToShowNextMonthCommand);
                return _ShowNextsMonthCommand;
            }

        }

       



        #endregion

        public CleaningListViewModel()
        {
            source = new ObservableCollection<CarwashVisitDetails>();

            this.CarWashListtRepository = new CarWashListRepository();
            this.carWashListService = new CarWashListService(this.CarWashListtRepository);
            IsCalenderShown = false;
            CreateCarVashVisitCollection();

            CalenderClass = new CalenderClass();
            CalenderClass.Year = DateTime.Today.Year;
            CalenderClass.Month = DateTime.Today.Month;

            LoadCarWashVisitList();
           
        }

        private void LoadCarWashVisitList()
        {
            try
            {
                CalenderClass.MonthYear = new DateTime(CalenderClass.Year, CalenderClass.Month, 1).ToString("MMM", CultureInfo.InvariantCulture) + " " + CalenderClass.Year;
                CalenderClass.ListOfMonthDetails = new ObservableCollection<MonthDayDate>();
                int startMonth = DateTime.DaysInMonth(CalenderClass.Year, CalenderClass.Month);
                for (int i = 1; i <= startMonth; i++)
                {
                    string date = new DateTime(CalenderClass.Year, CalenderClass.Month, i).ToString("yyyy-MM-dd");
                    DateTime dateTime = Convert.ToDateTime(date);
                    CalenderClass.ListOfMonthDetails.Add(new MonthDayDate { Date = i, IsSelected = false, ShowDialogCommand = SelectedDateCommand, ShownDate = dateTime, Day = dateTime.ToString("ddd") });
                }
                ListOfMonthDetails = CalenderClass.ListOfMonthDetails;
                LoadDateWiseList();

               
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(new AlertConfig { Message = ex.Message, OkText = AppResources.BtnTitle_Ok });
            }
        }

        private void LoadDateWiseList()
        {
            try
            {
                DisplayCarVisitList = new ObservableCollection<CarwashVisitDetails>();
                var selectedDate = ListOfMonthDetails.Where(item => item.IsSelected == true);

                foreach (var item in selectedDate)
                {

                    var selectedDateDetails = CarVisitList.Where(select => Convert.ToDateTime(select.StartTimeUtc.ToString("yyyy-MM-dd")) == item.ShownDate);

                    if(DisplayCarVisitList != null && DisplayCarVisitList.Count == 0)
                    {
                        DisplayCarVisitList = new ObservableCollection<CarwashVisitDetails>(selectedDateDetails.ToList());
                    }
                    else
                    {
                        foreach (var singleitem in selectedDateDetails)
                        {
                            CarwashVisitDetails carwashVisitDetails = singleitem as CarwashVisitDetails;
                            DisplayCarVisitList.Add(carwashVisitDetails);
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(new AlertConfig { Message = ex.Message, OkText = AppResources.BtnTitle_Ok });
            }
        }

        private async void CreateCarVashVisitCollection()
        {

            try
            {
              
                var response =  await this.carWashListService.ProcessToGetCarWashList();
                if (response != null)
                {
                    if (response.Code == Constants.SuccessCode)
                    {
                        double previousDistance = 0f;
                        int itemCount = 0;
                        foreach (var item in response.CarwashVisitDetails)
                        {
                            double distance = item.HouseOwnerLatitude + item.HouseOwnerLongitude;
                            if (itemCount > 0)
                            {
                                previousDistance += distance;
                                item.TaskToDoNextDistance = previousDistance.ToString() + " Km";
                                previousDistance = 0 + distance;
                            }
                            itemCount++;
                            source.Add(item);
                            
                        }

                        CarVisitList = new ObservableCollection<CarwashVisitDetails>(source);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert(response.Message, null, AppResources.BtnTitle_Ok);
                    }
                }

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(new AlertConfig { Message = ex.Message, OkText = AppResources.BtnTitle_Ok });
            }
        }

        private void ProcessToShowCalender(object obj)
        {
            if (IsCalenderShown)
            {
                IsCalenderShown = false;
            }
            else
            {
                IsCalenderShown = true;
            }
        }

        private void ProcessToSelectedDateCommand(object obj)
        {
            try
            {
                MonthDayDate monthDayDate = obj as MonthDayDate;
                var item = CalenderClass.ListOfMonthDetails.FirstOrDefault(i => i.Date == monthDayDate.Date);
                if (item != null)
                {
                    if (item.Date == monthDayDate.Date && item.IsSelected == false)
                    {
                        item.IsSelected = true;
                        item.IsSelectedColor = "#368268";
                    }
                    else if (item.Date == monthDayDate.Date && item.IsSelected == true)
                    {
                        item.IsSelected = false;
                        item.IsSelectedColor = "#25A87B";
                    }
                   
                }
                LoadDateWiseList();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(new AlertConfig { Message = ex.Message, OkText = AppResources.BtnTitle_Ok });
            }
         



        }

        private void ProcessToShowNextMonthCommand(object obj)
        {
           
            try
            {
                if (CalenderClass.Month == 12)
                {
                    CalenderClass.Year = CalenderClass.Year + 1;
                }
                else
                {
                    CalenderClass.Month++;
                }
                LoadCarWashVisitList();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(new AlertConfig { Message = ex.Message, OkText = AppResources.BtnTitle_Ok });
            }
        }

        private void ProcessToShowPreviousMonthCommand(object obj)
        {
            try
            {
                if (CalenderClass.Month == 1)
                {
                    CalenderClass.Year = CalenderClass.Year - 1;
                }
                else
                {
                    CalenderClass.Month--;
                }
                LoadCarWashVisitList();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(new AlertConfig { Message = ex.Message, OkText = AppResources.BtnTitle_Ok });
            }
           
        }

    }
}
