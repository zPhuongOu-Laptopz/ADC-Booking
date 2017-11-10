using ADCGroup_Service.Model.BasicModel.Account;

namespace ADCGroup_Service.InterfaceEx.Service_Basic
{
    public interface IChangeType
    {
        string EncodedAccount(Accounts account);
        byte[] ByteCredentials(Accounts account);
    }
}
