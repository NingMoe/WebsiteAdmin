using System;
using System.Collections.Generic;
using System.Text;
using XueFu.EntLib.AttributeExtend;

namespace XueFu.EntLib
{
    public enum MoneyType
    {
        [Description("分红")]
        Bonus,
        [Description("推荐奖")]
        Introduce,
        [Description("报单奖")]
        Report,
        [Description("团队奖")]
        Team
    }

    public enum GroupType
    {
        [Description("报单员")]
        Report = 1,
        [Description("普通会员")]
        User = 2
    }

    public enum OrderType
    {
        Desc,
        Asc
    }

    public enum UserState
    {
        [Description("冻结")]
        Frozen = 0,
        [Description("未激活")]
        NoCheck = 1,
        [Description("正常")]
        Normal = 2
    }

    public enum SexType
    {
        [Description("保密")]
        Secret = 0,
        [Description("男")]
        Male = 1,
        [Description("女")]
        Female = 2
    }

    public enum PowerCheckType
    {
        Single,
        OR,
        AND
    }

    public enum ChangeAction
    {
        Up,
        Down,
        Plus,
        Minus
    }

}
