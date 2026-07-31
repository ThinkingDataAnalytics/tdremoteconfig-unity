/*
 * Copyright (C) 2024 ThinkingData
 */
package cn.thinkingdata.remoteconfig;


import android.content.Context;
import android.text.TextUtils;
import org.json.JSONObject;
import cn.thinkingdata.remoteconfig.TDRemoteConfig;
import cn.thinkingdata.remoteconfig.TDRemoteConfigSettings;
import cn.thinkingdata.remoteconfig.core.TDObject;

public class TDRemoteConfigProxy {
    public static void enableLog(boolean enable){
        TDRemoteConfig.enableLog(enable);
    }

    public static void init(Context context, String appId, String serverUrl, String templateCode, int mode, String params) {
        TDRemoteConfigSettings settings = new TDRemoteConfigSettings();
        settings.appId = appId;
        settings.serverUrl = serverUrl;
        settings.templateCode = templateCode;
        if (mode == 0 || mode == 1) {
            settings.mode = TDRemoteConfigSettings.TDRemoteConfigMode.values()[mode];
        }
        try {
            settings.setCustomFetchParams(new JSONObject(params));
        } catch (Exception ignore) {
        }
        TDRemoteConfig.init(context, settings);
    }

    public static void setDefaultValues(String defaultValues, String appId) {
        try {
            TDRemoteConfig.setDefaultValues(new JSONObject(defaultValues), appId);
        } catch (Exception ignore) {
        }
    }

    public static void setCustomFetchParams(String fetchParams, String appId, String tempCode) {
        try {
            TDRemoteConfig.setCustomFetchParams(new JSONObject(fetchParams), appId, tempCode);
        } catch (Exception ignore) {
        }
    }

    public static void clearDefaultValues(String appId) {
        try {
            TDRemoteConfig.clearDefaultValues(appId);
        } catch (Exception ignore) {
        }
    }

    public static void removeCustomFetchParam(String key, String appId, String tempCode) {
        try {
            TDRemoteConfig.removeCustomFetchParam(key, appId, tempCode);
        } catch (Exception ignore) {
        }
    }

    public static void fetch(String appId, String tempCode) {
        try {
            TDRemoteConfig.fetch(appId, tempCode);
        } catch (Exception ignore) {
        }
    }

    public static String getAllData(String configId, String templateId) {
        try {
            if (TextUtils.isEmpty(configId)) return "{}";
            TDObject tdObject = TDRemoteConfig.getData().get(configId);
            if (!TextUtils.isEmpty(templateId)) {
                tdObject.get(templateId);
            }
            return tdObject.configValue();

        } catch (Exception ignore) {
        }
        return "{}";
    }

    public static void addConfigFetchListener(TDConfigFetchListener listener) {
        TDRemoteConfig.addConfigFetchListener(new TDRemoteConfig.OnConfigFetchListener() {
            @Override
            public void onFetchSuccess(JSONObject statusData) {
                if (listener != null && statusData != null) {
                    listener.onFetchSuccess(statusData.toString());
                }
            }
        });
    }

    public interface TDConfigFetchListener {
        void onFetchSuccess(String statusData);
    }

}
