using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPLab1
{
    class ComboItems
    {
        public List<string> ItemsCollection { get; set; }
        public ComboItems()
        {
            ItemsCollection = new List<string>()
            {
                "алфавиту (по возрастанию)",
                "алфавиту (по убыванию)",
                "длине слова (по возрастанию)",
                "длине слова (по убыванию)"
            };
        }
    }
}
