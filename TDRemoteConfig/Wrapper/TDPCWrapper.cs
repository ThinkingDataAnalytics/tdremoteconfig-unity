#if ((!(UNITY_IOS) || UNITY_EDITOR) && (!(UNITY_ANDROID) || UNITY_EDITOR)) || TE_DISABLE_ANDROID_JAVA || TE_DISABLE_IOS_OC

using System;
using System.Collections.Generic;

namespace ThinkingData.RemoteConfig.Wrapper {

    public partial class TDWrapper {

        public static void EnableLog(bool enable)
        {

        }

        public static void Init(TDRemoteConfigSettings settings)
        {

        }

        public static void SetDefaultValues(Dictionary<string, object> defaultValues, string appId = "")
        {

        }

        public static void ClearDefaultValues(string appId = "")
        {

        }

        public static void SetCustomFetchParams(Dictionary<string, object> fetchParams, string appId = "", string tempCode = "")
        {

        }

        public static void RemoveCustomFetchParam(string key, string appId = "", string tempCode = "")
        {

        }

        public static void Fetch(string appId = "", string tempCode = "")
        {

        }

        public static void AddConfigFetchListener(TDConfigFetchListener listener)
        {

        }

        public static string GetAllData(string configId = "", string templateId = "")
        {
            return "";
        }

    }
}
#endif
