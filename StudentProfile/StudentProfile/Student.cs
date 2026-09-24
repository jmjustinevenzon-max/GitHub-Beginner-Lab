using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StudentProfile
{
    internal class Student
    {// Basic Get/Set Properties
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Major { get; set; }

        // Using ArrayList to store completed course codes (e.g., "CS101", "MATH101")
        public ArrayList CompletedCourses { get; set; }

        // Using ArrayList to store currently enrolled courses for the semester
        public ArrayList EnrolledCourses { get; set; }

        // Constructor initializing the ArrayLists
        public Student(string id, string name, string major)
        {
            StudentId = id;
            FullName = name;
            Major = major;
            CompletedCourses = new ArrayList();
            EnrolledCourses = new ArrayList();
        }


        public class StudentManager
        {
            public ArrayList StudentList { get; set; }

            public StudentManager()
            {
                StudentList = new ArrayList();
                LoadStudents();
            }

            private void LoadStudents()
            {
                // Student 1
                Student s1 = new Student("101", "Alex Mercer", "Computer Science");
                s1.CompletedCourses.Add("CS101");
                s1.CompletedCourses.Add("MATH101");

                // Student 2
                Student s2 = new Student("102", "Beatrix Kiddo", "Information Technology");

                // Student 3
                Student s3 = new Student("103", "Charles Xavier", "Computer Science");
                s3.CompletedCourses.Add("CS101");
                s3.CompletedCourses.Add("CS102");

                // Student 4
                Student s4 = new Student("104", "Diana Prince", "Software Engineering");
                s4.CompletedCourses.Add("CS101");

                // Student 5
                Student s5 = new Student("105", "Ethan Hunt", "Information Technology");
                s5.CompletedCourses.Add("IT101");

                StudentList.Add(s1);
                StudentList.Add(s2);
                StudentList.Add(s3);
                StudentList.Add(s4);
                StudentList.Add(s5);
            }
        }
    }
}
