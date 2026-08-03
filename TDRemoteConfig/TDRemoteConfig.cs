using System;
using System.Collections.Generic;
using ThinkingData.RemoteConfig.Wrapper;

namespace ThinkingData.RemoteConfig {
	public class TDRemoteConfig {

		public static void EnableLog(bool enable) {
			TDWrapper.EnableLog(enable);
		}

        public static void Init(string appId,string serverUrl)
        {
			TDRemoteConfigSettings settings = new TDRemoteConfigSettings();
			settings.appId = appId;
			settings.serverUrl = serverUrl;
            TDWrapper.Init(settings);
        }

        public static void Init(TDRemoteConfigSettings settings) {
			TDWrapper.Init(settings);
		}

		public static void SetDefaultValues(Dictionary<string,object> defaultValues,string appId = "") {
            if (defaultValues == null) return;
            TDWrapper.SetDefaultValues(defaultValues, appId);
		}

        public static void ClearDefaultValues(string appId = "")
        {
			TDWrapper.ClearDefaultValues();
        }

        public static void SetCustomFetchParams(Dictionary<string,object> fetchParams,string appId= "", string tempCode = "") {
            if (fetchParams == null) return;
            TDWrapper.SetCustomFetchParams(fetchParams, appId);
		}

        public static void RemoveCustomFetchParam(string key, string appId = "", string tempCode = "")
        {
			if (key == null) return;
			TDWrapper.RemoveCustomFetchParam(key, appId, tempCode);
        }

		public static void Fetch(string appId = "", string tempCode = "") {
			TDWrapper.Fetch(appId, tempCode);
		}

		public static void AddConfigFetchListener(TDConfigFetchListener listener) {
			TDWrapper.AddConfigFetchListener(listener);
		}

        public static string GetAllData(string configId = "", string templateId = "")
        {
			return TDWrapper.GetAllData(configId, templateId);
        }

		public static string GetSDKVersion() {
			return "1.2.3";
		}

    }

	public class TDRemoteConfigSettings {
		public string appId;
		public string serverUrl;
		public string templateCode;
		public TDRemoteMode mode;
		public Dictionary<string,object> customFetchParams;
    }

	public enum TDRemoteMode {
		NORMAL = 0,
		DEBUG = 1
	}

	public interface TDConfigFetchListener {
		public void OnFetchSuccess(string statusData);
    }
}

