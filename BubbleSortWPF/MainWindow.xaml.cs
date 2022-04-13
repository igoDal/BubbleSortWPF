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

namespace BubbleSortWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[] arrayOfEnteredElements;
        public int[] arrayOfSortedElements;
        string[] sortedElements;
        string stringOfSortedElements;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EnteredNumbers.Text.Equals(""))
            {
                Console.WriteLine("Didn't enter any numbers to sort.");
            }
            else
            {
                ConvertToIntArray(EnteredNumbers.Text, ',');
                Sort();
            }
        }

        public void Sort()
        {
            int counter = 0;
            for (int j = 0; j < arrayOfEnteredElements.Length; j++)
            {
                for (int i = 0; i < arrayOfEnteredElements.Length - j - 1; i++)
                {
                    if (arrayOfEnteredElements[i] > arrayOfEnteredElements[i + 1])
                    {
                        int temporary = arrayOfEnteredElements[i];
                        arrayOfEnteredElements[i] = arrayOfEnteredElements[i + 1];
                        arrayOfEnteredElements[i + 1] = temporary;
                    }
                    counter++;
                }

            }

            sortedElements = new string[arrayOfEnteredElements.Length];
            for (int i = 0; i < arrayOfEnteredElements.Length; i++)
            {
                sortedElements[i] = Convert.ToString(arrayOfEnteredElements[i]);
                stringOfSortedElements = String.Join(',', sortedElements[i]);
            }
            stringOfSortedElements = String.Join(',', sortedElements);

            arrayOfSortedElements = arrayOfEnteredElements;
            SortedNumbers.Text = stringOfSortedElements;

            //for (int i = 0; i < arrayOfSortedElements.Length; i++)
            //{
            //    Console.Write($"{arrayOfSortedElements[i]} \n");
            //}
            //Console.WriteLine($"{counter} iterations");
        }

        public int[] ConvertToIntArray(string text, char separator)
        {
            string[] separatedStrings = text.Split(separator);
            arrayOfEnteredElements = new int[separatedStrings.Length];

            for (int i = 0; i < arrayOfEnteredElements.Length; i++) 
            {
                int nextInt;
                string checkedString = separatedStrings[i];
                if(int.TryParse(checkedString, out nextInt))
                {
                    arrayOfEnteredElements[i] = nextInt;
                }
            }
            return arrayOfEnteredElements;
        }
    }
}
