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
        }

        /// <summary>
        /// Genereer een aantal willekeurige getallen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateUI(true);
                var rg = new RandomGenerator(ReadInput(tbAmount), ReadInput(tbMin), ReadInput(tbMax), cbUnique.IsChecked.Value);
                var list = rg.GenerateNumbers();
                SetList(lbUnsorted, list);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateUI();
            }
        }



        /// <summary>
        /// Beide listboxen leegmaken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            lbUnsorted.Items.Clear();
            lbSorted.Items.Clear();
        }

        /// <summary>
        /// Sorteer de lijst met behulp van een bepaald algoritme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSort_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;        //Van welke knop komt de click ?
            lbSorted.Items.Clear();             //Gesorteerde lijst wissen
            UpdateUI(true);

            Stopwatch sw = new Stopwatch();    //Stopwatch voor tijdsmeting
            sw.Start();                     

            switch (b.Tag)
            {
                case "BS":   //Bubble sort
                    {
                        //var bs = new BubbleSort();              //Voorbeeld code, sorteeralgo zelf te maken 
                        //var list = GetList(lbUnsorted);
                        //bs.Sort(list);
                        //SetList(lbSorted, list);
                    }
                    break;
                case "SS":   //Selection Sort
                    {
                      
                    }
                    break;
                case "IS":   //Insertion Sort
                    {
                    }   
                    break;
                case "QS":   //Quicksort
                    {
                       
                    }
                    break;
                case "MS":    //Merge sort
                    {
                       
                    }
                    break;
                default:
                    MessageBox.Show("dit algoritme is nog niet in werking !");
                    break;
            }
            sw.Stop();
            lbTime.Text = $"Tijd: {sw.Elapsed.ToString(@"mm\:ss\.fff")}";
            UpdateUI();
        }

        /// <summary>
        /// Helper methode om de invoer om te zetten naar een integer
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        private int ReadInput(TextBox box)
        {
            int temp = 0;
            if (int.TryParse(box.Text, out temp))
                return temp;

            throw new Exception("ingevoerde waarde is ongeldig");
        }

        /// <summary>
        /// Haal de waarden uit een listbox en zet ze om naar een array
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        private int[] GetList(ListBox box)
        {
            int[] list = new int[box.Items.Count];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = (int)box.Items[i];
            }
            return list;
        }

        /// <summary>
        /// Voeg de lijst met getallen toe aan een listbox
        /// </summary>
        /// <param name="box"></param>
        /// <param name="list"></param>
        private void SetList(ListBox box, int[] list)
        {
            foreach (var i in list)
                box.Items.Add(i);
        }

        private void UpdateUI(bool busy = false)
        {
            Mouse.OverrideCursor = busy ?Cursors.Wait: null;
        }

        /// <summary>
        /// Geef manueel een getal in, voeg dit toe aan de lijst van unsorted elementen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbManual_KeyDown(object sender, KeyEventArgs e)
        {
            int nr = 0;
            if (e.Key == Key.Enter && int.TryParse(tbManual.Text, out nr))
            {
                lbUnsorted.Items.Add(nr);
                tbManual.Text = "";
            }
        }

        /// <summary>
        /// Voeg een aantal willekeurige auto's toe (code zelf te schrijven)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCars_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
