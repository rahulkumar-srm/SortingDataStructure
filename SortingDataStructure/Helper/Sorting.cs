using SortingDataStructure.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingDataStructure.Helper
{
    internal class Sorting
    {
        internal void HeapSort()
        {
            HeapADT heapADT = new HeapADT(50);
            heapADT.CreateHeap();

            int i = heapADT.top;

            while(i > 0)
            {
                heapADT.DeleteFromHeap();
                i--;
            }

            while(heapADT.item[++i] > 0)
            {
                Console.Write(heapADT.item[i] + " ");
            }

            Console.WriteLine();
        }

        internal void BubbleSort()
        {
            int[] item = new int[50];
            int flag, tempData, n = 0;

            n = FillArray(item, n);

            for (int i = 0; i < n - 1; i++)
            {
                flag = 0;

                for(int j = 0; j < n - 1 - i; j++)
                {
                    if(item[j] > item[j+1])
                    {
                        tempData = item[j];
                        item[j] = item[j+1];
                        item[j+1] = tempData;

                        flag = 1;
                    }
                }

                if (flag == 0)
                    break;
            }

            DisplaySortedArray(item, n);
        }

        internal void InsertionSort()
        {
            int[] item = new int[50];
            int tempData, n = 0;

            n = FillArray(item, n);

            for (int i = 0; i < n - 1; i++)
            {
                int j = i + 1;
                tempData = item[j];

                while (item[j - 1] > tempData && j > 0)
                {
                    item[j] = item[j - 1];
                    j--;
                }

                item[j] = tempData;
            }

            DisplaySortedArray(item, n);
        }

        internal void SelectionSort()
        {
            int[] item = new int[50];
            int k, tempData, n = 0;

            n = FillArray(item, n);

            for(int i = 0; i < n-1; i++)
            {
                k = i;

                for(int j = i+1; j < n; j++)
                {
                    if(item[j] < item[k])
                    {
                        k = j;
                    }
                }

                tempData = item[i];
                item[i] = item[k];
                item[k] = tempData;
            }

            DisplaySortedArray(item, n);
        }

        internal void QuickSort()
        {
            int[] item = new int[50];
            int n = 0;

            n = FillArray(item, n);
            item[n++] = int.MaxValue;

            RQuickSorting(item, 0, n - 1);

            DisplaySortedArray(item, n-1);
        }

        internal void MergeSort()
        {
            int[] item = new int[50];
            int i, n = 0;

            n = FillArray(item, n);

            //for(i = 2; i <= n; i = i * 2)
            //{
            //    for(int j = 0; j < n -1; j = i + j)
            //    {
            //        int l = j;
            //        int h = j + i - 1;
            //        int mid = (l + h) / 2;
            //        Merge(item, l, mid, h);
            //    }
            //}

            //if(i/2 < n)
            //{
            //    Merge(item, 0, i / 2 - 1, n - 1);
            //}

            RMergeSort(item, 0, n - 1);

            DisplaySortedArray(item, n - 1);
        }

        internal void BinSort()
        {
            int[] item = new int[50];
            int n = 0;

            n = FillArray(item, n);

            int max = FindMax(item, n);

            Node[] temp = new Node[item[max] + 1];

            for(int i = 0; i < n; i++)
            {
                if(temp[item[i]] == null)
                {
                    temp[item[i]] = new Node(item[i]);
                }
                else
                {
                    InsertData(temp[item[i]], item[i]);
                }
            }

            n = 0;

            for(int i = 0; i < temp.Length; i++)
            {
                if(temp[i] != null)
                {
                    Node tempNode = temp[i];
                    while (tempNode != null)
                    {
                        item[n++] = tempNode.Data;
                        tempNode = tempNode.Next;
                    }
                }
            }

            DisplaySortedArray(item, n - 1);
        }

        internal void ShellSort()
        {
            int[] item = new int[50];
            int tempData, i = 0, j = 0, n = 0;

            n = FillArray(item, n);

            int gap = n / 2;

            while (gap > 0)
            {
                if(i + gap < n  && item[i + gap] < item[i])
                {
                    tempData = item[i + gap];
                    item[i + gap] = item[i];

                    j = i;

                    while(j - gap >= 0 && item[j - gap] > tempData)
                    {
                        item[j] = item[j - gap];

                        j = j - gap;
                    }

                    item[j] = tempData;
                }

                i++;
                j = 0;

                if(i == n)
                {
                    gap = gap / 2;
                    i = 0;
                }
            }

            DisplaySortedArray(item, n);
        }

        private void RMergeSort(int[] item, int l, int h)
        {
            if(l < h)
            {
                int mid = (l + h) / 2;
                RMergeSort(item, l, mid);
                RMergeSort(item, mid + 1, h);
                Merge(item, l, mid, h);
            }
        }

        private void Merge(int[]item, int l, int mid, int h) 
        {
            int i = l, j = mid + 1, k = l;
            int[] temp = new int[100];
            while (i <= mid && j <= h)
            {
                if (item[i] < item[j])
                    temp[k++] = item[i++];
                else
                    temp[k++] = item[j++];
            }
            for (; i <= mid; i++)
                temp[k++] = item[i];
            for (; j <= h; j++)
                temp[k++] = item[j];
            for (i = l; i <= h; i++)
                item[i] = temp[i];
        }

        private void RQuickSorting(int[] item, int l, int h)
        {
            if(l < h)
            {
                int j = FindPartition(item, l, h);
                RQuickSorting(item, l, j);
                RQuickSorting(item, j + 1, h);
            }
        }

        private int FindPartition(int[] item, int l, int h)
        {
            int pivot = item[l];
            int i = l;
            int j = h;
            int tempData;

            while(i < j)
            {
                while(item[i] <= pivot)
                {
                    i++;
                }

                while(item[j] > pivot)
                {
                    j--;
                }

                if(i < j)
                {
                    tempData = item[i];
                    item[i] = item[j];
                    item[j] = tempData;
                }
            }

            item[l] = item[j];
            item[j] = pivot;

            return j;
        }

        private static int FillArray(int[] item, int n)
        {
            while (true)
            {
                Console.WriteLine("Enter the number");
                int num = Convert.ToInt32(Console.ReadLine());

                if (num == -1)
                {
                    break;
                }

                item[n++] = num;
            }

            return n;
        }

        private static void DisplaySortedArray(int[] item, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(item[i] + " ");
            }

            Console.WriteLine();
        }

        private int FindMax(int[] item, int length)
        {
            int i = 1, j = 0;

            while(i < length)
            {
                if(item[i]>item[j])
                {
                    j = i;
                }

                i++;
            }

            return j;
        }

        private void InsertData(Node rootNode, int num)
        {
            while(rootNode.Next != null)
            {
                rootNode = rootNode.Next;
            }

            rootNode.Next = new Node(num);
        }
    }
}
