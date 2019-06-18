using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Forms;

namespace WalletWPF.Helpers
{
    public static class InvokeHelper
    {

        //public static void InvokeIfRequired(this Control c, MethodInvoker action)
        //{
        //    if (c.InvokeRequired)
        //    {
        //        c.Invoke(action);
        //    }
        //    else
        //    {
        //        action();
        //    }
        //}

        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}
