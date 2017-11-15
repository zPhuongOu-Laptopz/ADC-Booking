using System;
using System.Collections.Generic;
using ADCGroup_Service.InterfaceEx.Service_Html;
using ADCGroup_Service.Model.JiraModel.Issue;

namespace ADCGroup_Service.Service.Service_Html
{
    public class Html_MeetingRoom : IHtml_MeetingRoom
    {
        public string MeetingRoomToday(List<Issue> list)
        {
            string html_result = string.Empty;
            foreach (var item in list)
            {
                html_result += "<p>" + item.fields.summary + " : ";
                html_result += item.fields.customfield_10402.value + " - ";
                html_result += item.fields.customfield_10400.Value.Hour + ":" + item.fields.customfield_10400.Value.Minute + "-";
                html_result += item.fields.customfield_10401.Value.Hour + ":" + item.fields.customfield_10401.Value.Minute + " ";
                html_result += "<a href=\"#\" data-toggle=\"modal\" data-target=\"#" + item.id + "\">[Chi Tiết]</a></p>";
            }
            return html_result;
        }

        public string MeetingRoomwithID(List<Issue> list)
        {
            string html_result = string.Empty;
            foreach (var item in list)
            {
                html_result += "<div class=\"modal fade\" id=\"" + item.id + "\" role=\"dialog\">";
                html_result += "<div class=\"modal-dialog modal-sm\">";
                html_result += "<div class=\"modal-content\">";
                html_result += "<div class=\"modal-header\">";
                html_result += "<button type = \"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>";
                html_result += "<h4 class=\"modal-title\">Chi tiết về cuộc họp</h4>";
                html_result += "</div>";
                html_result += "<div class=\"modal-body\">";
                html_result += "<p>";
                html_result += "<strong>Người đặt: </strong>" + item.fields.creator.displayName + "</p>";
                html_result += "<p>";
                html_result += "<strong>Tiêu đề: </strong> " + item.fields.summary + " </ p >";
                html_result += "<p>";
                html_result += "<strong>Phòng: </strong>" + item.fields.customfield_10402.value + "</ p >";
                html_result += "<p>";
                html_result += "<p>";
                html_result += "<strong>Số người: </strong>" + item.fields.customfield_10307.Value + "</ p >";
                html_result += "<p>";
                html_result += "<strong>Giờ bắt đầu: </strong> " + item.fields.customfield_10400.Value.Hour + ":" + item.fields.customfield_10400.Value.Minute + " </ p >";
                html_result += "<p>";
                html_result += "<strong>Giờ kết thúc: </strong>" + item.fields.customfield_10401.Value.Hour + ":" + item.fields.customfield_10401.Value.Minute + "</ p >";
                html_result += "<p>";
                html_result += "<p>";
                html_result += "<strong>Mô tả: </strong>" + item.fields.description + "</ p >";
                html_result += "<p>";
                html_result += "<strong>Tình trạng: </strong> Đã duyệt </p>";
                html_result += "</div>";
                html_result += "<div class=\"modal-footer\">";
                html_result += "<button type = \"button\" class=\"btn btn-danger\" data-dismiss=\"modal\">Liên hệ</button>";
                html_result += "<button type = \"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Close</button>";
                html_result += "</div>";
                html_result += "</div>";
                html_result += "</div>";
                html_result += "</div>";
            }
            return html_result;
        }

        /// <summary>
        /// Return string Html for Website about MeetingRoomToday
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_summary"></param>
        /// <param name="_room"></param>
        /// <param name="_starttime"></param>
        /// <param name="_endtime"></param>
        /// <returns></returns>
        public string MeetingRoomToday(string _id, string _summary, string _room, DateTime _starttime, DateTime _endtime)
        {
            string html_result = string.Empty;
            html_result = "<p>" + _summary + " : ";
            html_result += _room + " - ";
            html_result += _starttime.Hour + ":" + _starttime.Minute + "-";
            html_result += _endtime.Hour + ":" + _endtime.Minute + " ";
            html_result += "<a href=\"#\" data-toggle=\"modal\" data-target=\"#" + _id + "\">[Chi Tiết]</a></p>";
            return html_result;
        }

        /// <summary>
        /// Return string Html for Website about MeetingRoomwithID Popup
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_summary"></param>
        /// <param name="_room"></param>
        /// <param name="_quantity"></param>
        /// <param name="_starttime"></param>
        /// <param name="_endtime"></param>
        /// <param name="_description"></param>
        /// <param name="attactment"></param>
        /// <param name="label"></param>
        /// <param name="_name"></param>
        /// <returns></returns>
        public string MeetingRoomwithID(string _id, string _summary, string _room, double? _quantity, DateTime _starttime, DateTime _endtime, string _description, string attactment, string[] label, string _name)
        {
            string html_result = string.Empty;
            html_result = "<div class=\"modal fade\" id=\"" + _id + "\" role=\"dialog\">";
            html_result += "<div class=\"modal-dialog modal-sm\">";
            html_result += "<div class=\"modal-content\">";
            html_result += "<div class=\"modal-header\">";
            html_result += "<button type = \"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>";
            html_result += "<h4 class=\"modal-title\">Chi tiết về cuộc họp</h4>";
            html_result += "</div>";
            html_result += "<div class=\"modal-body\">";
            html_result += "<p>";
            html_result += "<strong>Người đặt: </strong>" + _name + "</p>";
            html_result += "<p>";
            html_result += "<strong>Tiêu đề: </strong> " + _summary + " </ p >";
            html_result += "<p>";
            html_result += "<strong>Phòng: </strong>" + _room + "</ p >";
            html_result += "<p>";
            html_result += "<strong>Giờ bắt đầu: </strong> " + _starttime.Hour + ":" + _starttime.Minute + " </ p >";
            html_result += "<p>";
            html_result += "<strong>Giờ kết thúc: </strong>" + _endtime.Hour + ":" + _endtime.Minute + "</ p >";
            html_result += "<p>";
            html_result += "<strong>Tình trạng: </strong> Đã duyệt </p>";
            html_result += "</div>";
            html_result += "<div class=\"modal-footer\">";
            html_result += "<button type = \"button\" class=\"btn btn-danger\" data-dismiss=\"modal\">Liên hệ</button>";
            html_result += "<button type = \"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Close</button>";
            html_result += "</div>";
            html_result += "</div>";
            html_result += "</div>";
            html_result += "</div>";
            return html_result;
        }

        public string MeetingRoomTodayTable(List<Issue> list)
        {
            int i = 1;
            string html_result = string.Empty;
            //html_result += "<table border = \"2px solid red;\" style=\"margin: 0 auto; \">";
            html_result += "<table class=\"table\">";
            html_result += "<tr>";
            html_result += "<td>";
            html_result += "Số thứ tự";
            html_result += "</td>";
            html_result += "</td>";
            html_result += "<td>";
            html_result += "Tên cuộc họp";
            html_result += "</td>";
            html_result += "<td>";
            html_result += "Thời gian bắt đầu";
            html_result += "</td>";
            html_result += "<td>";
            html_result += "Thời gian kết thúc";
            html_result += "</td>";
            html_result += "<td>";
            html_result += "Phòng họp";
            html_result += "</td>";
            html_result += "<td>";
            html_result += "Thao tác";
            html_result += "</td>";
            html_result += "</tr>";
            foreach (var item in list)
            {
                html_result += "<tr>";
                html_result += "<td scope=\"row\">";
                html_result += i++;
                html_result += "</td>";
                html_result += "<td>";
                html_result += item.fields.summary;
                html_result += "</td>";
                html_result += "<td>";
                html_result += item.fields.customfield_10400.Value.Hour + ":" + item.fields.customfield_10400.Value.Minute;
                html_result += "</td>";
                html_result += "<td>";
                html_result += item.fields.customfield_10401.Value.Hour + ":" + item.fields.customfield_10401.Value.Minute;
                html_result += "</td>";
                html_result += "<td>";
                html_result += item.fields.customfield_10402.value;
                html_result += "</td>";
                html_result += "<td>";
                html_result += "<a href=\"#\" data-toggle=\"modal\" data-target=\"#" + item.id + "\">[Chi Tiết]</a></p>";
                html_result += "</td>";
                html_result += "</tr>";
            }
            html_result += "</table>";
            return html_result;
        }
    }
}
