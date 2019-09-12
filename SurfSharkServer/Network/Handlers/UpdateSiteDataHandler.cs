using CommonDB;
using JHSNetProtocol;
using SurfShark.Communication.Packets;
using SurfSharkServer.com;
using SurfSharkServer.Communication.Packets.Data;
using SurfSharkServer.MySQL.Tables;

namespace SurfSharkServer.Network
{
    public class UpdateSiteDataHandler : IJHSInterface
    {
        UserManager userManager = null;
        public bool Execute(JHSNetworkMessage msg)
        {
            SubmitDataForUpdate packet = msg.ReadMessage<SubmitDataForUpdate>();
            if(packet != null)
            {
                if (userManager == null)
                    userManager = UserManager.Instance;
                uint connectionId = msg.conn.connectionId;
               
                User user = userManager.GetUserByConnectionId(connectionId);
                if(user != null)
                {               
                    lock (user)
                    {
                        bool delted = false;

                        foreach (SiteClass site in packet.Added)
                        {
                            site.UserId = user.UserId;
                            SiteClass n = new SiteClass(DbService.CreateEntity(site._data));
                            user.AddOrUpdateSite(n);
                            DbService.SubmitUpdate2Queue(n.UID, n._data);
                            
                        }
                        foreach (SiteClass site in packet.Changed)
                        {
                            SiteClass v = user.GetSite(site.SiteIndex);
                            if (v != null)
                            {
                                v.WebsiteName = site.WebsiteName;
                                v.Url = site.Url;
                                v.Region = site.Region;
                                v.Referral = site.Referral;
                                v.IsActive = site.IsActive;
                                v.Time = site.Time;
                                user.AddOrUpdateSite(v);
                                DbService.SubmitUpdate2Queue(v.UID, v._data);
                            }
                        }              
                        foreach (int site in packet.Deleted)
                        {
                            SiteClass v = user.GetSite(site);
                            if (v != null)
                            {
                                delted = true;
                                user.RemoveSite(site);
                                DbService.RemoveEntityFromDatabase<UserUrls>(v.UID);
                            }
                        }
                        if (delted)
                            user.ReorderSites();

                        msg.conn.Send(NetworkConstants.UPDATE_SITE_DATA, new SubmitDataForUpdate()
                        {
                            Code = delted ? ErrorCodes.JUST_DATA_UPDATE : ErrorCodes.GENERAL_FAILURE,
                            Changed = user.Sites
                        });
                    }

                }
            }
            return true;
        }
    }
}
