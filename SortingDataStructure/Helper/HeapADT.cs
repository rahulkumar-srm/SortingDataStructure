using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingDataStructure.Helper
{
    internal class HeapADT
    {
        internal int top = 0;
        internal int[] item { get; set; }

        public HeapADT(int size)
        {
            item = new int[size];
        }

        internal void CreateHeap()
        {
            while (true)
            {
                Console.WriteLine("Enter the number");
                int num = Convert.ToInt32(Console.ReadLine());

                if (num == -1)
                {
                    break;
                }

                InsertNode(num);
            }
        }

        internal void InsertNode(int num)
        {
            item[++top] = num;
            int i = top;

            while (i > 1 && num > item[i / 2])
            {
                item[i] = item[i / 2];
                i = i / 2;
            }

            item[i] = num;
        }

        internal void RInOrderTraversal(int index)
        {
            if (index <= top)
            {
                RInOrderTraversal(2 * index);
                Console.Write(item[index] + " ");
                RInOrderTraversal((2 * index) + 1);
            }
        }

        internal void DeleteFromHeap()
        {
            int tempData = item[1];
            item[1] = item[top];
            item[top--] = tempData;

            int i = 1;
            int j = 2 * i;

            while (j < top)
            {
                if (item[j + 1] > item[j])
                {
                    j = j + 1;
                }
                if (item[j] > item[i])
                {
                    tempData = item[i];
                    item[i] = item[j];
                    item[j] = tempData;

                    i = j;
                    j = 2 * j;
                }
                else
                    break;
            }
        }
    }
}
