using System;
using System.Data;
using System.Configuration;

namespace XueFu.Common
{
    public sealed class Global
    {
        public static string CopyRight = "Copyright \x00a9 XueFu Website 2018";
        private static string dataProvider = string.Empty;
        public static string Description = "<span>本系统，开发的语言是net(C#)。系统采用三层结构，充分利用了缓存技术；对sql语句和相关逻辑的优化；经过多次的反复测试；大大提高了系统的反应速度。<span>";
        public static string ProductName = "果咖管理平台";
        public static string Version = "V1.0";

        public static string DataProvider
        {
            get
            {
                if (dataProvider == string.Empty)
                {
                    dataProvider = ConfigurationManager.AppSettings["DataProvider"];
                }
                return dataProvider;
            }
        }
    }

}
