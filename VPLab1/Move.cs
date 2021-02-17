using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VPLab1
{
    static class Move
    {
        public static void SomeMove(ListBox lb1, ListBox lb2)
        {                      
                lb2.Items.Add(lb1.SelectedItem);
                lb1.Items.Remove(lb1.SelectedItem);  
        }

        public static void Allmove(ListBox lb1, ListBox lb2)
        {
            foreach(object item in lb1.Items)
            {
                lb2.Items.Add(item);
            }
            lb1.Items.Clear();
        }
    }
}
