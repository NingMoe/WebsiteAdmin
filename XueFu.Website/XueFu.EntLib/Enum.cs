using System;
using System.Collections.Generic;
using System.Text;
using XueFu.EntLib.AttributeExtend;

namespace XueFu.EntLib
{
    public enum MoneyType
    {
        [Description("�ֺ�")]
        Bonus,
        [Description("�Ƽ���")]
        Introduce,
        [Description("������")]
        Report,
        [Description("�Ŷӽ�")]
        Team
    }

    public enum GroupType
    {
        [Description("����Ա")]
        Report = 1,
        [Description("��ͨ��Ա")]
        User = 2
    }

    public enum OrderType
    {
        Desc,
        Asc
    }

    public enum UserState
    {
        [Description("����")]
        Frozen = 0,
        [Description("δ����")]
        NoCheck = 1,
        [Description("����")]
        Normal = 2
    }

    public enum SexType
    {
        [Description("����")]
        Secret = 0,
        [Description("��")]
        Male = 1,
        [Description("Ů")]
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
