//using Microsoft.OData.Edm;
//using MySpace.Entities.Data;
//using MySpace.Entities.ViewModel;
//using MySpace.Repository.Interface;
////using MySpace.Repository.Models;
//using MySpace;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace MySpace.Repository
//{
//    public class MyDayRepository : IMyDayRepository
//    {
//        private readonly AppDbContext context;
//        public MyDayRepository(AppDbContext context)
//        {
//            this.context = context;
//        }
//        public MyDayViewModel GetCurrentDayData(int timeDifference)
//        {
//            Date currentLocalDate = DateTime.UtcNow.AddMinutes(-timeDifference).Date;
//            MyDayViewModel model = context.Days.Where(x => x.LocalDate == currentLocalDate)?.FirstOrDefault();
//            return model;
//        }

//        public IEnumerable<MyDayViewModel> GetAllDaysData()
//        {
//            var data = context.Days;
//            return data.OrderByDescending(x=>x.LocalDate);
//        }
//        public MyDayViewModel AddDayData(MyDayViewModel model)
//        {
//            context.Days.Add(model);
//            context.SaveChanges();
//            return model;
//        }
//        public MyDayViewModel DeleteDayDataById(int id)
//        {
//            MyDayViewModel model = context.Days.Find(id);
//            if(model != null)
//            {
//                context.Days.Remove(model);
//                context.SaveChanges();
//            }
//            return model;
//        }

//        public MyDayViewModel UpdateDayData(MyDayViewModel updatedData)
//        {
//            var model = context.Days.Attach(updatedData);
//            model.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            context.SaveChanges();
//            return updatedData; 
//        }
//    }
//}
