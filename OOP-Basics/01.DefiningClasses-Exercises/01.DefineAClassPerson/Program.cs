﻿using System;

namespace _01.DefineAClassPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pesho = new Person();
            pesho.Name = "Pesho";
            pesho.Age = 20;

            Person gosho = new Person();
            gosho.Name = "Gosho";
            gosho.Age = 18;

            Person stamat = new Person();
            stamat.Name = "Stamat";
            stamat.Age = 43;
        }
    }
}
