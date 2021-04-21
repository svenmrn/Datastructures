using MyLibrary;
using MyLibrary.Sorteeralgoritmen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            lbUnsorted.Items.Add(5);
            lbUnsorted.Items.Add(4);
            lbUnsorted.Items.Add(3);
            lbUnsorted.Items.Add(2);
            lbUnsorted.Items.Add(1);

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
            Stopwatch sw = new Stopwatch();
            sw.Start();

            switch (b.Tag)
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
                        if (!(lbUnsorted.Items[0] is Auto))   //Speciaal geval, sorteren van Auto's
                        {
                            var list = GetList(lbUnsorted);
                            ins.Sort(list);
                            SetList(lbSorted, list);
                        }
                        else
                        {
                            var list = GetAutoList(lbUnsorted);
                            ins.Sort(list);
                            SetList(lbSorted, list);
                        }
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
            sw.Stop();
            lbTime.Text = $"Tijd: {sw.Elapsed.ToString(@"mm\:ss\.fff")}";
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

        private Auto[] GetAutoList(ListBox box)
        {
            var list = new Auto[box.Items.Count];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = (Auto)box.Items[i];
            }
            return list;
        }

        private void SetList(ListBox box, int[] list)
        {
            foreach (var i in list)
                box.Items.Add(i);
        }

        private void SetList(ListBox box, Auto[] list)
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

        private void tbManual_KeyDown(object sender, KeyEventArgs e)
        {
            int nr = 0;
            if (e.Key == Key.Enter && int.TryParse(tbManual.Text, out nr))
            {
                lbUnsorted.Items.Add(nr);
                tbManual.Text = "";
            }
        }

        private void menuCars_Click(object sender, RoutedEventArgs e)
        {
            string[] modellen = new[] { "Opel", "BMW", "Ford", "Mercedes", "Fiat" };
            string[] colors = new[] { "Groen", "Rood", "Blauw", "Wit", "Zwart" };

            for(var i = 0; i < int.Parse(tbAmount.Text); i++)
            {
                var a = new Auto()
                {
                    Model = modellen[new Random().Next(0, modellen.Length)],
                    Kleur = colors[new Random().Next(0, colors.Length)],
                    Bouwjaar = 2000 + new Random().Next(0,20),
                    Brandstof = (Brandstof)new Random().Next(0,3),
                    AantalKm = new Random().Next(100000)
                };
                lbUnsorted.Items.Add(a);
            }
        }
    }
}
