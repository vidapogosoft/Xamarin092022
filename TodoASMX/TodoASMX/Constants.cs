using Xamarin.Forms;

namespace TodoASMX
{
    public static class Constants
    {
        // URL of ASMX service
        public static string SoapUrl
        {
            get
            {
                var defaultUrl = "http://localhost:49178/TodoService.asmx";

                if (Device.RuntimePlatform == Device.Android)
                {
                    //defaultUrl = "http://10.0.2.2:49178/TodoService.asmx";
                    defaultUrl = "http://192.168.100.10/todoasmx/TodoService.asmx";
                }

                return defaultUrl;
            }
        }
    }
}
