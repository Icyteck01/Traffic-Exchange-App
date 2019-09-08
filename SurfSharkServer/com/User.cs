using SurfSharkServer.MySQL.Tables;

namespace SurfSharkServer.com
{
    public class User 
    {
        public uint UID = 0;
        public UserAccounts _data;
        public string UserName { get => _data.userName; set => _data.userName = value; }
        public string Password { get => _data.passWord; set => _data.passWord = value; }
        public string Hwid { get => _data.hwid; set => _data.hwid = value; }

        public object GetEntity()
        {
            return _data;
        }

        public string GetId()
        {
            return _data.UserId + "_User";
        }

        public void OnLogout()
        {

        }
    }
}
