using System;
using XueFu.Common;
using XueFu.EntLib;

namespace XueFu.Website
{
    public partial class Record : UserBasePage
    {
        protected string action = RequestHelper.GetQueryString<string>("Action");

        protected void Page_Load(object sender, EventArgs e)
        {
            string pageTitle = string.Empty;
            switch (action)
            { 
                case "Bonus":
                    pageTitle = "�ֺ��¼";
                    break;

                case "AddUser":
                    pageTitle = "������¼";
                    break;

                case "Introduce":
                    pageTitle = "�Ƽ���¼";
                    break;

                case "Transfer":
                    pageTitle = "ת�ʼ�¼";
                    break;

                case "Notice":
                    pageTitle = "��Ա����";
                    break;
            }

            ((Master)Master).Title = pageTitle;
        }
    }
}
