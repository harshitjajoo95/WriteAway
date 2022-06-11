using Microsoft.OData.Edm;
using MySpace.Entities.Data;
using MySpace.Entities.ViewModel;
//using MySpace.Repository.Models;
using MySpace;
using System;
using System.Collections.Generic;
using System.Linq;
using MySpace.Models;

namespace MySpace
{
    public class MyDayRepository : IMyDayRepository
    {
        private readonly ApplicationDbContext context;
        public MyDayRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        //public MyDayViewModel GetCurrentDayData(int timeDifference)
        //{
        //    DateTime currentLocalDate = DateTime.UtcNow.AddMinutes(-timeDifference);
        //    MyDayViewModel model = context.Days.Where(x => x.LocalDateTime.Date == currentLocalDate.Date)?.FirstOrDefault();
        //    return model;
        //}

        /// <summary>
        /// Get user's data by its local date
        /// </summary>
        /// <param name="timeDifference"></param>
        /// <returns></returns>
        public MyDayViewModel GetUsersLocalDayData(int timeDifference)
        {
            DateTime currentLocalDate = DateTime.UtcNow.AddMinutes(-timeDifference);
            MyDayViewModel model = context.Days.Where(x => x.LocalDateTime.Date == currentLocalDate.Date)?.FirstOrDefault();
            return model;
        }
        public MyDayViewModel GetDayDataById(int id)
        {
            MyDayViewModel model = context.Days.Where(x => x.id == id)?.FirstOrDefault();
            return model;
        }
        public string GetCurrentDayWrittenData(int timeDifference)
        {
            DateTime currentLocalDate = DateTime.UtcNow.AddMinutes(-timeDifference);
            string data = context.Days.Where(x => x.LocalDateTime.Date == currentLocalDate.Date)?.FirstOrDefault()?.WrittenData;
            return data;
        }

        public IEnumerable<MyDayViewModel> GetAllDaysData()
        {
            var data = context.Days;
            return data.OrderByDescending(x=>x.LocalDateTime);
        }
        public MyDayViewModel AddDayData(MyDayViewModel model)
        {
            context.Days.Add(model);
            context.SaveChanges();
            return model;
        }
        public MyDayViewModel DeleteDayDataById(int id)
        {
            MyDayViewModel model = context.Days.Find(id);
            if(model != null)
            {
                context.Days.Remove(model);
                context.SaveChanges();
            }
            return model;
        }

        public MyDayViewModel UpdateDayData(MyDayViewModel updatedData)
        {
            var model = context.Days.Attach(updatedData);
            model.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedData; 
        }

        public MyDayViewModel UpdateDayDataById(MyDayViewModel updatedData)
        {
            var model = context.Days
                .Where(s => s.id == updatedData.id)
                .SingleOrDefault();
            model.UtcDateTime = updatedData.UtcDateTime;
            model.WrittenData = updatedData.WrittenData;
            context.SaveChanges();
            return updatedData;
        }
    }
}
