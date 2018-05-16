using System;
using System.Collections.Generic;
using System.Linq;
using XueFu.EntLib.AttributeExtend;
using XueFu.EntLib.Model;

namespace XueFu.EntLib
{
    /// <summary>
    /// 枚举操作辅助类
    /// </summary>
    /// <typeparam name="T">枚举类型</typeparam>
    public static class EnumHelper<T> where T : struct
    {
        #region 构造函数
        private readonly static List<EnumInfo> enumKeyValueList = null;
        static EnumHelper()
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("指定的参数类型错误，必须是枚举");
            }
            enumKeyValueList = new List<EnumInfo>();
            var enumList = Enum.GetValues(enumType);
            foreach (var e in enumList)
            {
                string FieldText = e.ToString();
                int v = (int)e;
                object[] objs = enumType.GetField(FieldText).GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs != null && objs.Length > 0)
                {
                    DescriptionAttribute attr = objs[0] as DescriptionAttribute;
                    FieldText = attr.Description;
                }
                enumKeyValueList.Add(new EnumInfo { Value = v, Description = FieldText, Key = e.ToString() });
            }
        }
        #endregion

        #region 获取指定值的说明
        /// <summary>
        /// 获取当前枚举之的Description属性说明，未标注 <see cref="DescriptionAttribute"/> 返回属性名称
        /// </summary>
        /// <param name="value">枚举值字段</param>
        /// <returns></returns>
        public static string GetDescription(T value)
        {
            string desTest = value.ToString();
            var item = enumKeyValueList.Where(o => o.Key.Equals(desTest, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (null != item)
            {
                desTest = item.Description;
            }
            return desTest;
        }
        #endregion

        #region 获取枚举值和说明字典集合
        /// <summary>
        /// 获取当前枚举的名称和值列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, int> GetSelectList()
        {

            Dictionary<string, int> list = new Dictionary<string, int>();
            enumKeyValueList.ForEach(o =>
            {
                list.Add(o.Description, o.Value);
            });
            return list;
        }
        #endregion

        //public static string GetDescription(this Enum value)
        //{
        //    FieldInfo field = value.GetType().GetField(value.ToString());
        //    if (field.IsDefined(typeof(DescriptionAttribute), false))
        //    {
        //        Attribute customAttribute = field.GetCustomAttribute(typeof(DescriptionAttribute), false);
        //        return (customAttribute as DescriptionAttribute).Description;
        //    }
        //    return string.Empty;
        //}

        //public static List<EnumInfo> ToList(this Enum value)
        //{
        //    return RealList(value.GetType());
        //}

        //private static List<EnumInfo> RealList<T>()
        //{
        //    return RealList(typeof(T));
        //}

        //private static List<EnumInfo> RealList(Type type)
        //{
        //    List<EnumInfo> list = new List<EnumInfo>();
        //    FieldInfo[] fields = type.GetFields();
        //    foreach (FieldInfo field in fields)
        //    {
        //        if (field.IsDefined(typeof(DescriptionAttribute), false))
        //        {
        //            EnumInfo item = new EnumInfo();
        //            item.Description = ((DescriptionAttribute)field.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description;
        //            item.Key = field.Name;
        //            item.Value = Convert.ToInt32(field.GetRawConstantValue());
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
    }
}
