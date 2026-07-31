//
//  TDObject.h
//  DevelopProgram
//
//  Created by 杨雄 on 2024/9/9.
//

@class TDObject;

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef TDObject *__nullable(^TDObjectOperation)(NSString *);
typedef TDObject *__nullable(^TDObjectOperationDefault)(NSString *, __nullable id);
typedef TDObject *__nullable(^TDObjectOperationFilter)(BOOL(^)(TDObject *));

@interface TDObject : NSObject

@property (nonatomic, strong, nullable) id originValue;

- (TDObject *)objectAtIndexedSubscript:(NSUInteger)idx;

/// Get value
/// e.g.
///     get(@"key1").get(@"key2")
- (TDObjectOperation)get;

/// Get value with default value
/// e.g.
///     get(@"dict").getWithDefault(@"key2", @"placehold")
- (TDObjectOperationDefault)getWithDefault;

/// Filter the elements in the array with a filter
/// e.g.
///  get(@"config_1").arrayWithFilter(^(TDObject *obj){
///      NSInteger num = obj.get(@"child_key").numberValue.integerValue;
///      BOOL result = num > 100;
///      return result;
///  })[0].stringValue;
- (TDObjectOperationFilter)arrayWithFilter;

- (nullable NSString *)stringValue;
- (nullable NSArray *)arrayValue;
- (nullable NSDictionary *)objectValue;
- (nullable NSNumber *)numberValue;
- (nullable NSNumber *)longNumber;
- (nullable NSNumber *)doubleNumber;
- (nullable NSString *)configValue;

@end

NS_ASSUME_NONNULL_END
