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
            if (CacheHelper.Read(configCacheKey) == null)
            {
                RefreshConfigCache();
            }
            return (ConfigInfo)CacheHelper.Read(configCacheKey);
        }

        public static void RefreshConfigCache()
        {
            string fileName = ServerHelper.MapPath(GetFileName());
            ConfigInfo cacheValue = ConfigHelper.ReadPropertyFromXml<ConfigInfo>(fileName);
            CacheDependency cd = new CacheDependency(fileName);
            CacheHelper.Write(configCacheKey, cacheValue, cd);
            RefreshApp();
        }

        public static void RefreshApp()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add(".aspx", ".ashx");
            CheckCode.CodeDot = ReadConfigInfo().CodeDot;
            CheckCode.CodeLength = ReadConfigInfo().CodeLength;
            CheckCode.CodeType = (CodeType)ReadConfigInfo().CodeType;
            CheckCode.Key = ReadConfigInfo().SecureKey;
        }

        public static void UpdateConfigInfo(ConfigInfo config)
        {
            ConfigHelper.UpdatePropertyToXml<ConfigInfo>(ServerHelper.MapPath(GetFileName()), config);
        }

        private static string GetFileName()
        {
            string fileName = "/Config/Config.config";
            return fileName;
        }
    }
}
