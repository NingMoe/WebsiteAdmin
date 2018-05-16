using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XueFu.EntLib.MethodExtend
{
    public static class EnumExtension
    {
        /// <summary>
        /// 获取当前枚举之的Description属性说明，未标注DescriptionAttribute返回属性名称
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static string GetDescription<T>(this T value) where T : struct
        {
            return EnumHelper<T>.GetDescription(value);
        }


        public static Dictionary<string, int> ToList<T>(this T value) where T : struct
        {
            return EnumHelper<T>.GetSelectList();
        }
    }
}
