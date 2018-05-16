using System;
using System.Web.Caching;
using System.Collections.Generic;
using XueFu.EntLib;
using XueFu.Model;

namespace XueFu.Common
{    
    public sealed class Config
    {        
        private static string configCacheKey = "Config";
                
        public static ConfigInfo ReadConfigInfo()
        {
            ConfigInfo config = (ConfigInfo)CacheHelper.Read(configCacheKey);
            if (config == null)
            {
                RefreshConfigCache();
                config = (ConfigInfo)CacheHelper.Read(configCacheKey);
            }
            return config;
        }

        public static void RefreshConfigCache()
        {
            string fileName = PubConstant.ConfigPath;
            ConfigInfo cacheValue = ConfigHelper.ReadPropertyFromXml<ConfigInfo>(fileName);
            CacheDependency cd = new CacheDependency(fileName);
            CacheHelper.Write(configCacheKey, cacheValue, cd);
            RefreshApp();
        }

        public static void RefreshApp()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add(".aspx", ".ashx");
            ConfigInfo config = ReadConfigInfo();
            CheckCode.CodeDot = config.CodeDot;
            CheckCode.CodeLength = config.CodeLength;
            CheckCode.CodeType = (CodeType)config.CodeType;
            CheckCode.Key = config.SecureKey;
        }

        public static void UpdateConfigInfo(ConfigInfo config)
        {
            ConfigHelper.UpdatePropertyToXml<ConfigInfo>(PubConstant.ConfigPath, config);
        }
    }
}
