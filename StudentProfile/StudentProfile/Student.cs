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

        // Enrollment Status ("Pending", "Enrolled", "Cleared")
        public string Status { get; set; }

        // ArrayLists for course tracking
        public ArrayList CompletedCourses { get; set; }
        public ArrayList EnrolledCourses { get; set; }

        // Constructor
        public Student(string id, string name, string major, string status)
        {
            StudentId = id;
            FullName = name;
            Major = major;
            Status = status;
            CompletedCourses = new ArrayList();
            EnrolledCourses = new ArrayList();
        }

        // Method to generate Certificate of Registration (COR) text content
        public string GenerateCOR()
        {
            string corContent = "====================================================\n";
            corContent += "          OFFICIAL CERTIFICATE OF REGISTRATION      \n";
            corContent += "====================================================\n";
            corContent += "Student ID: " + StudentId + "\n";
            corContent += "Name:       " + FullName + "\n";
            corContent += "Major:      " + Major + "\n";
            corContent += "Status:     " + Status + "\n";
            corContent += "----------------------------------------------------\n";
            corContent += "ENROLLED SUBJECTS BREAKDOWN:\n";
            corContent += "----------------------------------------------------\n";

            if (EnrolledCourses.Count == 0)
            {
                corContent += "No subjects enrolled for this semester.\n";
            }
            else
            {
                foreach (string subject in EnrolledCourses)
                {
                    corContent += "- " + subject + "\n";
                }
            }

            corContent += "----------------------------------------------------\n";
            corContent += "Date Generated: " + DateTime.Now.ToShortDateString() + "\n";
            corContent += "====================================================\n";

            return corContent;
        }
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
            // Student 1 - Enrolled
            Student s1 = new Student("101", "Alex Mercer", "Computer Science", "Enrolled");
            s1.CompletedCourses.Add("CS101");
            s1.CompletedCourses.Add("MATH101");
            s1.EnrolledCourses.Add("CS102 - Data Structures (3 Units) | MWF 09:00 AM - 10:00 AM");
            s1.EnrolledCourses.Add("MATH102 - Calculus II (3 Units) | TTH 01:00 PM - 02:30 PM");

            // Student 2 - Pending
            Student s2 = new Student("102", "Beatrix Kiddo", "Information Technology", "Pending");
            s2.EnrolledCourses.Add("IT101 - Intro to IT (3 Units) | MWF 10:00 AM - 11:00 AM");

            // Student 3 - Cleared
            Student s3 = new Student("103", "Charles Xavier", "Computer Science", "Cleared");
            s3.CompletedCourses.Add("CS101");
            s3.CompletedCourses.Add("CS102");
            s3.EnrolledCourses.Add("CS201 - OOP Concepts (3 Units) | MWF 01:00 PM - 02:00 PM");
            s3.EnrolledCourses.Add("CS202 - Database Systems (3 Units) | TTH 10:30 AM - 12:00 PM");

            // Student 4 - Enrolled
            Student s4 = new Student("104", "Diana Prince", "Software Engineering", "Enrolled");
            s4.CompletedCourses.Add("CS101");
            s4.EnrolledCourses.Add("SE101 - Software Engineering I (3 Units) | TTH 08:00 AM - 09:30 AM");

            // Student 5 - Pending
            Student s5 = new Student("105", "Ethan Hunt", "Information Technology", "Pending");
            s5.CompletedCourses.Add("IT101");
            s5.EnrolledCourses.Add("IT102 - Web Development (3 Units) | MWF 02:00 PM - 03:00 PM");

            // Add all 5 students into the main ArrayList
            StudentList.Add(s1);
            StudentList.Add(s2);
            StudentList.Add(s3);
            StudentList.Add(s4);
            StudentList.Add(s5);
        }
    }
}
