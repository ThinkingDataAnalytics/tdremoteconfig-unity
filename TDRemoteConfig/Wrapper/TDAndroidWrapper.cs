#if UNITY_ANDROID && !(UNITY_EDITOR) && !TE_DISABLE_ANDROID_JAVA
using System;
using System.Collections.Generic;
using UnityEngine;
using ThinkingData.RemoteConfig.Utils;

namespace ThinkingData.RemoteConfig.Wrapper
{

    public partial class TDWrapper
    {

        private static readonly AndroidJavaClass sdkClass = new AndroidJavaClass("cn.thinkingdata.remoteconfig.TDRemoteConfigProxy");
        private static TDConfigFetchListener mListener;

        public static void EnableLog(bool enable)
        {
            sdkClass.CallStatic("enableLog", enable);
        }

        public static void Init(TDRemoteConfigSettings settings)
        {
            if (settings == null) return;
            AndroidJavaObject context = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            string fetchParams = "";
            if(settings.customFetchParams != null)
            {
                fetchParams = TDMiniJson.Serialize(settings.customFetchParams);
            }
            sdkClass.CallStatic("init", context, settings.appId, settings.serverUrl, settings.templateCode, (int)settings.mode, fetchParams);
        }

        public static void SetDefaultValues(Dictionary<string, object> defaultValues, string appId = "")
        {
            try
            {
                sdkClass.CallStatic("setDefaultValues", TDMiniJson.Serialize(defaultValues), appId);
            }
            catch (Exception) {
            }
        }

        public static void ClearDefaultValues(string appId = "")
        {
            sdkClass.CallStatic("clearDefaultValues", appId);
        }

        public static void SetCustomFetchParams(Dictionary<string, object> fetchParams, string appId = "", string tempCode = "")
        {
            try
            {
                sdkClass.CallStatic("setCustomFetchParams", TDMiniJson.Serialize(fetchParams), appId, tempCode);
            }
            catch (Exception) {
            }
        }


        public static void RemoveCustomFetchParam(string key, string appId = "", string tempCode = "")
        {
            sdkClass.CallStatic("removeCustomFetchParam", key, appId, tempCode);
        }

        public static void Fetch(string appId = "", string tempCode = "")
        {
            sdkClass.CallStatic("fetch", appId, tempCode);
        }

        public static void AddConfigFetchListener(TDConfigFetchListener listener)
        {
            mListener = listener;
            ConfigFetchListenerAdapter adapter = new ConfigFetchListenerAdapter();
            sdkClass.CallStatic("addConfigFetchListener", adapter);
        }

        public static string GetAllData(string configId = "", string templateId = "")
        {
            try
            {
                return sdkClass.CallStatic<string>("getAllData", configId, templateId);
            }
            catch (Exception e)
            {
                return "";
            }
        }

        private class ConfigFetchListenerAdapter : AndroidJavaProxy
        {
            public ConfigFetchListenerAdapter() : base("cn.thinkingdata.remoteconfig.TDRemoteConfigProxy$TDConfigFetchListener") { }
            public void onFetchSuccess(string result)
            {
                if (mListener != null)
                {
                    mListener.OnFetchSuccess(result);
                }
            }
        }


    }
}
#endif