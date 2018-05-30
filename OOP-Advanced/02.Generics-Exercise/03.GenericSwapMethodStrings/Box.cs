using System;
using System.Collections.Generic;
using System.Text;


   public class Box<T>
   {
       public readonly List<string> list;

       public Box(IEnumerable<string> list)
       {
           this.list = new List<string>(list);
       }

       public void Swap(int firstIndex, int secondIndex)
       {
           string remember = this.list[firstIndex];
           this.list[firstIndex] = this.list[secondIndex];
           this.list[secondIndex] = remember;
       }
   }

