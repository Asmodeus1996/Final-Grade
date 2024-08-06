using System;
using System.Collections.Generic;

namespace UniversityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var softwareDevelopmentUniversity = new University("Software Development University", new List<string>
            {
                "Math1", "Math2", "Electrotechnics1", "Electrotechnics2", "Algorithmics", "Object Oriented Programming",
                "Web Development", "English Language1", "English Language2", "Machine Learning", "Cyber Security", "Design(UI/UX)"
            });

            var medicineUniversity = new University("Medicine University", new List<string>
            {
                "Anatomy", "Medicine and Society", "English Language1", "English Language2", "Medicine and Physiology",
                "Microbiology", "Pathology", "Neurology", "Radiology"
            });

            var sociologyUniversity = new University("Sociological University", new List<string>
            {
                "General History", "Classical Theories", "English Language1", "French Language1", "German Language1",
                "English Language2", "French Language2", "German Language2", "Economy", "Sociology of Culture",
                "Studies of Globalization", "Sociology of Mental Sicknesses"
            });

            var universities = new List<University> { softwareDevelopmentUniversity, medicineUniversity, sociologyUniversity };

            Console.Write("Enter the student's name: ");
            string studentName = Console.ReadLine();

            Console.WriteLine("Select the university:");
            for (int i = 0; i < universities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {universities[i].Name}");
            }

            int universityChoice = int.Parse(Console.ReadLine()) - 1;
            University selectedUniversity = universities[universityChoice];

            var student = new Student(studentName, selectedUniversity);

            foreach (var course in selectedUniversity.Courses)
            {
                Console.WriteLine($"Enter 4 grades for {course}:");

                var grades = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        Console.Write($"Enter grade {i + 1} for {course}: ");
                        int grade = int.Parse(Console.ReadLine());
                        student.ValidateGrade(grade); // Validate grade
                        grades.Add(grade);
                    }
                    catch (InvalidGradeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        i--; // Retry current grade input
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                        i--; // Retry current grade input
                    }
                }
                student.Grades[course] = grades;
            }

            student.DisplayGrades();
        }
    }
}
