using System;
using System.Collections.Generic;
using System.Text;

namespace XueFu.EntLib
{
    public enum MoneyType
    {
        [Enum("�ֺ�")]
        Bonus,
        [Enum("�Ƽ���")]
        Introduce,
        [Enum("������")]
        Report,
        [Enum("�Ŷӽ�")]
        Team
    }

    public enum GroupType
    {
        [Enum("����Ա")]
        Report = 1,
        [Enum("��ͨ��Ա")]
        User = 2
    }

    public enum OrderType
    {
        Desc,
        Asc
    }

    public enum UserState
    {
        [Enum("����")]
        Frozen = 0,
        [Enum("δ����")]
        NoCheck = 1,
        [Enum("����")]
        Normal = 2
    }

    public enum SexType
    {
        [Enum("����")]
        Secret = 0,
        [Enum("��")]
        Male = 1,
        [Enum("Ů")]
        Female = 2
    }

}
