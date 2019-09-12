using JHSEngine.Interfaces;
using JHSEngine.Patterns.Command;
using JHUI.Utils;
using SurfShark.Communication.Packets;
using SurfSharkServer.Communication.Packets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfShark.Core.CMD
{
    public class DoUpdateSites : SimpleCommand
    {
        float LastExecutuion = 0;
        public static bool Lock = false;
        public override void Execute(INotification notification)
        {
            if (LastExecutuion > Time.time)
                return;

            LastExecutuion = Time.time + 1f; // PREVENT SPAM

            if (!Lock)
            {
                Lock = true;
                SiteClass[] Added = SitesManager.Added();
                SiteClass[] Changed = SitesManager.Changed();
                int[] Deleted = SitesManager.Deleted();

                bool IsSend = Added.Length != 0 | Changed.Length != 0 | Deleted.Length != 0;
                if (IsSend)
                {
                    NetworkManager.Send(NetworkConstants.UPDATE_SITE_DATA, new SubmitDataForUpdate()
                    {
                        Code = ErrorCodes.SUCCESS,
                        Added = Added,
                        Changed = Changed,
                        Deleted = Deleted,
                    });
                }
                Lock = false;
            }
        }
    }
}
