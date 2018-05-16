using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace XueFu.EntLib
{
    public class PubConstant
    {
        private readonly static string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
        private readonly static string configPath = "/Config/Config.config";
        private readonly static string languageConfigPath = "/Config/Language.config";
        private readonly static string cacheKeyConfigPath = "/Config/CacheKey.config";

        static PubConstant()
        {
            connectionString = ProcessConnectionString(connectionString);
            configPath = ServerHelper.MapPath(ConfigurationManager.AppSettings["ConfigPath"] ?? configPath);
            languageConfigPath = ServerHelper.MapPath(ConfigurationManager.AppSettings["LanguageConfigPath"] ?? languageConfigPath);
            cacheKeyConfigPath = ServerHelper.MapPath(ConfigurationManager.AppSettings["CacheKeyConfigPath"] ?? cacheKeyConfigPath);
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get { return connectionString; }
        }

        public static string ConfigPath
        {
            get { return configPath; }
        }

        public static string LanguageConfigPath
        {
            get { return languageConfigPath; }
        }

        public static string CacheKeyConfigPath
        {
            get { return cacheKeyConfigPath; }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetAppSettingsString(string configName)
        {
            string appSettingsString = ConfigurationManager.AppSettings[configName];
            return ProcessConnectionString(appSettingsString);
        }


        private static string ProcessConnectionString(string connectionString)
        {
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            return ConStringEncrypt == "true" ? EncryptHelper.DesDecrypt(connectionString) : connectionString;
        }

    }
}
