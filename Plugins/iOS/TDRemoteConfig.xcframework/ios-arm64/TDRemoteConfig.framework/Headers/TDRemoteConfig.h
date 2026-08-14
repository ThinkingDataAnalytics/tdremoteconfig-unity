//
//  TDRemoteConfig.h
//  TDRemoteConfig
//
//  Created by huangdiao on 2023/10/27.
//

#import <Foundation/Foundation.h>

#if __has_include(<TDRemoteConfig/TDRemoteConfigSettings.h>)
#import <TDRemoteConfig/TDRemoteConfigSettings.h>
#else
#import "TDRemoteConfigSettings.h"
#endif

#if __has_include(<TDRemoteConfig/TDObject.h>)
#import <TDRemoteConfig/TDObject.h>
#else
#import "TDObject.h"
#endif

#if __has_include(<TDRemoteConfig/TDRCFetchTask.h>)
#import <TDRemoteConfig/TDRCFetchTask.h>
#else
#import "TDRCFetchTask.h"
#endif

#if __has_include(<TDRemoteConfig/TDRemoteConfigSettingsPrivate.h>)
#import <TDRemoteConfig/TDRemoteConfigSettingsPrivate.h>
#else
#import "TDRemoteConfigSettingsPrivate.h"
#endif

NS_ASSUME_NONNULL_BEGIN

extern NSString *kTDRemoteConfigFetchDataSuccess;
extern NSString *kTDRemoteConfigStrategyStatusMap;

@interface TDRemoteConfig : NSObject

+ (void)startWithSettings:(TDRemoteConfigSettings *)settings;
+ (void)enableLog:(BOOL)enable;
+ (NSString *)version;

// MARK: - Client params
/// Add a key-value pair to clientParams. If the key already exists, the new value will overwrite the old one.
+ (void)addClientParams:(NSDictionary *)params;

+ (void)removeClientParam:(NSString *)key;
+ (void)accumulateNum:(NSNumber *)number toClientParamKey:(NSString *)key;
+ (nullable NSDictionary *)getClientParams;
+ (id)getClientParamValueForKey:(NSString *)key;

// MARK: -

+ (TDObject *)getData;
+ (TDRCFetchTask *)fetch;
+ (void)setCustomFetchParams:(NSDictionary *)params;
+ (void)removeCustomFetchParam:(NSString *)key;
/// 设置自定义分桶ID，与当前内存中的值合并后持久化
+ (void)setCustomBucketId:(NSDictionary<NSString *, NSString *> *)bucketId;
+ (void)setDefaultValues:(NSDictionary *)defaultValue;
+ (void)setDefaultValuesWithJsonFile:(NSString *)filePath;
+ (void)clearDefaultValues;

+ (TDObject *)getDataWithAppId:(nullable NSString *)appId;
/// 获取指定模版的远程配置
+ (TDObject *)getDataWithAppId:(nullable NSString *)appId templateCode:(nullable NSString *)code;
+ (TDRCFetchTask *)fetchWithAppId:(nullable NSString *)appId;
/// 拉取指定模版的远程配置
+ (TDRCFetchTask *)fetchWithAppId:(nullable NSString *)appId templateCode:(nullable NSString *)code;
+ (void)setCustomFetchParams:(NSDictionary *)params appId:(nullable NSString *)appId;
/// 设置指定模版的自定义请求参数，与当前内存中的值合并后持久化
+ (void)setCustomFetchParams:(NSDictionary *)params appId:(nullable NSString *)appId templateCode:(nullable NSString *)code;
+ (void)removeCustomFetchParam:(NSString *)key appId:(nullable NSString *)appId;
/// 设置自定义分桶ID，与当前内存中的值合并后持久化
+ (void)setCustomBucketId:(NSDictionary<NSString *, NSString *> *)bucketId appId:(nullable NSString *)appId templateCode:(nullable NSString *)code;
+ (void)setDefaultValues:(NSDictionary *)defaultValue appId:(nullable NSString *)appId;
+ (void)setDefaultValuesWithJsonFile:(NSString *)filePath appId:(nullable NSString *)appId;
+ (void)clearDefaultValuesWithAppId:(nullable NSString *)appId;

@end

NS_ASSUME_NONNULL_END
