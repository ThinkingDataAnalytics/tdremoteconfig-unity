#if __has_include(<TDRemoteConfig/TDRemoteConfig.h>)
#import <TDRemoteConfig/TDRemoteConfig.h>
#else
#import "TDRemoteConfig.h"
#endif


typedef void (*ConfigFetchHandler) (const char *statusData);
static ConfigFetchHandler resultHandler;
void RegisterRecieveConfigCallback(ConfigFetchHandler handlerPointer)
{
    resultHandler = handlerPointer;
}

void rc_convertToDictionary(const char *json, NSDictionary **properties_dict) {
    NSString *json_string = json != NULL ? [NSString stringWithUTF8String:json] : nil;
    if (json_string) {
        *properties_dict = [NSJSONSerialization JSONObjectWithData:[json_string dataUsingEncoding:NSUTF8StringEncoding] options:kNilOptions error:nil];
    }
}

char* rc_strdup(const char* string) {
    if (string == NULL)
        return NULL;
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

void rc_enableLog(BOOL enableLog) {
    [TDRemoteConfig enableLog:enableLog];
}

void rc_init(const char *appId,const char *serverUrl,const char *templateCode,int mode,const char *params){
    NSDictionary *fetch_params = nil;
    rc_convertToDictionary(params, &fetch_params);
    TDRemoteConfigSettings *setting = [[TDRemoteConfigSettings alloc]init];
    NSString *app_id_string = appId != NULL ? [NSString stringWithUTF8String:appId] : nil;
    setting.appId = app_id_string;
    NSString *server_url = serverUrl != NULL ? [NSString stringWithUTF8String:serverUrl] : nil;
    setting.serverUrl = server_url;
    NSString *template_code = templateCode != NULL ? [NSString stringWithUTF8String:templateCode] : nil;
    setting.templateCode = template_code;
    if(mode == 1){
        setting.mode = TDRemoteConfigModeDebug;
    }else{
        setting.mode = TDRemoteConfigModeNormal;
    }
    setting.fetchParams = fetch_params;
    [TDRemoteConfig startWithSettings:setting];
}

void rc_set_default_values(const char *defaultValues,const char *appId){
    NSDictionary *default_values = nil;
    rc_convertToDictionary(defaultValues, &default_values);
    NSString *app_id_string = appId != NULL ? [NSString stringWithUTF8String:appId] : nil;
    [TDRemoteConfig setDefaultValues:default_values appId:app_id_string];
}

void rc_set_fetch_params(const char *fetchParams,const char *appId,const char *templateCode){
    NSDictionary *fetch_params = nil;
    rc_convertToDictionary(fetchParams, &fetch_params);
    NSString *app_id_string = appId != NULL ? [NSString stringWithUTF8String:appId] : nil;
    [TDRemoteConfig setCustomFetchParams:fetch_params appId:app_id_string];
}


void rc_clear_default_values(const char *appId){
    NSString *app_id_string = appId != NULL ? [NSString stringWithUTF8String:appId] : nil;
    [TDRemoteConfig clearDefaultValuesWithAppId:app_id_string];
}

void rc_remove_fetch_param(const char *key,const char *appId,const char *templateCode){
    NSString *key_string = key != NULL ? [NSString stringWithUTF8String:key] : nil;
    NSString *app_id_string = appId != NULL ? [NSString stringWithUTF8String:appId] : nil;
    [TDRemoteConfig removeCustomFetchParam:key_string appId:app_id_string];
}

void rc_fetch(const char *appId,const char *templateCode){
    NSString *app_id_string = appId != NULL ? [NSString stringWithUTF8String:appId] : nil;
    [TDRemoteConfig fetchWithAppId:app_id_string];
}

const char *rc_get_all_data(const char *configId,const char *templateId){
    NSString *config_id_string = configId != NULL ? [NSString stringWithUTF8String:configId] : nil;
    NSString *template_id_string = templateId != NULL ? [NSString stringWithUTF8String:templateId] : nil;
    TDObject *obj = [TDRemoteConfig getData].get(config_id_string);
    if ([template_id_string isKindOfClass:NSString.class]) {
        obj = obj.get(template_id_string);
    }
    NSString *str = [obj configValue];
    return rc_strdup([str UTF8String]);
}

@interface TDRemoteConfigReceiver : NSObject

@end

@implementation TDRemoteConfigReceiver

+ (void)fun:(NSNotification *)notification {
    NSDictionary *info = notification.userInfo[kTDRemoteConfigStrategyStatusMap];
    NSData *data = [NSJSONSerialization dataWithJSONObject:info options:kNilOptions error:nil];
    NSString *jsonString = [[NSString alloc]initWithData:data encoding:NSUTF8StringEncoding];
    resultHandler(rc_strdup([jsonString UTF8String]));
}

@end

void rc_setConfigFetchDelegate(){
    [[NSNotificationCenter defaultCenter] addObserver:TDRemoteConfigReceiver.class selector:@selector(fun:) name:kTDRemoteConfigFetchDataSuccess object:nil];
}

