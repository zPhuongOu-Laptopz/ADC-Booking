using ADCGroup_Service.InterfaceEx.Service_Basic;
using ADCGroup_Service.Model.BasicModel.Account;
using System;
using System.Text;

namespace ADCGroup_Service.Service.Service_Basic
{
    public class ChangeType : IChangeType
    {
        /// <summary>
        /// Convert from Account with username, password to Base64
        /// </summary>
        /// <param name="account">Account of user</param>
        /// <returns>string</returns>
        public string EncodedAccount(Accounts account)
        {
            var mergedCredentials = string.Format("{0}:{1}", account.username, account.password);
            byte[] byteCredentials = Encoding.UTF8.GetBytes(mergedCredentials);
            return (Convert.ToBase64String(byteCredentials));
        }

        /// <summary>
        /// Convert from Account with username, password to Byte[]
        /// </summary>
        /// <param name="account">Account of user</param>
        /// <returns>byte[]</returns>
        public byte[] ByteCredentials(Accounts account)
        {
            var mergedCredentials = string.Format("{0}:{1}", account.username, account.password);
            return (Encoding.UTF8.GetBytes(mergedCredentials));
        }
    }
}
