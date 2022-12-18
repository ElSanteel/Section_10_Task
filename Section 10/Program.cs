using System;
namespace program;
public class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        if (name == null || name == "" || name.Length >= 32)
        {
            // throw new Exception();
            Console.WriteLine("Invalid name");
            return;
        }
        if (age <= 0 || age > 128)
        {
            Console.WriteLine("Invalid Age");
            return;
        }
        Name = name;
        Age = age;
    }
    public virtual void Print()
    {
        System.Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}
//--------------------------------------------------------
public class Student : Person
{
    public int Year;
    public float GPA;
    public Student(string name, int age, int year, float gpa) : base(name, age)
    {
        if (year < 1 || year > 5)
        {
            Console.WriteLine("Invalid Year");
            return;
        }
        if (gpa < 0 || gpa > 4)
        {
            Console.WriteLine("Invalid Gpa");
            return;
        }
        Year = year;
        GPA = gpa;
    }
    public override void Print()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Gpa: {GPA}");
    }
}
// --------------------------------------------------------
public class Staff : Person
{
    public double Salary;
    public int JoinYear;

    public Staff(string name, int age, double salary, int joinyear) : base(name, age)
    {
        var year_of_the_day = DateTime.Today;
        var actual_birthYear = year_of_the_day.Year - age;
        if (salary <= 0 || salary >= 120000)
        {
            Console.WriteLine("Invalid Salary");
            return;
        }
        if ((joinyear - actual_birthYear) < 21)
        {
            Console.WriteLine("Invalid JoinYear");
            return;
        }
        Salary = salary;
        JoinYear = joinyear;
    }

    public override void Print()
    {
        Console.WriteLine($"My name is {Name}, my age is {Age}, and my salary is {Salary}");
    }
}
// --------------------------------------------------------
public class Database
{
    private int _currIndex;
    public Person[] People = new Person[50];
    public void AddStudent(Student student)
    {
        People[_currIndex++] = student;
    }
    public void AddStaff(Staff staff)
    {
        People[_currIndex++] = staff;
    }
    public void AddPerson(Person person)
    {
        People[_currIndex++] = person;
    }
    public void PrintAll()
    {
        foreach (var item in People)
        {
            item?.Print();
        }

    }
}
public class Program
{
    public static void Main()
    {
        var database = new Database();
        while (true)
        {
            Console.WriteLine("Choose one of the following: (1) Student (2) Staff (3) Person (4) Print ALL");
            var op = Convert.ToInt32(Console.ReadLine());
            if (op == 1)
            {
                Console.Write("Name: ");
                var name = Console.ReadLine();
                Console.Write("Age: ");
                var age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Year: ");
                var year = Convert.ToInt32(Console.ReadLine());
                Console.Write("gpa: ");
                var gpa = Convert.ToSingle(Console.ReadLine());
                var student = new Student(name, age, year, gpa);
                database.AddStudent(student);
            }
            else if (op == 2)
            {
                Console.Write("Name: ");
                var name_2 = Console.ReadLine();
                Console.Write("Age: ");
                var age_2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Salary: ");
                var salary = Convert.ToDouble(Console.ReadLine());
                Console.Write("JoinYear: ");
                var joinYear = Convert.ToInt32(Console.ReadLine());
                var staff = new Staff(name_2, age_2, salary, joinYear);
                database.AddStaff(staff);
            }
            else if (op == 3)
            {
                Console.Write("Name: ");
                var name_3 = Console.ReadLine();
                Console.Write("Age: ");
                var age_3 = Convert.ToInt32(Console.ReadLine());
                var person = new Person(name_3, age_3);
                database.AddPerson(person);
            }
            else if (op == 4)
            {
                database.PrintAll();
            }
            else
            {
                return;
            }
        }
    }
}
