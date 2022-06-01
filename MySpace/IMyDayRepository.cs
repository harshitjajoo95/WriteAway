using MySpace.Entities.ViewModel;
using System;
using System.Collections.Generic;

namespace MySpace
{
    public interface IMyDayRepository
    {
        MyDayViewModel GetCurrentDayData(int timeDifference);
        IEnumerable<MyDayViewModel> GetAllDaysData();
        MyDayViewModel AddDayData(MyDayViewModel model);

        MyDayViewModel DeleteDayDataById(int id);
        MyDayViewModel UpdateDayData(MyDayViewModel model);
        string GetCurrentDayWrittenData(int timeDifference);
        MyDayViewModel GetDayDataById(int id);
        MyDayViewModel UpdateDayDataById(MyDayViewModel updatedData);
    }
}
