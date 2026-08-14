# ThinkingData Remote Config SDK for Unity

This is the [ThinkingData](https://www.thinkingdata.cn)™ Remote Config SDK for Unity.

## Install via Package Manager

Requires **TDAnalytics 3.5.0** (`com.thinkingdata.analytics`). Unity does not support Git dependencies inside a package's `package.json`, so add both packages in the host project's `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.thinkingdata.analytics": "https://github.com/ThinkingDataAnalytics/unity-sdk.git#v3.5.0",
    "com.thinkingdata.remoteconfig": "https://github.com/ThinkingDataAnalytics/tdremoteconfig-unity.git?path=/Assets#v1.2.4"
  }
}
```

Or add each from Package Manager → Add package from git URL.

## Quick Start

```csharp
using ThinkingData.RemoteConfig;

TDRemoteConfig.Init("YOUR_APP_ID", "https://YOUR_SERVER_URL");
TDRemoteConfig.AddConfigFetchListener(listener);
TDRemoteConfig.Fetch();
string data = TDRemoteConfig.GetAllData();
```

API entry: `ThinkingData.RemoteConfig.TDRemoteConfig`.

---
