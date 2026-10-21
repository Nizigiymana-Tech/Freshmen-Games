using System;
using System.Linq;

// Create an Dictionary that is named "Students" which has
// - Name
// - Dictionary
// - - ClassName
// - - ClassGrade

// Example:
// - Terance
// - - Science
// - - Grade: 50
// - - English
// - - Grade: 90

class Helpers
{
    public static bool IsInvalid(string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
}

class GradeTracker
{
    public static Dictionary<string, Dictionary<string, double>> students = new Dictionary<string, Dictionary<string, double>>();

    public static (bool, string) AddStudent(string name, Dictionary<string, double> classes)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return (false, "The student name is empty.");
        }

        if (students.ContainsKey(name))
        {
            return (false, "Theres already a name inside the books.");
        }

        if (classes.Count == 0)
        {
            return (false, "No classes were added.");
        }

        students.Add(name, classes);
        return (true, "Succesfully saved.");
    }
}

class Program {

    // Should have the Dictionary of the Students
    // Asks the user if they want to remove or add a student or change their grade
    // if they want to add a student it would say

    // What is the students name?
    // Disclaimer: This will loop until you respond with Q to exit. Each loop will save

    // - START LOOP
    // What is the class name? 
    // What is the grade?

    // Dictionary add class name and double
    // - END LOOP

    // Finished!

    // If they wanted to remove a student
    // What is the students name? (They will be removed permanently when entered.)

    // Finished!

    // Change Grade

    // What is the students name?
    // What Class?
    // Put New Grade Here:

    // Finished!
    static void Main()
    {
        string[] options = ["Add", "Remove", "Change", "Show", "Q"];

        while (true)
        {
            Console.WriteLine("This is the Student Grade Tracker.");
            Console.WriteLine("---- Options ----");
            Console.WriteLine("1. Add Student (Add)");
            Console.WriteLine("2. Remove Student (Remove)");
            Console.WriteLine("3. Change Student Grade (Change)");
            Console.WriteLine("4. Show Student Grades. (Show)");
            Console.WriteLine("5. Leave (Q)");

            Console.Write("");
            string option = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(option))
            {
                Console.WriteLine("Not a valid response.");
                Thread.Sleep(2000);
                continue;
            }

            if (!options.Contains(option))
            {
                Console.WriteLine("Isn't a valid option.");
                Thread.Sleep(2000);
                continue;
            }

            if (option == "Q")
            {
                Console.WriteLine("Thank you for opening.");
                Thread.Sleep(1000);
                break;
            }

            // Add
            if (option == "Add")
            {
                Dictionary<string, double> classDict = new Dictionary<string, double>();
                Console.WriteLine("Disclaimer: This will loop until you respond with Q (studentName) to exit. Each loop will save");
                Console.WriteLine("What is the student's name?");
                Console.Write("");

                string studentName = Console.ReadLine()!;

                if (Helpers.IsInvalid(studentName))
                {
                    Console.WriteLine("Name cannot be Null or Empty.");
                    Thread.Sleep(1000);
                    continue;
                }

                while (true)
                {
                    Console.WriteLine("What is the Class Name?");
                    Console.Write("");
                    string className = Console.ReadLine()!;

                    if (Helpers.IsInvalid(className))
                    {
                        Console.WriteLine("Name cannot be Null or Empty.");
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (className == "Q")
                    {
                        Console.WriteLine("Saving and closing...");
                        Thread.Sleep(1000);
                        break;
                    }

                    Console.WriteLine("What is the Class Grade?");
                    string classGrade = Console.ReadLine()!;

                    if (Helpers.IsInvalid(classGrade))
                    {
                        Console.WriteLine("Grade cannot be Null or Empty.");
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (double.TryParse(classGrade, out double grade))
                    {
                        // (bool, string) = GradeTracker.AddStudent(studentName, classDict);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a whole number.");
                        continue;
                    }
                }
            }
        }
    }
}