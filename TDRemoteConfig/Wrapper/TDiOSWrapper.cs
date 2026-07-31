#if UNITY_IOS && !(UNITY_EDITOR) && !TE_DISABLE_IOS_OC
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ThinkingData.RemoteConfig.Utils;

namespace ThinkingData.RemoteConfig.Wrapper
{

    public partial class TDWrapper
    {
        [DllImport("__Internal")]
        private static extern void rc_enableLog(bool enable);

        [DllImport("__Internal")]
        private static extern void rc_init(string appId,string serverUrl,string templateCode,int mode,string fetchParams);

        [DllImport("__Internal")]
        private static extern void rc_set_default_values(string defaultValues, string appId);

        [DllImport("__Internal")]
        private static extern void rc_clear_default_values(string appId);

        [DllImport("__Internal")]
        private static extern void rc_set_fetch_params(string fetchParams, string appId, string templateCode);

        [DllImport("__Internal")]
        private static extern void rc_remove_fetch_param(string key,string appId, string templateCode);

        [DllImport("__Internal")]
        private static extern void rc_fetch(string appId, string templateCode);

        [DllImport("__Internal")]
        private static extern string rc_get_all_data(string configId, string templateId);


        [DllImport("__Internal")]
        private static extern void rc_setConfigFetchDelegate();

        [DllImport("__Internal")]
        public static extern void RegisterRecieveConfigCallback
        (
            IntPtr handlerPointer
        );

        private static TDConfigFetchListener mListener;

        public static void EnableLog(bool enable)
        {
            rc_enableLog(enable);
        }

        public static void Init(TDRemoteConfigSettings settings)
        {
            if (settings == null) return;
            RegisterConfigCallback();
            string fetchParams = "";
            if (settings.customFetchParams != null)
            {
                fetchParams = TDMiniJson.Serialize(settings.customFetchParams);
            }
            rc_init(settings.appId, settings.serverUrl, settings.templateCode, (int)settings.mode, fetchParams);
        }

        public static void SetDefaultValues(Dictionary<string, object> defaultValues, string appId = "")
        {
            try
            {
                rc_set_default_values(TDMiniJson.Serialize(defaultValues), appId);
            }
            catch (Exception) {
            }
            
        }

        public static void ClearDefaultValues(string appId = "")
        {
            rc_clear_default_values(appId);
        }


        public static void SetCustomFetchParams(Dictionary<string, object> fetchParams, string appId = "", string tempCode = "")
        {
            try
            {
                rc_set_fetch_params(TDMiniJson.Serialize(fetchParams), appId, tempCode);
            }
            catch (Exception) {
            }
        }

        public static void RemoveCustomFetchParam(string key, string appId = "", string tempCode = "")
        {
            rc_remove_fetch_param(key, appId, tempCode);
        }

        public static void Fetch(string appId = "", string tempCode = "")
        {
            rc_fetch(appId, tempCode);
        }

        public static void AddConfigFetchListener(TDConfigFetchListener listener)
        {
            mListener = listener;
            rc_setConfigFetchDelegate();
        }

        public static string GetAllData(string configId = "", string templateId = "")
        {
            try
            {
                return rc_get_all_data(configId,templateId);
            }
            catch (Exception e)
            {
                return "";
            }
        }

        private static void RegisterConfigCallback()
        {
            ConfigFetchHandler handler = new ConfigFetchHandler(configFetchHandler);
            IntPtr handlerPointer = Marshal.GetFunctionPointerForDelegate(handler);
            RegisterRecieveConfigCallback(handlerPointer);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ConfigFetchHandler(string statusData);


        [AOT.MonoPInvokeCallback(typeof(ConfigFetchHandler))]
        static void configFetchHandler(string statusData) {
            if (mListener != null) {
                mListener.OnFetchSuccess(statusData);
            }
        }

    }
}
#endif