using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCGroup_Service.InterfaceEx.Service_Html
{
    public interface IHtml_MeetingRoom
    {
        string MeetingRoomToday(string _id, string _summary, string _room, DateTime _starttime, DateTime _endtime);
        string MeetingRoomwithID(string _id, string _summary, string _room, double? _quantity, DateTime _starttime, DateTime _endtime, string _description, string attactment, string[] label, string _name);
    }
}
