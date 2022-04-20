using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMage2
{
    public class engGLog
    {
        private ListBox lstLog;

        public engGLog(ListBox lstLog)
        {
            this.lstLog = lstLog;
        }

        public void Add(string msg)
        {
            lstLog.Items.Insert(0, msg);
        }
        public void ClearLog()
        {
            lstLog.Items.Clear();
        }
    }
}
