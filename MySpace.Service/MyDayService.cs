//using MySpace.Entities.ViewModel;
//using MySpace.Repository.Interface;
//using MySpace.Service.Interface;
//using System;
//using System.Collections.Generic;

//namespace MySpace.Service
//{
//    public class MyDayService : IMyDayService
//    {
//        private readonly IMyDayRepository _myDayRepository;

//        public MyDayService(IMyDayRepository myDayRepository)
//        {
//            this._myDayRepository = myDayRepository;
//        }
//        public MyDayViewModel AddDayData(MyDayViewModel model)
//        {
//            return _myDayRepository.AddDayData(model);
//        }

//        public MyDayViewModel DeleteDayDataById(int id)
//        {
//            return _myDayRepository.DeleteDayDataById(id);
//        }

//        public IEnumerable<MyDayViewModel> GetAllDaysData()
//        {
//            return _myDayRepository.GetAllDaysData();
//        }

//        public MyDayViewModel GetCurrentDayData(int timeDifference)
//        {
//            return _myDayRepository.GetCurrentDayData(timeDifference);
//        }

//        public MyDayViewModel UpdateDayData(MyDayViewModel model)
//        {
//            return _myDayRepository.UpdateDayData(model);
//        }
//    }
//}
