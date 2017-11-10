using ADCGroup_Service.Model.BasicModel.Account;
using ADCGroup_Service.Model.JiraModel.Issue;
using System;
using System.Collections.Generic;

namespace ADCGroup_Service.InterfaceEx.Service_Booking
{
    public interface IMeeting
    {
        Issues GetAllMeetingRoom(Accounts account);
        List<Issue> GetAllIssue(Accounts account);
        bool CreateIssue(Accounts account, string sumamary, string idroom, double? quantity, DateTime start, DateTime end, string description);
        string JsonMeetingRoom(string sumamary, string idroom, double? quantity, DateTime start, DateTime end, string description);
        bool ChangeStatusIssue();
    }
}
