using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VPLab1
{
    static class SomeClear
    {
        public static void Clear(ListBox lb1 = null, ListBox lb2 = null, RichTextBox tb = null, RadioButton rb = null)
        {
            if (lb1 != null) { lb1.Items.Clear(); }
            if (lb2 != null) { lb2.Items.Clear(); }
            if (tb != null) { tb.Document.Blocks.Clear(); }
            if (rb != null) { rb.IsChecked = true; }           
        }
    }
}
