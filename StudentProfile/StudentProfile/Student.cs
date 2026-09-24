using System;
using System.Collections;

namespace StudentProfile
{
    public class Student
    {
        // Basic Student Info
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Major { get; set; }
        public string Status { get; set; }

        // Course Tracking
        public ArrayList CompletedCourses { get; set; }
        public ArrayList EnrolledCourses { get; set; }

        // Cashier & Billing Properties
        public double TuitionRatePerUnit { get; set; } = 500.00; // P500 per unit
        public double MiscFees { get; set; } = 2500.00;          // Fixed misc fees
        public double TotalAmountPaid { get; set; }
        public ArrayList PaymentHistory { get; set; }

        public Student(string id, string name, string major, string status)
        {
            StudentId = id;
            FullName = name;
            Major = major;
            Status = status;
            CompletedCourses = new ArrayList();
            EnrolledCourses = new ArrayList();
            PaymentHistory = new ArrayList();
            TotalAmountPaid = 0;
        }

        // Assumes 3 units per enrolled subject
        public int TotalUnits => EnrolledCourses.Count * 3;

        // Financial Calculations
        public double TotalTuitionFee => TotalUnits * TuitionRatePerUnit;
        public double TotalAssessedFees => TotalTuitionFee + MiscFees;
        public double RemainingBalance => TotalAssessedFees - TotalAmountPaid;

        // Record a new payment
        public void AddPayment(double amount, string receiptNo)
        {
            TotalAmountPaid += amount;
            string record = DateTime.Now.ToString("yyyy-MM-dd HH:mm") +
                            " | OR #" + receiptNo +
                            " | Paid: P" + amount.ToString("N2") +
                            " | Bal: P" + RemainingBalance.ToString("N2");
            PaymentHistory.Add(record);
        }

        // Helper to check if search query matches ID or Name
        public bool MatchesSearch(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return false;
            return StudentId.Equals(query, StringComparison.OrdinalIgnoreCase) ||
                   FullName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        // Generate Digital Receipt text file format
        public string GenerateReceipt(double paidAmount, string receiptNo)
        {
            string receipt = "====================================================\n";
            receipt += "              OFFICIAL DIGITAL RECEIPT              \n";
            receipt += "====================================================\n";
            receipt += "OR Number:   " + receiptNo + "\n";
            receipt += "Date:        " + DateTime.Now.ToString("f") + "\n";
            receipt += "Student ID:  " + StudentId + "\n";
            receipt += "Name:        " + FullName + "\n";
            receipt += "Major:       " + Major + "\n";
            receipt += "----------------------------------------------------\n";
            receipt += "ASSESSED FEES BREAKDOWN:\n";
            receipt += "  Tuition Fee (" + TotalUnits + " units @ P" + TuitionRatePerUnit + "): P" + TotalTuitionFee.ToString("N2") + "\n";
            receipt += "  Miscellaneous Fees:                      P" + MiscFees.ToString("N2") + "\n";
            receipt += "  Total Assessed Amount:                  P" + TotalAssessedFees.ToString("N2") + "\n";
            receipt += "----------------------------------------------------\n";
            receipt += "TRANSACTION DETAILS:\n";
            receipt += "  Amount Paid This Transaction:            P" + paidAmount.ToString("N2") + "\n";
            receipt += "  Total Amount Paid To Date:               P" + TotalAmountPaid.ToString("N2") + "\n";
            receipt += "  Remaining Balance:                       P" + RemainingBalance.ToString("N2") + "\n";
            receipt += "====================================================\n";
            return receipt;
        }

        // Certificate of Registration Generator
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
            // Student 1 - Partial Payment (Has 2 enrolled subjects)
            Student s1 = new Student("101", "Alex Mercer", "Computer Science", "Enrolled");
            s1.CompletedCourses.Add("CS101");
            s1.CompletedCourses.Add("MATH101");
            s1.EnrolledCourses.Add("CS102 - Data Structures (3 Units)");
            s1.EnrolledCourses.Add("MATH102 - Calculus II (3 Units)");
            s1.AddPayment(2000.00, "OR-1001"); // Initial downpayment

            // Student 2 - Unpaid (Has 1 enrolled subject)
            Student s2 = new Student("102", "Beatrix Kiddo", "Information Technology", "Pending");
            s2.EnrolledCourses.Add("IT101 - Intro to IT (3 Units)");

            // Student 3 - Cleared / Fully Paid (Has 2 enrolled subjects)
            Student s3 = new Student("103", "Charles Xavier", "Computer Science", "Cleared");
            s3.CompletedCourses.Add("CS101");
            s3.CompletedCourses.Add("CS102");
            s3.EnrolledCourses.Add("CS201 - OOP Concepts (3 Units)");
            s3.EnrolledCourses.Add("CS202 - Database Systems (3 Units)");
            s3.AddPayment(5500.00, "OR-1000"); // Paid in full (6 units * 500 + 2500 misc = 5500)

            // Student 4 - Partial Payment (Has 1 enrolled subject)
            Student s4 = new Student("104", "Diana Prince", "Software Engineering", "Enrolled");
            s4.CompletedCourses.Add("CS101");
            s4.EnrolledCourses.Add("SE101 - Software Engineering I (3 Units)");
            s4.AddPayment(1500.00, "OR-1002");

            // Student 5 - Unpaid (Has 1 enrolled subject)
            Student s5 = new Student("105", "Ethan Hunt", "Information Technology", "Pending");
            s5.CompletedCourses.Add("IT101");
            s5.EnrolledCourses.Add("IT102 - Web Development (3 Units)");

            // Add all 5 students into the main ArrayList
            StudentList.Add(s1);
            StudentList.Add(s2);
            StudentList.Add(s3);
            StudentList.Add(s4);
            StudentList.Add(s5);
        }
    }
}