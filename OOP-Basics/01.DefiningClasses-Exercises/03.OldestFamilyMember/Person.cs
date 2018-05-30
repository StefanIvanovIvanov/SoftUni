using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Person()
    {
        this.Age = 1;
        this.Name = "No name";
    }

    public Person(int age) : this()
    {
        this.Age = age;
    }

    public Person(int age, string name) : this(age)
    {
        this.Age = age;
        this.Name = name;
    }

}

