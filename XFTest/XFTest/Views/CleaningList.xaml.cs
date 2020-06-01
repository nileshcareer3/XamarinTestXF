using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XFTest.ViewModels;
using Prism.Services.Dialogs;

namespace XFTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningList : ContentPage
    {
        public static CleaningListViewModel ViewModel;
        public CleaningList()
        {
            InitializeComponent();
            //ViewModel = new CleaningListViewModel();
            //BindingContext = ViewModel;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var state= width < 280 ? "Small" : width < 360 ? "Medium" : "Large";
            VisualStateManager.GoToState(PageHeading, state);
            var state1 = width < 280 ? "Small" : width == 320 ? "Small" : width < 380 ? "Medium" : "Large";
           // VisualStateManager.GoToState(dayLbl01, state1);
           
            /*VisualStateManager.GoToState(dayLbl15, state);
            VisualStateManager.GoToState(dayLbl16, state);
            VisualStateManager.GoToState(dayLbl17, state);
            VisualStateManager.GoToState(dayLbl18, state);
            VisualStateManager.GoToState(dayLbl19, state);
            VisualStateManager.GoToState(dayLbl20, state);
            VisualStateManager.GoToState(dayLbl21, state);
            VisualStateManager.GoToState(dayLbl22, state);
            VisualStateManager.GoToState(dayLbl23, state);
            VisualStateManager.GoToState(dayLbl24, state);
            VisualStateManager.GoToState(dayLbl25, state);
            VisualStateManager.GoToState(dayLbl26, state);
            VisualStateManager.GoToState(dayLbl27, state);
            VisualStateManager.GoToState(dayLbl28, state);
            VisualStateManager.GoToState(dayLbl29, state);
            VisualStateManager.GoToState(dayLbl30, state);
            VisualStateManager.GoToState(dayLbl31, state);*/

           // VisualStateManager.GoToState(dateLbl01, state1);
          
            /*VisualStateManager.GoToState(dateLbl15, state);
            VisualStateManager.GoToState(dateLbl16, state);
            VisualStateManager.GoToState(dateLbl17, state);
            VisualStateManager.GoToState(dateLbl18, state);
            VisualStateManager.GoToState(dateLbl19, state);
            VisualStateManager.GoToState(dateLbl20, state);
            VisualStateManager.GoToState(dateLbl21, state);
            VisualStateManager.GoToState(dateLbl22, state);
            VisualStateManager.GoToState(dateLbl23, state);
            VisualStateManager.GoToState(dateLbl24, state);
            VisualStateManager.GoToState(dateLbl25, state);
            VisualStateManager.GoToState(dateLbl26, state);
            VisualStateManager.GoToState(dateLbl27, state);
            VisualStateManager.GoToState(dateLbl28, state);
            VisualStateManager.GoToState(dateLbl29, state);
            VisualStateManager.GoToState(dateLbl30, state);
            VisualStateManager.GoToState(dateLbl31, state);*/

            //VisualStateManager.GoToState(calPad01, state1);

            /*VisualStateManager.GoToState(calPad15, state);
            VisualStateManager.GoToState(calPad16, state);
            VisualStateManager.GoToState(calPad17, state);
            VisualStateManager.GoToState(calPad18, state);
            VisualStateManager.GoToState(calPad19, state);
            VisualStateManager.GoToState(calPad20, state);
            VisualStateManager.GoToState(calPad21, state);
            VisualStateManager.GoToState(calPad22, state);
            VisualStateManager.GoToState(calPad23, state);
            VisualStateManager.GoToState(calPad24, state);
            VisualStateManager.GoToState(calPad25, state);
            VisualStateManager.GoToState(calPad26, state);
            VisualStateManager.GoToState(calPad27, state);
            VisualStateManager.GoToState(calPad28, state);
            VisualStateManager.GoToState(calPad29, state);
            VisualStateManager.GoToState(calPad30, state);
            VisualStateManager.GoToState(calPad31, state);*/

            /*VisualStateManager.GoToState(calPadInr01, state);
            VisualStateManager.GoToState(calPadInr02, state);
            VisualStateManager.GoToState(calPadInr03, state);
            VisualStateManager.GoToState(calPadInr04, state);
            VisualStateManager.GoToState(calPadInr05, state);
            VisualStateManager.GoToState(calPadInr06, state);
            VisualStateManager.GoToState(calPadInr07, state);
            VisualStateManager.GoToState(calPadInr08, state);
            VisualStateManager.GoToState(calPadInr09, state);
            VisualStateManager.GoToState(calPadInr10, state);
            VisualStateManager.GoToState(calPadInr11, state);
            VisualStateManager.GoToState(calPadInr12, state);
            VisualStateManager.GoToState(calPadInr13, state);
            VisualStateManager.GoToState(calPadInr14, state);
            VisualStateManager.GoToState(calPadInr15, state);
            VisualStateManager.GoToState(calPadInr16, state);
            VisualStateManager.GoToState(calPadInr17, state);
            VisualStateManager.GoToState(calPadInr18, state);
            VisualStateManager.GoToState(calPadInr19, state);
            VisualStateManager.GoToState(calPadInr20, state);
            VisualStateManager.GoToState(calPadInr21, state);
            VisualStateManager.GoToState(calPadInr22, state);
            VisualStateManager.GoToState(calPadInr23, state);
            VisualStateManager.GoToState(calPadInr24, state);
            VisualStateManager.GoToState(calPadInr25, state);
            VisualStateManager.GoToState(calPadInr26, state);
            VisualStateManager.GoToState(calPadInr27, state);
            VisualStateManager.GoToState(calPadInr28, state);
            VisualStateManager.GoToState(calPadInr29, state);
            VisualStateManager.GoToState(calPadInr30, state);
            VisualStateManager.GoToState(calPadInr31, state);*/
           
        }

      
    }
}