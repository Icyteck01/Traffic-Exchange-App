using Microsoft.Win32;
using Newtonsoft.Json;
using SurfShark.program;
using SurfShark.programs;
using System;
using System.Net;
using WindowsFormsApplication1;

namespace SurfShark
{
    internal static class Component
    {
        // public static CoreSystem main;
        // public static LoginDialog login;
        // public static MainProgram surf;
        // public static UrlUtilityForm util;

        public static CoreSystem main { get; set; }
        public static LoginDialog login { get; set; }
        public static MainProgram surf { get; set; }
        public static UrlUtilityForm util { get; set; }
        public static ChatWindow chat { get; set; }

        private static string hwKey { get; set; }
        private static bool finished = false;
        private static bool regionGot = false;
        private static string region { get; set; }

        internal static string GetInfo()
        {
            try
            {
                WebClient wc = new WebClient();
                string dw = wc.DownloadString("http://api.hostip.info/get_json.php?ip=");
                Hostip li = (Hostip)JsonConvert.DeserializeObject<Hostip>(dw);
                region = li.country_name;
                return region;
            }
            catch (Exception) { return ""; }
        }

        internal static string getRegion()
        {
            if (regionGot && region.Length > 0)
            {
                return region;
            }
            else
            {

                regionGot = true;
                return GetInfo();
            }

        }

        internal static string getHwKey()
        {
            // if(finished && hwKey.Length > 2)
            // {
            //     return hwKey;
            // }
            return FPkey.Value();
        }

        internal static void saveLastLogin(string username, string password)
        {
            string hardwereKey = "";
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Games Shark Limited\\Values", true);
                if (key != null)
                {
                    string value = key.GetValue("hash").ToString();
                    LoginInfo li = (LoginInfo)JsonConvert.DeserializeObject<LoginInfo>(Encrypt.Decode(value));
                    string usernamex = li.username;
                    if (!usernamex.Equals(username))
                    {
                        hardwereKey = FPkey.Value();
                        string loginInfo = "{\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"hardwereKey\":\"" + hardwereKey + "\",\"country\":\"" + getRegion() + "\"}";
                        string valuex = Encrypt.Encode(loginInfo);
                        key.SetValue("hash", valuex);
                        key.Close();
                    }
                    else
                    {
                        hardwereKey = li.hardwereKey;
                        key.Close();
                    }
                }
                else
                {
                    hardwereKey = FPkey.Value();
                    string loginInfo = "{\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"hardwereKey\":\"" + hardwereKey + "\",\"country\":\"" + getRegion() + "\"}";
                    string value = Encrypt.Encode(loginInfo);
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Games Shark Limited\\Values");
                    key.SetValue("hash", value);
                    key.Close();
                }
            }
            catch (Exception)
            {
            }
            hwKey = hardwereKey;
            finished = true;
        }

        internal static LoginInfo getLastLogin()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Games Shark Limited\\Values", true);
                if (key != null)
                {
                    string value = key.GetValue("hash").ToString();
                    LoginInfo li = (LoginInfo)JsonConvert.DeserializeObject<LoginInfo>(Encrypt.Decode(value));
                    key.Close();
                    hwKey = li.hardwereKey;
                    region = getRegion();
                    finished = true;
                    return li;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
