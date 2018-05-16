using System;
using System.Collections.Generic;
using System.Text;

namespace XueFu.EntLib
{
    public enum MoneyType
    {
        [Enum("分红")]
        Bonus,
        [Enum("推荐奖")]
        Introduce,
        [Enum("报单奖")]
        Report,
        [Enum("团队奖")]
        Team
    }

    public enum GroupType
    {
        [Enum("报单员")]
        Report = 1,
        [Enum("普通会员")]
        User = 2
    }

    public enum OrderType
    {
        Desc,
        Asc
    }

    public enum UserState
    {
        [Enum("冻结")]
        Frozen = 0,
        [Enum("未激活")]
        NoCheck = 1,
        [Enum("正常")]
        Normal = 2
    }

    public enum SexType
    {
        [Enum("保密")]
        Secret = 0,
        [Enum("男")]
        Male = 1,
        [Enum("女")]
        Female = 2
    }

}
