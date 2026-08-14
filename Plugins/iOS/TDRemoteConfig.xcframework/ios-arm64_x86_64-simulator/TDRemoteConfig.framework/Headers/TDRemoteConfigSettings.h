//
//  TDRemoteConfigSettings.h
//  TDRemoteConfig
//
//  Created by huangdiao on 2023/12/5.
//

#import <Foundation/Foundation.h>

#if __has_include(<TDRemoteConfig/TDRCFetchTask.h>)
#import <TDRemoteConfig/TDRCFetchTask.h>
#else
#import "TDRCFetchTask.h"
#endif

NS_ASSUME_NONNULL_BEGIN

typedef NS_OPTIONS(NSUInteger, TDRemoteConfigMode) {
    TDRemoteConfigModeNormal = 0,
    TDRemoteConfigModeDebug = 1,
};

@interface TDRemoteConfigSettings : NSObject
@property (nonatomic, assign) TDRemoteConfigMode mode;
@property (nonatomic, copy) NSString *appId;
@property (nonatomic, copy) NSString *serverUrl;
@property (nonatomic, strong) NSDictionary<NSString *, NSObject *> *fetchParams;
/// 自定义分桶ID，用于指定分桶规则
@property (nonatomic, strong) NSDictionary<NSString *, NSString *> *customBucketId;
/// fetch 回调任务
@property (nonatomic, strong, nullable) TDRCFetchTask *fetchTask;

@end

NS_ASSUME_NONNULL_END
