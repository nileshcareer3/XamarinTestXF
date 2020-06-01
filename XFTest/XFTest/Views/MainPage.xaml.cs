using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using XFTest.Models;

namespace XFTest.Views
{
    public partial class MainPage : ContentPage
    {

        public static string filename = "JsonFile";
        public static string name = "Name"; 
        public MainPage()
        {
            InitializeComponent();

            string fileName = "XF-Test-Json";

            string filePath = Path.GetFullPath(fileName);
            FileInfo fileInfo = new FileInfo(fileName);
            string json = "{\"success\":true,\"message\":\"Got visits successfully\",\"data\":[{\"visitId\":\"799d7830-a5ff-4a0b-b571-9052df6a2e64\",\"homeBobEmployeeId\":\"85f99bd7-ffd2-4ca7-1174-08d7984a4cf3\",\"houseOwnerId\":\"4ad40a8b-8c55-45a3-9b81-b87527f5cf93\",\"isBlocked\":false,\"startTimeUtc\":\"2020-04-29T08:05:00\",\"endTimeUtc\":\"2020-04-29T08:35:00\",\"title\":\"Add title\",\"isReviewed\":false,\"isFirstVisit\":false,\"isManual\":false,\"visitTimeUsed\":0,\"rememberToday\":null,\"houseOwnerFirstName\":\"Tone\",\"houseOwnerLastName\":\"Holtermann\",\"houseOwnerMobilePhone\":\"+4520934021\",\"houseOwnerAddress\":\"Akademivej 15, 1 th\",\"houseOwnerZip\":\"2800\",\"houseOwnerCity\":\"Kgs. Lyngby\",\"houseOwnerLatitude\":55.77883,\"houseOwnerLongitude\":12.52124,\"isSubscriber\":false,\"rememberAlways\":null,\"professional\":\"Test\",\"visitState\":\"Done\",\"stateOrder\":1,\"expectedTime\":\"08:00"+"/"+"10:00\",\"tasks\":[{\"taskId\":\"e4131f30-6beb-45aa-9fcf-02758f332219\",\"title\":\"Pudsning indvendig\",\"isTemplate\":false,\"timesInMinutes\":25,\"price\":99,\"paymentTypeId\":\"51d14bdf-8d83-49fa-843d-787ceba4bb40\",\"createDateUtc\":\"2020-04-29T20:01:56.8831511\",\"lastUpdateDateUtc\":\"2020-04-29T20:01:56.8831539\",\"paymentTypes\":null},{\"taskId\":\"56ed0718-2854-4b11-8fde-8a3c573c9283\",\"title\":\"Pudsning udvendig\",\"isTemplate\":false,\"timesInMinutes\":35,\"price\":199,\"paymentTypeId\":\"9f40509b-191d-4c61-946e-0e816b63088d\",\"createDateUtc\":\"2020-04-29T20:01:26.2182451\",\"lastUpdateDateUtc\":\"2020-04-29T20:01:26.2182775\",\"paymentTypes\":null}],\"houseOwnerAssets\":[],\"visitAssets\":[],\"visitMessages\":[]},{\"visitId\":\"eefa3ba5-0aa8-42a4-a7b3-cd6d3939473e\",\"homeBobEmployeeId\":\"85f99bd7-ffd2-4ca7-1174-08d7984a4cf3\",\"houseOwnerId\":\"8572e4a1-bb98-48b8-a4ae-4411d2e6b39b\",\"isBlocked\":false,\"startTimeUtc\":\"2020-04-29T08:40:00\",\"endTimeUtc\":\"2020-04-29T09:10:00\",\"title\":\"Add title\",\"isReviewed\":false,\"isFirstVisit\":false,\"isManual\":false,\"visitTimeUsed\":0,\"rememberToday\":null,\"houseOwnerFirstName\":\"Kenn\",\"houseOwnerLastName\":\"J\u00f8rgensen\",\"houseOwnerMobilePhone\":\"+4520441443\",\"houseOwnerAddress\":\"Kornagervej 67\",\"houseOwnerZip\":\"2800\",\"houseOwnerCity\":\"Kgs. Lyngby\",\"houseOwnerLatitude\":55.77453,\"houseOwnerLongitude\":12.51967,\"isSubscriber\":false,\"rememberAlways\":null,\"professional\":\"Test\",\"visitState\":\"InProgress\",\"stateOrder\":3,\"expectedTime\":null,\"tasks\":[{\"taskId\":\"33a44066-560e-4294-9f7d-af28e0d2db04\",\"title\":\"Pudsning udvendig\",\"isTemplate\":false,\"timesInMinutes\":45,\"price\":199,\"paymentTypeId\":\"9f40509b-191d-4c61-946e-0e816b63088d\",\"createDateUtc\":\"2020-04-29T20:03:18.9444727\",\"lastUpdateDateUtc\":\"2020-04-29T20:03:18.9444755\",\"paymentTypes\":null}],\"houseOwnerAssets\":[],\"visitAssets\":[],\"visitMessages\":[]},{\"visitId\":\"ec94deca-d66a-4d62-b049-72414870de00\",\"homeBobEmployeeId\":\"85f99bd7-ffd2-4ca7-1174-08d7984a4cf3\",\"houseOwnerId\":\"9f2efc9b-c275-474c-aec9-4f9bd063b46a\",\"isBlocked\":false,\"startTimeUtc\":\"2020-04-29T09:15:00\",\"endTimeUtc\":\"2020-04-29T09:40:00\",\"title\":\"Add title\",\"isReviewed\":false,\"isFirstVisit\":false,\"isManual\":false,\"visitTimeUsed\":0,\"rememberToday\":null,\"houseOwnerFirstName\":\"Mads\",\"houseOwnerLastName\":\"Kolding\",\"houseOwnerMobilePhone\":\"+4531952906\",\"houseOwnerAddress\":\"Sorgenfrig\u00e5rdsvej 54 st th\",\"houseOwnerZip\":\"2800\",\"houseOwnerCity\":\"Lyngby\",\"houseOwnerLatitude\":55.7765,\"houseOwnerLongitude\":12.5127,\"isSubscriber\":false,\"rememberAlways\":null,\"professional\":\"Test\",\"visitState\":\"ToDo\",\"stateOrder\":2,\"expectedTime\":null,\"tasks\":[{\"taskId\":\"9a5f6a07-aad8-4510-8686-de8a2b824113\",\"title\":\"Pudsning udvendig\",\"isTemplate\":false,\"timesInMinutes\":35,\"price\":175,\"paymentTypeId\":\"9f40509b-191d-4c61-946e-0e816b63088d\",\"createDateUtc\":\"2020-04-29T20:04:07.3063091\",\"lastUpdateDateUtc\":\"2020-04-29T20:04:07.3063118\",\"paymentTypes\":null}],\"houseOwnerAssets\":[],\"visitAssets\":[],\"visitMessages\":[]}],\"code\":200}";


            Carwashvisit carwashVisitDetails = JsonConvert.DeserializeObject<Carwashvisit>(json,new JsonSerializerSettings {  NullValueHandling = NullValueHandling.Ignore});
          
            GenrateDatabase(carwashVisitDetails);
        }

        private async void GenrateDatabase(Carwashvisit carwashvisit)
        {
            try
            {

                //foreach (var carwashVisitDetails in carwashvisit.CarwashVisitDetails)
                //{
                //    DataBase.CarwashVisitDetails carwashVisit = new DataBase.CarwashVisitDetails
                //    {
                //        VisitId = carwashVisitDetails.VisitId,
                //        HomeBobEmployeeId = carwashVisitDetails.VisitId,
                //        HouseOwnerId = carwashVisitDetails.VisitId,
                //        IsBlocked = carwashVisitDetails.IsBlocked,
                //        StartTimeUtc = carwashVisitDetails.StartTimeUtc,
                //        EndTimeUtc = carwashVisitDetails.EndTimeUtc,
                //        Title = carwashVisitDetails.Title,
                //        IsReviewed = carwashVisitDetails.IsReviewed,
                //        IsFirstVisit = carwashVisitDetails.IsFirstVisit,
                //        IsManual = carwashVisitDetails.IsManual,
                //        VisitTimeUsed = carwashVisitDetails.VisitTimeUsed,
                //        RememberToday = carwashVisitDetails.RememberToday,
                //        HouseOwnerFirstName = carwashVisitDetails.HouseOwnerFirstName,
                //        HouseOwnerLastName = carwashVisitDetails.HouseOwnerLastName,
                //        HouseOwnerMobilePhone = carwashVisitDetails.HouseOwnerMobilePhone,
                //        HouseOwnerAddress = carwashVisitDetails.HouseOwnerAddress,
                //        HouseOwnerZip = carwashVisitDetails.HouseOwnerZip,
                //        HouseOwnerCity = carwashVisitDetails.HouseOwnerCity,
                //        HouseOwnerLatitude = carwashVisitDetails.HouseOwnerLatitude,
                //        HouseOwnerLongitude = carwashVisitDetails.HouseOwnerLongitude,
                //        IsSubscriber = carwashVisitDetails.IsSubscriber,
                //        RememberAlways = carwashVisitDetails.RememberAlways,
                //        Professional = carwashVisitDetails.Professional,
                //        VisitState = carwashVisitDetails.VisitState,
                //        StateOrder = carwashVisitDetails.StateOrder,
                //        ExpectedTime = carwashVisitDetails.ExpectedTime,
                //    };
                //    await App.Database.SaveCarWashDetailsAsync(carwashVisit);
                //    foreach (var item in carwashVisitDetails.Tasks)
                //    {
                //        await App.Database.SaveTaskDetailsAsync(new DataBase.TaskDetails
                //        {
                //            VisitTaskId = carwashVisitDetails.VisitId.ToString(),
                //            TaskId = item.TaskId,
                //            Title = item.Title,
                //            TimesInMinutes = item.TimesInMinutes,
                //            IsTemplate = item.IsTemplate,
                //            Price = item.Price,
                //            PaymentTypeId = item.PaymentTypeId,
                //            PaymentTypes = item.PaymentTypes,
                //            CreateDateUtc = item.CreateDateUtc,
                //            LastUpdateDateUtc = item.LastUpdateDateUtc
                //        });
                //    }

                //}

                var data = await App.Database.GetCarwashVisitDetailsAsync();
            }
            catch (Exception ex)
            {

            }

        }

        public static string fileextension = ".json";
        public static string Folderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static bool JsonWrite(string filename, string JsonData)
        {
            try
            {
                var filepath = Path.Combine(Folderpath, filename + fileextension);
                File.WriteAllText(filepath, JsonData);
                Console.WriteLine(true.ToString());
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static string JsonReader(string filename, string fieldname)
        {
            try
            {
                var filepath = Path.Combine(Folderpath, filename + fileextension);
                var content = File.ReadAllText(filepath);
                JObject obj = JObject.Parse(content);
                return obj[fieldname].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        private async void BtnCleaningList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.CleaningList());
        }

        private async void btnCalendar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calendar());
        }

    }
}