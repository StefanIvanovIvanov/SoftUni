﻿using System;
using System.Collections.Generic;
using System.Dynamic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.repo = new Dictionary<string, Student>();
    }

    public void ParseCommand(string command, Action<string> printFunction)
    {
        string[] args = command.Split();

        if (args[0] == "Create")
        {
            Create(args[1], args[2], args[3]);
        }
        else if (args[0] == "Show")
        {
            var studentName = args[1];
            if (repo.ContainsKey(studentName))
            {
                printFunction(repo[studentName].ToString());
            }
        }
    }

    private void Create(string name, string ageString, string gradeString)
    {

        int age = int.Parse(ageString);
        double grade = double.Parse(gradeString);
        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            repo[name] = student;
        }
    }
}