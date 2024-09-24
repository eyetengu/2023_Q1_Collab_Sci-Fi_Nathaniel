using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class LINQ_SchoolExample : MonoBehaviour
{
    [SerializeField] List<string> _students;
    [SerializeField] List<Teacher> _teachers;
    [SerializeField] List<Department> _departments;
    [SerializeField] List<(string, int)> _nameRank;
    [SerializeField] (string, int) newRank;

    private void Start()
    {
        Student newStudent = new Student("Bob", "Marley");
        _students.Add(newStudent.LastName);

        newRank = ("Bob", 3);
        _nameRank.Add(newRank);


        var query = _teachers.OrderBy(teacher => teacher.LastName).Select(teacher => teacher.LastName);
        foreach (var teacher in query)
            Debug.Log(teacher);
    }


}
    public enum GradeLevel { FirstYear = 1,
                                SecondYear,
                                ThirdYear,
                                FourthYear,
                                FifthYear   }

[System.Serializable]
public class Student
{
    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string FirstName { get; set; }
    public  string LastName { get; set; }
    public  int ID { get; set; }

    public GradeLevel Year { get; set; }
    public  List<int> Scores {  get; set; }
    public  int DepartmentID { get; set; }

}

[System.Serializable]
public class Teacher
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public string City { get; set; }
}

[System.Serializable]
public class Department
{
    public string Name { get; set; }
    public int ID { get; set; } 
    public int TeacherID { get; set; }
}