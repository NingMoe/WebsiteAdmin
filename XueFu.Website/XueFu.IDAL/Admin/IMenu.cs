using System;
using System.Collections.Generic;
using XueFu.Model;

namespace XueFu.IDAL
{
    public interface IMenu
    {
        
        int AddMenu(MenuInfo Menu);
        void DeleteMenu(int id);
        void MoveDownMenu(int id);
        void MoveUpMenu(int id);
        List<MenuInfo> ReadMenuAllList();
        void UpdateMenu(MenuInfo Menu);
    }
}
