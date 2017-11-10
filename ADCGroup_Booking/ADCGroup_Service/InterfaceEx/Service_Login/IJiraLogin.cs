using ADCGroup_Service.Model.BasicModel.Account;
using ADCGroup_Service.Model.JiraModel.InfoUser;
using ADCGroup_Service.Model.JiraModel.LoginSession;

namespace ADCGroup_Service.InterfaceEx.Service_Login
{
    public interface IJiraLogin
    {
        LoginInfo GetSessionJiraLogin(Accounts account);
        InfoUser GetInfoUser(Accounts account);
    }
}
