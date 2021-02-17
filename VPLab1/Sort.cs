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
                list.Clear();
                foreach (var item in lb.Items)
                {
                    list.Add(item.ToString());
                }
                lb.Items.Clear();
                switch (str)
                {
                    case "алфавиту (по возрастанию)":
                        list = list.OrderBy(x => x).ToList();                       
                        break;
                    case "алфавиту (по убыванию)":
                        list = list.OrderByDescending(x => x).ToList();                        
                        break;
                    case "длине слова (по возрастанию)":                        
                        list = list.OrderBy(x => x.Length).ToList();
                        break;
                    case "длине слова (по убыванию)":
                        list = list.OrderByDescending(x => x.Length).ToList();                        
                        break;
                    default:
                        MessageBox.Show("Произошел троллинг, обратитесь к администратору.");
                        break;
                }
                foreach (string item in list)
                {
                    lb.Items.Add(item);
                }
                lb.Items.Refresh();                
            }
        }
    }
}
