using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

abstract public class Course
{
    public abstract long CourseID { get; }
    public abstract string CourselName { get; }
    public abstract uint CoursePrice { get; }
}

public class ProgrammingCourse : Course
{
    public override long CourseID => 1;
    public override string CourselName { get { return "ProgrammingCourse"; } }

    public override uint CoursePrice => 30;
}

public class MathematicsCourse : Course
{
    public override long CourseID => 2;
    public override string CourselName { get { return "MathematicsCourse"; } }
    public override uint CoursePrice => 30;

}

public class EconomicsCourse : Course
{
    public override long CourseID => 3;
    public override string CourselName { get { return "EconomicsCourse"; } }
    public override uint CoursePrice => 30;

}

public class User
{    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    private int money;
    public List<Course> listCourses = new List<Course>();

    public User(string firstName, string lastName, int money = 30)
    {
        this.FirstName = firstName;
        this.LastName = LastName;
        this.money = money;
    }
    

    public bool order(List<Course> courses)
    {
        if (courses != null)
        {
            while (courses.Count > 1)
            {
                long TotalPrice = courses.Sum(p => p.CoursePrice);
                if (TotalPrice > money)
                {
                    Course course = courses[0];
                    listCourses.Add(course);
                    courses.Remove(course);
                }
            }

        }
        return listCourses.Count > 1 ? true : false;
    }
}
class Program
{
    static string Main(string[] args)
    {

        string[,] userInformation = { { "Jack", "Harris", "25" }, { "Ryan", "Thomas", "50" }, { "Emily", "Young" } };
        string[,] courses = { { "0", "Programming", "Economics" }, { "2", "Economics" } };

        onlineCoursesWebsite(userInformation, courses);

    }
    static bool[] onlineCoursesWebsite(string[][] userInformation, string[][] orders)
    {
        User[] users = new User[userInformation.Length];
        bool[] result = new bool[orders.Length];
        for (int i = 0; i < userInformation.Length; ++i)
        {
            if (userInformation[i].Length == 3)
                users[i] = new User(userInformation[i][0], userInformation[i][1], int.Parse(userInformation[i][2]));
            else
                users[i] = new User(userInformation[i][0], userInformation[i][1]);
        }
        for (int i = 0; i < orders.Length; ++i)
        {
            List<Course> courses = new List<Course>();
            for (int j = 1; j < orders[i].Length; ++j)
            {
                if (orders[i][j] == "Programming")
                    courses.Add(new ProgrammingCourse());
                if (orders[i][j] == "Mathematics")
                    courses.Add(new MathematicsCourse());
                if (orders[i][j] == "Economics")
                    courses.Add(new EconomicsCourse());
            }
            result[i] = users[int.Parse(orders[i][0])].order(courses);
        }
        return result;
    }
}
