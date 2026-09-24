using System;
using System.IO;
using System.Windows.Forms;
using static StudentProfile.Student;

namespace StudentProfile
{
    public partial class CourseRegistrationForm : Form
    {
        private StudentManager manager = new StudentManager();

        public CourseRegistrationForm()
        {
            InitializeComponent();
        }

        private void CourseRegistrationForm_Load(object sender, EventArgs e)
        {
            PopulateStudentComboBox();
        }

        private void PopulateStudentComboBox()
        {
            cmbStudents.Items.Clear();
            foreach (Student s in manager.StudentList)
            {
                cmbStudents.Items.Add(s.FullName);
            }
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbStudents.SelectedIndex;
            if (index < 0) return;

            Student selectedStudent = (Student)manager.StudentList[index];
            ShowStudentInfoMessageBox(selectedStudent);
        }

        private void DownloadCOR(Student student)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Certificate of Registration";
                saveFileDialog.FileName = "COR_" + student.StudentId + ".txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string corData = student.GenerateCOR();
                    File.WriteAllText(saveFileDialog.FileName, corData);

                    MessageBox.Show(
                        "Certificate of Registration (COR) successfully saved!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private void ShowStudentInfoMessageBox(Student student)
        {
            string message = "=== STUDENT ENROLLMENT PROFILE ===\n\n";
            message += "ID: " + student.StudentId + "\n";
            message += "Name: " + student.FullName + "\n";
            message += "Major: " + student.Major + "\n";
            message += "STATUS: " + student.Status.ToUpper() + "\n";
            message += "--------------------------------------------------\n";
            message += "ENROLLED SUBJECTS:\n";

            if (student.EnrolledCourses.Count == 0)
            {
                message += "No enrolled subjects for this semester.\n";
            }
            else
            {
                foreach (string subject in student.EnrolledCourses)
                {
                    message += "• " + subject + "\n";
                }
            }

            message += "--------------------------------------------------\n";
            message += "Would you like to download/save the official COR file?";

            DialogResult result = MessageBox.Show(
                message,
                "Student Found - Information Profile",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                DownloadCOR(student);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            // Validate empty input
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show(
                    "Please enter a Student ID or Name to search.",
                    "Input Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Student foundStudent = null;

            // Search through the ArrayList by ID or Name (case-insensitive)
            foreach (Student s in manager.StudentList)
            {
                if (s.StudentId.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    s.FullName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    foundStudent = s;
                    break; // Stop at first match
                }
            }

            // AC3 & AC4: Display result or no-result message
            if (foundStudent != null)
            {
                // Optional: Sync ComboBox selection with the searched student
                cmbStudents.SelectedItem = foundStudent.FullName;

                // Display Student Info and Subject Breakdown
                ShowStudentInfoMessageBox(foundStudent);
            }
            else
            {
                // Display no-result message
                MessageBox.Show(
                    "No student found with ID or Name matching: \"" + searchTerm + "\"",
                    "Search Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}