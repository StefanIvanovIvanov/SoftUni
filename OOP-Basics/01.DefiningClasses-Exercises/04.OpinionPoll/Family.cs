using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;


public class Family
{
    private List<Person> people = new List<Person>();

    public List<Person> People
    {
        get { return this.people; }
        set { this.people = value; }
    }

    public void AddMember(Person person)
    {
        this.people.Add(person);
    }

    public List<Person> FilterAge(List<Person> people)
    {
        return people.Where(x => x.Age > 30).ToList();
    }

}

