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

            return MessageBox.Show(msg, "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        public static DialogResult ErrorBox(string msg)
        {
            return MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult AlertBox(string msg)
        {
            return MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult InfoBox(string msg)
        {
            return MessageBox.Show(msg, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
