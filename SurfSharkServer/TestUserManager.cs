using CommonDB;
using SurfSharkServer.MySQL.Tables;
using System.Linq;

namespace SurfSharkServer
{
    public class TestUserManager
    {
        HibernateAdapter<uint> CommonDao = new HibernateAdapter<uint>();
        public UserAccounts GetUserAccountByUserName(string userName)
        {
            UserAccounts user = CommonDao.GetSession().QueryOver<UserAccounts>().Where(x => x.userName == userName).List().FirstOrDefault();
            if(user != null)
            {
                user = GetUserAccountById(user.UserId); // LET THE DB SERVICE KNOW
            }
            return user;
        }

        public UserAccounts GetUserAccountById(uint playerId)
        {
            return DbService.GetFromCache<UserAccounts>(playerId);
        }
    }
}
