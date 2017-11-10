namespace ADCGroup_Service.Model.JiraModel.LoginSession
{
    public class ResultLogin
    {
        public int code { get; set; }
        public string name { get; set; }

        public ResultLogin()
        {

        }

        public ResultLogin(int _code, string _name)
        {
            this.code = _code;
            this.name = _name;
        }
    }
}
