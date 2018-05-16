using System;
using System.Collections.Generic;
using System.Linq;
using XueFu.EntLib.AttributeExtend;
using XueFu.EntLib.Model;

namespace XueFu.EntLib
{
    /// <summary>
    /// ö�ٲ���������
    /// </summary>
    /// <typeparam name="T">ö������</typeparam>
    public static class EnumHelper<T> where T : struct
    {
        #region ���캯��
        private readonly static List<EnumInfo> enumKeyValueList = null;
        static EnumHelper()
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("ָ���Ĳ������ʹ��󣬱�����ö��");
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

        #region ��ȡָ��ֵ��˵��
        /// <summary>
        /// ��ȡ��ǰö��֮��Description����˵����δ��ע <see cref="DescriptionAttribute"/> ������������
        /// </summary>
        /// <param name="value">ö��ֵ�ֶ�</param>
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

        #region ��ȡö��ֵ��˵���ֵ伯��
        /// <summary>
        /// ��ȡ��ǰö�ٵ����ƺ�ֵ�б�
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
