using System;

namespace XueFu.EntLib.AttributeExtend
{
    public class DescriptionAttribute : Attribute
    {
        private string description;

        public DescriptionAttribute(string description)
        {
            this.description = description;
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }
    }
}
