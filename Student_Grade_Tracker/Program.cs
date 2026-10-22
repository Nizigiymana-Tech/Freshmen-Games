using System;
using System.Linq;
using System.Threading;

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

    public static (bool, string) RegisterStudent(string name)
    {
        if (Helpers.IsInvalid(name))
        {
            return (false, "The student name is empty.");
        }

        if (students.ContainsKey(name))
        {
            return (false, "Theres already a name inside the books.");
        }

        students.Add(name, new Dictionary<string, double>());
        return (true, "Succesfully saved.");
    }

    public static (bool, string) RegisterClasses(string name, Dictionary<string, double> classes)
    {
        if (Helpers.IsInvalid(name))
        {
            return (false, "The student name is empty.");
        }

        if (!students.ContainsKey(name))
        {
            return (false, "Student doesn't exist.");
        }

        students[name] = classes;
        return (true, "Successfully enrolled.");
    }

    public static (bool, string) UnenrollStudent(string name)
    {
        if (Helpers.IsInvalid(name))
        {
            return (false, "The student name is empty.");
        }

        if (!students.ContainsKey(name))
        {
            return (false, "Student isn't in the system.");
        }

        students.Remove(name);
        return (true, "Succesfully Deleted.");
    }

    public static (bool, string) ShowStudentInfo(string name)
    {
        if (Helpers.IsInvalid(name))
        {
            return (false, "The student name is empty.");
        }

        if (!students.ContainsKey(name))
        {
            return (false, "Student isn't in the system.");
        }

        var classDict = students[name];

        foreach (var (key, value) in classDict)
        {
            Console.WriteLine($"- {key}: {value}");
        }

        return (true, "Succesfully shown.");
    }

    public static (bool, string) ModifyStudentData(string name, string Type)
    {
        if (Helpers.IsInvalid(name))
        {
            return (false, "The student name is empty.");
        }

        if (!students.ContainsKey(name))
        {
            return (false, "Student isn't in the system.");
        }

        var classDict = students[name];

    }
}

class OptionFunctions
{
    // ----------------------------------- \\
    public static void Add()
    {
        Dictionary<string, double> classDict = new Dictionary<string, double>();
        Console.WriteLine("What is the student's name?");
        Console.Write("");

        string studentName = Console.ReadLine()!;

        if (Helpers.IsInvalid(studentName))
        {
            Console.WriteLine("Name cannot be Null or Empty.");
            Thread.Sleep(1000);
            return;
        }

        (bool Success, string Text) = GradeTracker.RegisterStudent(studentName);

        if (!Success)
        {
            Console.WriteLine(Text);
            Thread.Sleep(1000);
            return;
        }

        while (true)
        {
            Console.WriteLine("What is the Class Name? (Type 'Q' To Exit.)");
            Console.Write("");
            string className = Console.ReadLine()!;

            if (Helpers.IsInvalid(className))
            {
                Console.WriteLine("Name cannot be Null or Empty.");
                Thread.Sleep(1000);
                continue;
            }

            if (classDict.ContainsKey(className))
            {
                Console.WriteLine("This class already exists.");
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

            if (double.TryParse(classGrade, out double grade) && grade >= 0 && grade <= 100)
            {
                classDict.Add(className, grade);
            }
            else
            {
                Console.WriteLine("Enter a grade between 0 and 100.");
                continue;
            }
        }

        GradeTracker.RegisterClasses(studentName, classDict);
    }
    // ------------------------------------------------------- \\

    public static void Remove()
    {
        Console.WriteLine("What is the student's name? (Note: Student will be completely deleted.)");
        Console.Write("");

        string studentName = Console.ReadLine()!;

        if (Helpers.IsInvalid(studentName))
        {
            Console.WriteLine("Name cannot be Null or Empty.");
            Thread.Sleep(1000);
            return;
        }

        (bool success, string text) = GradeTracker.UnenrollStudent(studentName);

        if (!success)
        {
            Console.WriteLine(text);
            Thread.Sleep(1000);
            return;
        }

        Console.WriteLine($"{studentName} has been removed.");
        Thread.Sleep(1000);
    }

    // ------------------------------------------------------- \\

    public static void Show()
    {
        Console.WriteLine("What is the student's name? (Note: Student will be completely deleted.)");
        Console.Write("");

        string studentName = Console.ReadLine()!;

        if (Helpers.IsInvalid(studentName))
        {
            Console.WriteLine("Name cannot be Null or Empty.");
            Thread.Sleep(1000);
            return;
        }   

        (bool success, string text) = GradeTracker.ShowStudentInfo(studentName);

        if (!success)
        {
            Console.WriteLine(text);
            Thread.Sleep(1000);
            return;
        }

        Console.Write("Press enter to exit: ");
        Console.ReadLine();
    }

    public static void Change()
    {
        Console.WriteLine("What is the student's name? ");
        Console.Write("");

        string studentName = Console.ReadLine()!;

        if (Helpers.IsInvalid(studentName))
        {
            Console.WriteLine("Name cannot be Null or Empty.");
            Thread.Sleep(1000);
            return;
        }  

        Console.WriteLine("Do you want to add or remove a grade? (Use Add or Remove)");
        Console.Write("");

        string type = Console.ReadLine()!;

        if (Helpers.IsInvalid(type))
        {
            Console.WriteLine("Type cannot be Null or Empty.");
            Thread.Sleep(1000);
            return;
        }         

        (bool success, string text) = GradeTracker.ShowStudentInfo(studentName, type);
        
    }
}

class Program
{

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
        string[] options = ["add", "remove", "change", "show", "q"];

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
            string option = Console.ReadLine()!.Trim().ToLower();

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
            if (option == options[0])
            {
                OptionFunctions.Add();
            }

            // Remove
            if (option == options[1])
            {
                OptionFunctions.Remove();
            }

            // Change
            if (option == options[2])
            {
                OptionFunctions.Change();
            }

            // Show
            if (option == options[3])
            {
                OptionFunctions.Show();
            }
        }
    }
}