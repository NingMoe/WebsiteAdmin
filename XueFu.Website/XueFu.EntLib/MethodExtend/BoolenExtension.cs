using System.Collections.Generic;

namespace XueFu.EntLib.MethodExtend
{
    public static class BoolenExtension
    {
        public static string Display(this bool value,int displayType)
        {
            List<string> boolDisplay = new List<string>();
            switch (displayType)
            {
                case 1:
                    boolDisplay.Add("否");
                    boolDisplay.Add("是");
                        break;
                case 2:
                    boolDisplay.Add("X");
                    boolDisplay.Add("√");
                    break;
                default:
                    boolDisplay.Add(bool.FalseString);
                    boolDisplay.Add(bool.TrueString);
                    break;
            }
            if (value)
                return boolDisplay[1];
            else
                return boolDisplay[0];
                    
        }
    }
}
