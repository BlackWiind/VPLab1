using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VPLab1
{
    static class SortClass
    {
        public static void Sort(ListBox lb, string str)
        {

            if (str != null)
            {
                var list = new List<string>();
                foreach(var item in lb.Items)
                {
                    list.Add(item.ToString());
                }
                lb.Items.Clear();
                switch (str)
                {
                    case "алфавиту (по возрастанию)":
                        lb.Items.SortDescriptions.Clear();
                        lb.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));
                        break;
                    case "алфавиту (по убыванию)":
                        lb.Items.SortDescriptions.Clear();
                        lb.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Descending));
                        break;
                    case "длине слова (по возрастанию)":                        
                        list.OrderBy(x => x.Length);
                        break;
                    case "длине слова (по убыванию)":
                        list.OrderByDescending(x => x.Length);
                        break;
                    default:
                        MessageBox.Show("Произошел троллинг, обратитесь к администратору.");
                        break;
                }
                foreach (var item in list)
                {
                    lb.Items.Add(item);
                }
            }
        }
    }
}
