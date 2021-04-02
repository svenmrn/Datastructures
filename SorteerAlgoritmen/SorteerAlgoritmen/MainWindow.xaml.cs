using MyLibrary.Sorteeralgoritmen;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SorteerAlgoritmen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void btGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateUI(true);
                var rg = new RandomGenerator(ReadInput(tbAmount), ReadInput(tbMin), ReadInput(tbMax), cbUnique.IsChecked.Value);
                var list = rg.GenerateNumbers();
                foreach (var l in list)
                    lbUnsorted.Items.Add(l);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateUI(false);
            }
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            lbUnsorted.Items.Clear();
            lbSorted.Items.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            UpdateUI(true);
            Mouse.OverrideCursor = Cursors.Wait;
            lbSorted.Items.Clear();
            switch(b.Tag)
            {
                case "BS":
                    {
                        var bs = new BubbleSort();
                        var list = GetList(lbUnsorted);
                        bs.Sort(list);
                        SetList(lbSorted, list);
                    }
                    break;
                case "SS":
                    {
                        var ss = new SelectionSort();
                        var list = GetList(lbUnsorted);
                        ss.Sort(list);
                        SetList(lbSorted, list);
                    }
                    break;
                case "IS":
                    {
                        var ins = new InsertionSort();
                        var list = GetList(lbUnsorted);
                        ins.Sort(list);
                        SetList(lbSorted, list);
                    }
                    break;
                case "QS":
                    {
                        var qs = new QuickSort();
                        var list = GetList(lbUnsorted);
                        qs.Sort(list, 0, list.Length - 1);
                        SetList(lbSorted, list);
                    }
                    break;
                case "MS":
                    {
                        var ms = new MergeSort();
                        var list = GetList(lbUnsorted);
                        var sortedList = ms.Sort(list);
                        SetList(lbSorted, sortedList);
                    }
                    break;
                default:
                    MessageBox.Show("dit algoritme is nog niet in werking !");
                    break;
            }
            UpdateUI(false);
        }

        private int ReadInput(TextBox box)
        {
            int temp = 0;
            if (int.TryParse(box.Text, out temp))
                return temp;

            throw new Exception("ingevoerde waarde is ongeldig");
        }

        private int[] GetList(ListBox box)
        {
            int[] list = new int[box.Items.Count];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = (int)box.Items[i];
            }
            return list;
        }

        private void SetList(ListBox box, int[] list)
        {
            foreach (var i in list)
                box.Items.Add(i);
        }

        private void UpdateUI(bool busy = false)
        {
            Mouse.OverrideCursor = busy ?Cursors.Wait: null;
            btGenerate.IsEnabled = !busy;
            btBubble.IsEnabled = !busy;
            btSelection.IsEnabled = !busy;
            btInsertion.IsEnabled = !busy;
            btQuick.IsEnabled = !busy;
            btMerge.IsEnabled = !busy;
        }

 
    }
}
