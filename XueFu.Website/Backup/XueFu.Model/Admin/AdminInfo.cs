using System;
using System.Collections.Generic;
using System.Text;

namespace XueFu.Model
{
    public sealed class AdminInfo : AccoutBaseInfo
    {
        private string notBook;

        public string NoteBook
        {
            get { return this.notBook; }
            set { this.notBook = value; }
        }
    }
}
