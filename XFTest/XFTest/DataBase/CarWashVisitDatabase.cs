using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;

namespace XFTest.DataBase
{
    public class CarWashVisitDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public CarWashVisitDatabase(string dbPath)
        {
            try
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<CarwashVisitDetails>().Wait();
                _database.CreateTableAsync<TaskDetails>().Wait();
            }
            catch (Exception ex)
            {

            }
          
        }

        public Task<List<CarwashVisitDetails>> GetCarwashVisitDetailsAsync()
        {
            _database.Table<CarwashVisitDetails>().ToListAsync();

            return _database.Table<CarwashVisitDetails>().ToListAsync();
        }

        public Task<List<TaskDetails>> GetTaskDetailsAsync()
        {
            return _database.Table<TaskDetails>().ToListAsync();
        }

        public Task<int> SaveCarWashDetailsAsync(CarwashVisitDetails carwashVisitDetails)
        {
            return _database.InsertAsync(carwashVisitDetails);
        }

        public Task<int> SaveTaskDetailsAsync(TaskDetails taskDetails)
        {
            return _database.InsertAsync(taskDetails);
        }
    }
}
