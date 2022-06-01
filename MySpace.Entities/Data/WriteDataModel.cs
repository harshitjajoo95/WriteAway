using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySpace.Entities.Data
{
    public class WriteDataModel
    {
        public int id { get; set; }
        public string userId { get; set; }

        public string WrittenData { get; set; }
        public DateTime UtcDateTime { get; set; }
        public DateTime LocalDateTime { get; set; }
        //public Date LocalDate { get; set; }
        public int TimeDifferenceInMinutes { get; set; }//time difference between local time and utc time
    }
}
