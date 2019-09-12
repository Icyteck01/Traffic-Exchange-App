using JHSEngine.Interfaces;
using JHSEngine.Patterns.Command;
using SurfShark.Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark.Core.CMD
{
    public class DoAskNextUrl : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
        

            NetworkManager.Send(NetworkConstants.GET_NEW_URL, new Ask4NewURL());
        }
    }
}
