using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SurfShark.program
{
     class PacketClient
    {


        internal static baseSocket decodeBS(string str)
        {
            String data = str.ToString().Trim();
            baseSocket main_packet = JsonConvert.DeserializeObject<baseSocket>(Encrypt.Decode(data));
            Object pockValue = main_packet.value.ToString();
            main_packet.value = pockValue;
            return main_packet;
        }

    }
}
