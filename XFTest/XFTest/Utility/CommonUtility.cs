using System;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.DeviceInfo;

namespace XFTest.Utility
{
    public enum DeviceTypeEnum
    {
        Android = 0,
        iOS = 1
    }


    public static class CommonUtility
    {
        private static bool isVisible = false;

        public static bool IsConnectedToInternet()
        {
            return CrossConnectivity.Current.IsConnected;
        }

        public static string GetDeviceType()
        {
            return CrossDeviceInfo.Current.Platform.ToString().ToLower();
        }

    }

}
