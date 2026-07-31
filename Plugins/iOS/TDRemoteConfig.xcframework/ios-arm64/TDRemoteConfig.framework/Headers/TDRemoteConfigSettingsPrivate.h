//
//  TDRemoteConfigSettingsPrivate.h
//  Pods
//
//  Created by 杨雄 on 2024/12/6.
//

#ifndef TDRemoteConfigSettingsPrivate_h
#define TDRemoteConfigSettingsPrivate_h

#if __has_include(<TDRemoteConfig/TDRemoteConfigSettings.h>)
#import <TDRemoteConfig/TDRemoteConfigSettings.h>
#else
#import "TDRemoteConfigSettings.h"
#endif

@interface TDRemoteConfigSettings ()
@property (nonatomic, copy) NSString *templateCode;

@end

#endif /* TDRemoteConfigSettingsPrivate_h */
