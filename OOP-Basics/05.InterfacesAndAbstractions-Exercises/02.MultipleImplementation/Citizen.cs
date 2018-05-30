﻿using System;
using System.Text;


public class Citizen : IPerson, IIdentifiable, IBirthable
{
    string name;
    int age;
    private string id;
    private string birthday;

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public string Birthdate
    {
        get { return this.birthday; }
        set { this.birthday = value; }
    }

    public Citizen(string name, int age, string id, string birthday)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthday;
    }

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
}

