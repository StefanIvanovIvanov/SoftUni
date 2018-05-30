using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Database
{
    public class Database
    {
        private const int MAX_CAPACITY = 16;
        private int currentIndex=0;
        int[] array;

        public Database()
        {
            this.array = new int[MAX_CAPACITY];
            this.currentIndex = 0;
        }


        public Database(params int[] inputNumbers)
            :this()
        {       
            this.InititializeValues(inputNumbers);

            //for (int i = 0; i < inputNumbers.Length; i++)
            //{
            //    this.array[i] = inputNumbers[i];
            //    this.currentIndex++;
            //}

        }

        private void InititializeValues(int[] inputNumbers)
        {
            try
            {
                //inputNumbers = inputNumbers.Concat(inputNumbers).ToArray();
                Array.Copy(inputNumbers, this.array, inputNumbers.Length);
                this.currentIndex = inputNumbers.Length;
            }
            catch (ArgumentException e)
            {
                throw new InvalidOperationException("Array is full!", e);
            }
          
        }

        public void Add(int element)
        {
            if (this.currentIndex >= MAX_CAPACITY)
            {
                throw  new InvalidOperationException("Array is full!");
            }

            this.array[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty!");
            }

            this.currentIndex--;
            this.array[currentIndex] = default(int);
        }

        public int[] Fetch()
        {
            int[]newArray=new int[this.currentIndex];
           Array.Copy(this.array, newArray, this.currentIndex);
            return newArray;
        }
    }
}
