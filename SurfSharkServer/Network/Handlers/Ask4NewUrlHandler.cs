using CommonDB;
using JHSNetProtocol;
using NHibernate;
using SurfShark.Network.Packets;
using SurfSharkServer.com;
using SurfSharkServer.MySQL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurfSharkServer.Network
{
    public class Ask4NewUrlHandler : IJHSInterface
    {
        UserManager userManager = null;
        public bool Execute(JHSNetworkMessage msg)
        {
            Ask4NewURL packet = msg.ReadMessage<Ask4NewURL>();
            if (packet != null)
            {
                if (userManager == null)
                    userManager = UserManager.Instance;
                uint connectionId = msg.conn.connectionId;

                User user = userManager.GetUserByConnectionId(connectionId);
                if (user != null)
                {
                    lock (user)
                    {
                        if(user.LastViedSite != null)
                        {
                            if (user.LastRequestTime > JHSTime.Time)
                            {
                                msg.conn.Send(NetworkConstants.GET_NEW_URL, new UrlDetails()
                                {
                                    code = ErrorCodes.SUCCESS,
                                    Time = user.LastViedSite.Time,
                                    Url = user.LastViedSite.url
                                });
                                user.LastRequestTime = JHSTime.Time + user.LastViedSite.Time;
                                return true;
                            }
                            uint reward = 0;
                            switch(user.MemberType)
                            {
                                case UserType.FREE:
                                    reward = (uint)(user.LastViedSite.Time * 0.5f);
                                    break;
                                default:
                                    reward = user.LastViedSite.Time;
                                    break;
                            }
                            User other = userManager.GetUserByUserID(user.LastViedSite.UID);
                            if(other != null)
                            {
                                uint take = other.Credits - user.LastViedSite.Time;
                                if(take > 0)
                                {
                                    other.Credits = take;
                                }
                                else
                                {
                                    other.Credits = 0;
                                }
                                DbService.UpdateEntityIntime(other.UserId, other._data);
                            }
                            user.ViewdSites.Add(user.LastViedSite.id);
                            user.Credits = reward;
                            DbService.UpdateEntityIntime(user.UserId, user._data);
                        }
                        ISession session = DbService.GetDBSession;
                        if (session != null)
                        {
                            var sql = "SELECT userurls.id,userurls.UID,userurls.WebsiteName,userurls.region,userurls.url,userurls.Referral,userurls.Time,userurls.ViewCount,userurls.IsActive FROM userurls,useraccounts WHERE userurls.IsActive = 1 AND useraccounts.UserId = userurls.UID AND useraccounts.credits > 120 AND userurls.id NOT IN(" + user.GetViewdSitesString() + ") AND useraccounts.UserId != " + user.UserId + " LIMIT 1";
                            var query = session.CreateSQLQuery(sql).AddEntity(typeof(UserUrls));
                            UserUrls objectList = query.UniqueResult<UserUrls>();
                            if(objectList != null)
                            {
                                msg.conn.Send(NetworkConstants.GET_NEW_URL, new UrlDetails()
                                {
                                    code = ErrorCodes.SUCCESS,
                                    Time = objectList.Time,
                                    Url = objectList.url
                                });
                                user.LastViedSite = objectList;
                                user.LastRequestTime = JHSTime.Time + user.LastViedSite.Time;
                            }
                            else
                            {
                                msg.conn.Send(NetworkConstants.GET_NEW_URL, new UrlDetails()
                                {
                                    code = ErrorCodes.NO_MORE_SITES
                                });
                            }

                        }
                    }
                }
            }
            return true;
        }
    }
}
