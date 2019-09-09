using SurfSharkServer.Communication.Packets.Data;
using SurfSharkServer.MySQL.Tables;

namespace SurfSharkServer.com
{
    public class User 
    {
        public uint UID = 0;
        public UserAccounts _data;

        public User(UserAccounts account)
        {
            this._data = account;
        }

        public UserType MemberType { get => (UserType)_data.MemberType; set => _data.MemberType = (byte)value; }

        public string UserName { get => _data.userName; set => _data.userName = value; }
        public string Password { get => _data.passWord; set => _data.passWord = value; }
        public string Hwid { get => _data.hwid; set => _data.hwid = value; }
        public uint Credits { get => _data.credits; set => _data.credits = value; }


        public int ViewsToday = 0;

        public SiteClass[] Sites = new SiteClass[0];

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
