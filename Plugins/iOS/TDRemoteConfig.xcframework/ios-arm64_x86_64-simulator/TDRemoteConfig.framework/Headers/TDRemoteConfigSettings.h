//
//  TDRemoteConfigSettings.h
//  TDRemoteConfig
//
//  Created by huangdiao on 2023/12/5.
//

#import <Foundation/Foundation.h>

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

@end

NS_ASSUME_NONNULL_END
