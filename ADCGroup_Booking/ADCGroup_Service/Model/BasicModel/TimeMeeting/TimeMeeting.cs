using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCGroup_Service.Model.BasicModel.TimeMeeting
{
    public class TimeMeeting
    {
        public DateTime timestart { get; set; }
        public DateTime timeend { get; set; }

        public TimeMeeting()
        {
            
        }

        public TimeMeeting(DateTime st, DateTime en)
        {
            this.timestart = st;
            this.timeend = en;
        }
    }
}
