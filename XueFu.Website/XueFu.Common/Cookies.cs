using System;
using XueFu.EntLib;
using System.Web.Security;
using System.Web;

namespace XueFu.Common
{    
    public sealed class Cookies
    {
        public sealed class Admin
        {
            
            private static string cookiesName = Config.ReadConfigInfo().AdminCookies;

            
            private static bool CheckCookies()
            {
                string str = CookiesHelper.ReadCookieValue(cookiesName);
                if (str != string.Empty)
                {
                    try
                    {
                        string[] strArray = str.Split(new char[] { '|' });
                        string str2 = strArray[0];
                        string str3 = strArray[1];
                        string str4 = strArray[2];
                        string str5 = strArray[3];
                        string str6 = strArray[4];
                        if (EncryptHelper.MD5(str3 + str4 + str5 + str6 + Config.ReadConfigInfo().SecureKey + ClientHelper.Agent).ToLower() == str2.ToLower())
                        {
                            return true;
                        }
                        CookiesHelper.DeleteCookie(cookiesName);
                    }
                    catch
                    {
                        CookiesHelper.DeleteCookie(cookiesName);
                    }
                }
                return false;
            }

            public static int GetAdminID(bool check)
            {
                int num = 0;
                if (!check || (check && CheckCookies()))
                {
                    string str = CookiesHelper.ReadCookieValue(cookiesName);
                    if (!(str != string.Empty))
                    {
                        return num;
                    }
                    try
                    {
                        num = Convert.ToInt32(str.Split(new char[] { '|' })[1]);
                    }
                    catch
                    {
                    }
                }
                return num;
            }

            public static string GetAdminName(bool check)
            {
                string str = string.Empty;
                if (!check || (check && CheckCookies()))
                {
                    string str2 = CookiesHelper.ReadCookieValue(cookiesName);
                    if (!(str2 != string.Empty))
                    {
                        return str;
                    }
                    try
                    {
                        str = str2.Split(new char[] { '|' })[2];
                    }
                    catch
                    {
                    }
                }
                return str;
            }

            public static int GetGroupID(bool check)
            {
                int num = 0;
                if (!check || (check && CheckCookies()))
                {
                    string str = CookiesHelper.ReadCookieValue(cookiesName);
                    if (!(str != string.Empty))
                    {
                        return num;
                    }
                    try
                    {
                        num = Convert.ToInt32(str.Split(new char[] { '|' })[3]);
                    }
                    catch
                    {
                    }
                }
                return num;
            }

            public static string GetRandomNumber(bool check)
            {
                string str = string.Empty;
                if (!check || (check && CheckCookies()))
                {
                    string str2 = CookiesHelper.ReadCookieValue(cookiesName);
                    if (!(str2 != string.Empty))
                    {
                        return str;
                    }
                    try
                    {
                        str = str2.Split(new char[] { '|' })[4];
                    }
                    catch
                    {
                    }
                }
                return str;
            }
        }

        public sealed class Common
        {
            
            public static string checkcode
            {
                get
                {
                    return StringHelper.Decode(CookiesHelper.ReadCookieValue(CheckCode.CookiesName), CheckCode.Key);
                }
            }
        }

        public sealed class User
        {            
            private static string cookiesName = Config.ReadConfigInfo().UserCookies;
            
            private static bool CheckCookies()
            {
                string str = CookiesHelper.ReadCookieValue(cookiesName);
                if (str != string.Empty)
                {
                    try
                    {
                        string[] strArray = str.Split(new char[] { '|' });
                        string str2 = strArray[0];
                        string str3 = strArray[1];
                        string str4 = strArray[2];
                        string str5 = strArray[3];
                        string str6 = strArray[4];
                        if (EncryptHelper.MD5(str3 + str4 + str5 + str6 + Config.ReadConfigInfo().SecureKey + ClientHelper.Agent).ToLower() == str2.ToLower())
                        {
                            return true;
                        }
                        CookiesHelper.DeleteCookie(cookiesName);
                    }
                    catch
                    {
                        CookiesHelper.DeleteCookie(cookiesName);
                    }
                }
                return false;
            }

            public static int GetUserID(bool check)
            {
                int num = 0;
                if (!check || (check && CheckCookies()))
                {
                    string str = CookiesHelper.ReadCookieValue(cookiesName);
                    if (!(str != string.Empty))
                    {
                        return num;
                    }
                    try
                    {
                        num = Convert.ToInt32(str.Split(new char[] { '|' })[1]);
                    }
                    catch
                    {
                    }
                }
                return num;
            }

            public static string GetUserName(bool check)
            {
                string str = string.Empty;
                if (!check || (check && CheckCookies()))
                {
                    string str2 = CookiesHelper.ReadCookieValue(cookiesName);
                    if (!(str2 != string.Empty))
                    {
                        return str;
                    }
                    try
                    {
                        str = HttpContext.Current.Server.UrlDecode(str2.Split(new char[] { '|' })[2]);
                    }
                    catch
                    {
                    }
                }
                return str;
            }

            public static string GetRealName(bool check)
            {
                string str = string.Empty;
                if (!check || (check && CheckCookies()))
                {
                    string str2 = CookiesHelper.ReadCookieValue(cookiesName);
                    if (!(str2 != string.Empty))
                    {
                        return str;
                    }
                    try
                    {
                        str = HttpContext.Current.Server.UrlDecode(str2.Split(new char[] { '|' })[3]);
                    }
                    catch
                    {
                    }
                }
                return str;
            }

            public static int GetGroupID(bool check)
            {
                int num = 0;
                if (!check || (check && CheckCookies()))
                {
                    string str = CookiesHelper.ReadCookieValue(cookiesName);
                    if (!(str != string.Empty))
                    {
                        return num;
                    }
                    try
                    {
                        num = Convert.ToInt32(str.Split(new char[] { '|' })[4]);
                    }
                    catch
                    {
                    }
                }
                return num;
            }

            public static int GetMobile(bool check)
            {
                int num = 0;
                if (!check || (check && CheckCookies()))
                {
                    string str = CookiesHelper.ReadCookieValue(cookiesName);
                    if (!(str != string.Empty))
                    {
                        return num;
                    }
                    try
                    {
                        num = Convert.ToInt32(str.Split(new char[] { '|' })[5]);
                    }
                    catch
                    {
                    }
                }
                return num;
            }

            public static int GetGradeID(bool check)
            {
                int num = 0;
                if (!check || (check && CheckCookies()))
                {
                    string str = CookiesHelper.ReadCookieValue(cookiesName);
                    if (!(str != string.Empty))
                    {
                        return num;
                    }
                    try
                    {
                        num = Convert.ToInt32(str.Split(new char[] { '|' })[4]);
                    }
                    catch
                    {
                    }
                }
                return num;
            }
        }
    }
}
