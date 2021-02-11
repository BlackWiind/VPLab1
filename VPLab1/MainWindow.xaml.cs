using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace VPLab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ExitCommandContext();
            this.DataContext = new ComboItems();
        }

        private void CommandBindingNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();

            openFile1.DefaultExt = "*.txt";
            openFile1.Filter = "Text Files|*.txt";

            if (openFile1.ShowDialog() == true)
            {
                TextRange doc = new TextRange(BigText.Document.ContentStart, BigText.Document.ContentEnd);
                using (FileStream fs = new FileStream(openFile1.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(openFile1.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        MessageBox.Show("Файл какая-то фигня!"); //переделать сообщение
                }
            }
        }
        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Text Files|*.txt";

            if (saveFile1.ShowDialog() == true)
            {
                TextRange doc = new TextRange(BigText.Document.ContentStart, BigText.Document.ContentEnd);
                using (FileStream fs = File.Create(saveFile1.FileName))
                {
                    doc.Save(fs, DataFormats.Text);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LeftText.Items.Clear();
            RightText.Items.Clear();

            TextRange tr = new TextRange(BigText.Document.ContentStart, BigText.Document.ContentEnd);

            string[] str = tr.Text.Split(new char[] { '\n' , '\t', ' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in str)
            {
                string strm = s.Trim();

                if (strm == String.Empty) continue;
                if (rb1.IsChecked == true) LeftText.Items.Add(strm);
                if (rb2.IsChecked == true)
                {
                    if (Regex.IsMatch(strm, @"\d")) LeftText.Items.Add(strm);
                }
                if (rb3.IsChecked == true)
                {
                    if (Regex.IsMatch(strm, @"\w+@\w+\.\w+")) LeftText.Items.Add(strm);
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            RightText.Items.Clear();
            LeftText.Items.Clear();
            BigText.Document.Blocks.Clear();
            rb1.IsChecked = true;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchText.Items.Clear();

            string find = TextBoxF.Text;

            if (FindCheck1.IsChecked == true)
            {
                foreach (string str in LeftText.Items)
                {
                    if (str.Contains(find)) SearchText.Items.Add(str);
                }
            }

            if (FindCheck2.IsChecked == true)
            {
                foreach (string str in RightText.Items)
                {
                    if (str.Contains(find)) SearchText.Items.Add(str);
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddForm aForm = new AddForm();

            aForm.Owner = this;
            aForm.ShowDialog();
        }

        private void DeleteString(ListBox lb)
        {
            for (int i = lb.Items.Count - 1; i >= 0; i--)
            {
                if (lb.SelectedIndex == i) lb.Items.RemoveAt(i);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftText.SelectedItem != null)
            {
                DeleteString(LeftText);
            }
            if (RightText.SelectedItem != null)
            {
                DeleteString(RightText);
            }
        }

        private void ToRightButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (object item in LeftText.SelectedItems)
            {
                RightText.Items.Add(item);
              //  LeftText.Items.Remove(item);
            }
        }

        private void ToLeftButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (object item in RightText.SelectedItems)
            {
                LeftText.Items.Add(item);
              //  RightText.Items.Remove(item);
            }
        }

        private void AllRightButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (object item in LeftText.Items)
            {
                RightText.Items.Add(item);
            }
            LeftText.Items.Clear();
        }

        private void AllLeftButton_Click(object sender, RoutedEventArgs e)
        {
            LeftText.Items.Add(RightText.Items);
            RightText.Items.Clear();
        }

        private void SortAlph(ListBox lb, bool b)
        {
            if(b == true)
            {
                lb.Items.SortDescriptions.Add(new SortDescription("Content", ListSortDirection.Ascending));
            }
            else
            {
                lb.Items.SortDescriptions.Add(new SortDescription("Content", ListSortDirection.Ascending));
            }
           
        }
    }
}
