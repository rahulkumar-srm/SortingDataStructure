using SortingDataStructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingDataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Sorting sorting = new Sorting();

                Console.WriteLine
                    ("Please select an option" +
                        Environment.NewLine + "1. Heap Sort" +
                        Environment.NewLine + "2. Bubble Sort" +
                        Environment.NewLine + "3. Insertion Sort" +
                        Environment.NewLine + "4. Selection Sort" +
                        Environment.NewLine + "5. Quick Sort" +
                        Environment.NewLine + "6. Merge Sort" +
                        Environment.NewLine + "7. Bin Sort" +
                        Environment.NewLine + "8. Shell Sort" +
                        Environment.NewLine + "0. Exit"
                    );

                if (!int.TryParse(Console.ReadLine(), out int i))
                {
                    Console.WriteLine(Environment.NewLine + "Input format is not valid. Please try again." + Environment.NewLine);
                }

                if (i == 0)
                {
                    Environment.Exit(0);
                }
                else if (i == 1)
                {
                    
                    sorting.HeapSort();
                }
                else if (i == 2)
                {
                    sorting.BubbleSort();
                }
                else if (i == 3)
                {
                    sorting.InsertionSort();
                }
                else if (i == 4)
                {
                    sorting.SelectionSort();
                }
                else if (i == 5)
                {
                    sorting.QuickSort();
                }
                else if(i == 6)
                {
                    sorting.MergeSort();
                }
                else if (i == 7)
                {
                    sorting.BinSort();
                }
                else if (i == 8)
                {
                    sorting.ShellSort();
                }
                else
                {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }
    }
}
