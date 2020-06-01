using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using SQLite;

namespace XFTest.Models
{
    public partial class Carwashvisit
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("carwashVisitDetails")]
        public ObservableCollection<CarwashVisitDetails> CarwashVisitDetails { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }
    }

    public partial class CarwashVisitDetails
    {
        [JsonProperty("visitId")]
        [PrimaryKey, AutoIncrement]
        public Guid VisitId { get; set; }

        [JsonProperty("homeBobEmployeeId")]
        public Guid HomeBobEmployeeId { get; set; }

        [JsonProperty("houseOwnerId")]
        public Guid HouseOwnerId { get; set; }

        [JsonProperty("isBlocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("startTimeUtc")]
        public DateTimeOffset StartTimeUtc { get; set; }

        [JsonProperty("endTimeUtc")]
        public DateTimeOffset EndTimeUtc { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("isReviewed")]
        public bool IsReviewed { get; set; }

        [JsonProperty("isFirstVisit")]
        public bool IsFirstVisit { get; set; }

        [JsonProperty("isManual")]
        public bool IsManual { get; set; }

        [JsonProperty("visitTimeUsed")]
        public long VisitTimeUsed { get; set; }

        [JsonProperty("rememberToday")]
        public bool RememberToday { get; set; }

        [JsonProperty("houseOwnerFirstName")]
        public string HouseOwnerFirstName { get; set; }

        [JsonProperty("houseOwnerLastName")]
        public string HouseOwnerLastName { get; set; }

        [JsonProperty("houseOwnerMobilePhone")]
        public string HouseOwnerMobilePhone { get; set; }

        [JsonProperty("houseOwnerAddress")]
        public string HouseOwnerAddress { get; set; }

        [JsonProperty("houseOwnerZip")]
        public long HouseOwnerZip { get; set; }

        [JsonProperty("houseOwnerCity")]
        public string HouseOwnerCity { get; set; }

        [JsonProperty("houseOwnerLatitude")]
        public double HouseOwnerLatitude { get; set; }

        [JsonProperty("houseOwnerLongitude")]
        public double HouseOwnerLongitude { get; set; }

        [JsonProperty("isSubscriber")]
        public bool IsSubscriber { get; set; }

        [JsonProperty("rememberAlways")]
        public bool RememberAlways { get; set; }

        [JsonProperty("professional")]
        public string Professional { get; set; }

        [JsonProperty("visitState")]
        public string VisitState { get; set; }

        [JsonProperty("stateOrder")]
        public long StateOrder { get; set; }

        [JsonProperty("expectedTime")]
        public string ExpectedTime { get; set; }

        [JsonProperty("tasks")]
        public List<TaskDetails> Tasks { get; set; }


        [JsonIgnore]
        public string HouseOwnerName => HouseOwnerFirstName + " " + HouseOwnerLastName;

        [JsonIgnore]
        public string BackGroundColorForState
        {
            get {

                string colorCode = string.Empty;
                if (VisitState == "ToDo")
                {
                    colorCode = "#4E77D6";
                }

                if (VisitState == "InProgress")
                {
                    colorCode = "#F5C709";
                }
                if (VisitState == "Done")
                {
                    colorCode = "#25A87B";
                }
                if (VisitState == "Rejected")
                {
                    colorCode = "#EF6565";
                }
                return colorCode;
            }
        }

        [JsonIgnore]
        public string TaskToDo
        {
            get
            {
                string TaskDetails = string.Empty;
                foreach (var item in Tasks)
                {
                    if (string.IsNullOrEmpty(TaskDetails))
                    {
                        TaskDetails += item.Title;
                    }
                    else
                    {
                        TaskDetails += "," + item.Title;
                    }
                }
                return TaskDetails;
            }
        }

        [JsonIgnore]
        public long TaskToDoTimeInMinute
        {
            get
            {
                long TaskDetailsTime = 0;
                foreach (var item in Tasks)
                {
                    
                        TaskDetailsTime += item.TimesInMinutes;
                   
                }
                return TaskDetailsTime;
            }
        }

        [JsonIgnore]
        public string TaskToDoNextDistance { get; set; }
        


        [JsonIgnore]
        public string ServiceStartEndTime
        {
            get
            {
                string DateTime = String.Empty;
                if(StartTimeUtc != null &&  !string.IsNullOrEmpty(ExpectedTime) )
                {
                    DateTime = StartTimeUtc.ToString("t") + "/" + ExpectedTime.Replace("/", "-");
                }
               else if(StartTimeUtc != null)
                {
                    DateTime = StartTimeUtc.ToString("t");
                }

                return DateTime;
            }

        }

        [JsonIgnore]
        public string HouseOwnerAdd => HouseOwnerAddress + " " + HouseOwnerZip + " " + HouseOwnerCity;


        [JsonIgnore]
        public string RequiredServiceTimeTaskToDo
        {
            get
            {
                long TaskTime =0;
                foreach (var item in Tasks)
                {
                   
                        TaskTime += TaskTime + item.TimesInMinutes;
                   
                }
                return TaskTime.ToString();
            }
        }
        //[JsonProperty("visitAssets")]
        //public List<VisitAssets> VisitAssets { get; set; }

        //[JsonProperty("visitMessages")]
        //public List<VisitMessages> VisitMessages { get; set; }


    }

    public class VisitMessages
    {
        string message { get; set; }
    }

    public class VisitAssets
    {
        string message { get; set; }
    }

    public class HouseOwnerAssets
    {
        string message { get; set; }
    }

    public class TaskDetails
    {
        [JsonProperty("taskId")]
        public Guid TaskId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("isTemplate")]
        public bool IsTemplate { get; set; }

        [JsonProperty("timesInMinutes")]
        public long TimesInMinutes { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("paymentTypeId")]
        public Guid PaymentTypeId { get; set; }

        [JsonProperty("createDateUtc")]
        public DateTimeOffset CreateDateUtc { get; set; }

        [JsonProperty("lastUpdateDateUtc")]
        public DateTimeOffset LastUpdateDateUtc { get; set; }

        [JsonProperty("paymentTypes")]
        public string PaymentTypes { get; set; }
    }
}

