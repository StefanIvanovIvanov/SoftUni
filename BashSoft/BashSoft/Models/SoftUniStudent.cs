﻿using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft.Models
{
    public class SoftUniStudent : IStudent
    {
        private Dictionary<string, ICourse> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;
        private string userName;

        public SoftUniStudent(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses
        {
            get
            {
                return this.enrolledCourses;
            }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get
            {
                return this.marksByCourseName;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.userName = value;
            }
        }

        public int CompareTo(IStudent other)
        {
            return this.UserName.CompareTo(other.UserName);
        }

        public void EntrollInCourse(ICourse course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, this.CalculateMark(scores));
        }

        public override string ToString()
        {
            return this.UserName;
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() / (double)(SoftUniCourse.NumberOfTasksOnExam * SoftUniCourse.MaxScoreOnExamTasks);
            double mark = (percentageOfSolvedExam * 4) + 2;
            return mark;
        }
    }
}