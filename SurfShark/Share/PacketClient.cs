using Newtonsoft.Json;

namespace SurfShark.program
{
    class PacketClient
    {


        internal static BaseSocket decodeBS(string str)
        {
            string data = str.ToString().Trim();
            BaseSocket main_packet = JsonConvert.DeserializeObject<BaseSocket>(Encrypt.Decode(data));
            object pockValue = main_packet.value.ToString();
            main_packet.value = pockValue;
            return main_packet;
        }

    }
}
