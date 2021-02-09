using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VPLab1
{
    /// <summary>
    /// Логика взаимодействия для AddForm.xaml
    /// </summary>
    public partial class AddForm : Window
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddAddButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = this.Owner as MainWindow;

            if (TextAdd.Text != "")
            {
                if (AddRadio1.IsChecked == true)
                {
                    main.LeftText.Items.Add(TextAdd.Text);
                }
                else main.RightText.Items.Add(TextAdd.Text);
                this.Close();
            }
        }

        private void AddClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
