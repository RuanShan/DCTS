using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCTS.Uti
{
    class MessageHelper
    {
        public static bool DeleteConfirm(string msg)
        {

            return MessageBox.Show(msg, "刪除確認", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
    }
}
