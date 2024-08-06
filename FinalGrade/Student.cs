using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityApp
{
    public class InvalidGradeException : Exception
    {
        public InvalidGradeException(string message) : base(message) { }
    }

    public class Student
    {
        public string Name { get; set; }
        public University University { get; set; }
        public Dictionary<string, List<int>> Grades { get; set; }

        public Student(string name, University university)
        {
            Name = name;
            University = university;
            Grades = new Dictionary<string, List<int>>();
        }

        public void ValidateGrade(int grade)
        {
            if (grade < 1 || grade > 5)
            {
                throw new InvalidGradeException($"Grade {grade} is not in the correct range (1-5).");
            }
        }

        public double CalculateAverageGrade(IEnumerable<int> grades)
        {
            return grades.Average();
        }

        public string GetFinalMark(double averageGrade)
        {
            if (averageGrade < 1)
                return "Insufficient";
            else if (averageGrade >= 1 && averageGrade < 2)
                return "Sufficient";
            else if (averageGrade >= 2 && averageGrade < 3)
                return "Good";
            else if (averageGrade >= 3 && averageGrade < 4)
                return "Very Good";
            else if (averageGrade >= 4 && averageGrade <= 5)
                return "Excellent";
            else
                return "Unknown";
        }

        public void DisplayGrades()
        {
            Console.WriteLine($"Grades for {Name}:");

            double totalSum = 0;
            int totalGradesCount = 0;
            bool hasInsufficient = false;
            bool stopProcessing = false;

            foreach (var course in Grades)
            {
                var courseName = course.Key;
                var courseGrades = course.Value;

                if (courseGrades.Count != 4)
                {
                    Console.WriteLine($"Error: The number of grades for {courseName} should be exactly 4.");
                    return;
                }

                double courseAverage = CalculateAverageGrade(courseGrades);

                if (courseAverage == 1)
                {
                    Console.WriteLine($"Average grade for {courseName} is 1. Grand Average Grade: 1. Grand Final Mark: Insufficient.");
                    stopProcessing = true;
                    break;
                }

                string courseMark = GetFinalMark(courseAverage);
                if (courseMark == "Insufficient")
                {
                    hasInsufficient = true;
                }

                Console.WriteLine($"{courseName}: {string.Join(", ", courseGrades)} - Average: {courseAverage:F2} ({courseMark})");

                totalSum += courseGrades.Sum();
                totalGradesCount += courseGrades.Count;
            }

            if (!stopProcessing)
            {
                double grandAverage = totalSum / totalGradesCount;
                string grandFinalMark = hasInsufficient ? "Insufficient" : GetFinalMark(grandAverage);

                Console.WriteLine($"Grand Average Grade: {grandAverage:F2}");
                Console.WriteLine($"Grand Final Mark: {grandFinalMark}");
                Console.WriteLine(Passes() ? "The student passes the grade." : "The student fails the grade.");
            }
        }

        public bool Passes()
        {
            return Grades.Values.All(grades => grades.Average() >= 1);
        }
    }

    public class University
    {
        public string Name { get; set; }
        public List<string> Courses { get; set; }

        public University(string name, List<string> courses)
        {
            Name = name;
            Courses = courses;
        }
    }
}
