//
//  TDRCFetchTask.h
//  TDRemoteConfig
//
//  Created by claude on 2025/05/28.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

/// fetch 链式回调任务类
@interface TDRCFetchTask : NSObject

/// 添加成功回调（无参数），返回 self 实现链式调用
- (TDRCFetchTask *)addOnSuccessListener:(void (^)(void))listener;

/// 添加失败回调（code + msg），返回 self 实现链式调用
- (TDRCFetchTask *)addOnFailureListener:(void (^)(NSInteger code, NSString *msg))listener;

/// 添加本地缓存就绪回调（初始化加载持久化数据完成后触发），返回 self 实现链式调用
- (TDRCFetchTask *)addOnLocalCacheReadyListener:(void (^)(void))listener;

/// 触发成功回调（内部方法）
- (void)invokeSuccess;

/// 触发失败回调（内部方法）
- (void)invokeFailureWithCode:(NSInteger)code msg:(NSString *)msg;

/// 触发本地缓存就绪回调（内部方法）
- (void)invokeLocalCacheReady;

@end

NS_ASSUME_NONNULL_END