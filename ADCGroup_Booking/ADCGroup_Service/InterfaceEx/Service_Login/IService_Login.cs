using ADCGroup_Service.Model.JiraModel.LoginSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCGroup_Service.InterfaceEx.Service_Login
{
    public interface IService_Login
    {
        int LoginServicewithIssue(string _us, string _pass);
        ResultLogin LoginServicewithAccount(string _us, string _pass);
    }
}
