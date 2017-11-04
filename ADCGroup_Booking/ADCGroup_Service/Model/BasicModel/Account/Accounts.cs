using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCGroup_Service.Model.BasicModel.Account
{
    public class Accounts
    {
        public string username { get; set; }
        public string password { get; set; }

        public Accounts()
        {

        }

        public Accounts(string user, string pass)
        {
            this.username = user;
            this.password = pass;
        }
    }
}
