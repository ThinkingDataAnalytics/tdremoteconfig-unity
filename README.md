# ThinkingData Remote Config SDK for Unity

This is the [ThinkingData](https://www.thinkingdata.cn)™ Remote Config SDK for Unity.

## Install via Package Manager

Depends on **TDAnalytics 3.5.0** (`com.thinkingdata.analytics`).

Add from git URL (Unity 2019.3+):

```
https://github.com/ThinkingDataAnalytics/tdremoteconfig-unity.git?path=/Assets#v1.2.2
```

Or add to your project's `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.thinkingdata.remoteconfig": "https://github.com/ThinkingDataAnalytics/tdremoteconfig-unity.git?path=/Assets#v1.2.2"
  }
}
```

> Note: Unity Package Manager 对「包依赖另一个 Git 包」支持有限。若未自动拉取 TDAnalytics，请在宿主工程中手动添加：
> `https://github.com/ThinkingDataAnalytics/unity-sdk.git?path=/Assets#v3.5.0`

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
