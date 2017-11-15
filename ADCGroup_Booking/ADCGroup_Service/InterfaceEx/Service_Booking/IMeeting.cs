using ADCGroup_Service.Model.BasicModel.Account;
using ADCGroup_Service.Model.BasicModel.TimeMeeting;
using ADCGroup_Service.Model.JiraModel.Issue;
using System;
using System.Collections.Generic;

namespace ADCGroup_Service.InterfaceEx.Service_Booking
{
    public interface IMeeting
    {
        
        Issues GetAllMeetingRoom(Accounts account);
        List<Issue> GetAllIssue(Accounts account);
        List<Issue> GetAllIssueToday(Accounts account);
        List<Issue> GetAllIssueThisDay(Accounts account, DateTime day);
        List<TimeMeeting> GetAllFreeTimeMeetingwithListIssueOneDay(List<TimeMeeting> list);
        List<Issue> GetAllIssuebyRoom2big(Accounts account);
        List<Issue> GetAllIssuebyRoom2small(Accounts account);
        List<Issue> GetAllIssuebyRoom4(Accounts account);
        List<Issue> GetAllIssuebyRoom6(Accounts account);
        List<Issue> GetAllIssuebyRoom2big(Accounts account, DateTime day);
        List<Issue> GetAllIssuebyRoom2small(Accounts account, DateTime day);
        List<Issue> GetAllIssuebyRoom4(Accounts account, DateTime day);
        List<Issue> GetAllIssuebyRoom6(Accounts account, DateTime day);
        List<TimeMeeting> ConvertDatimeIssuetoTimeMeeting(List<Issue> list);
        bool CheckFreeTimeIssueforBooking();
        bool BookingMeetingRoom();
        bool CreateIssue(Accounts account, string sumamary, string idroom, double? quantity, DateTime start, DateTime end, string description);
        string JsonMeetingRoom(string sumamary, string idroom, double? quantity, DateTime start, DateTime end, string description);
        bool ChangeStatusIssue();
    }
}
