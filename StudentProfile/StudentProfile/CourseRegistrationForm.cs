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
            // Populate ComboBox with student names on load
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

            // 1. Build the status and subject breakdown message for MessageBox
            string message = "=== STUDENT ENROLLMENT PROFILE ===\n\n";
            message += "ID: " + selectedStudent.StudentId + "\n";
            message += "Name: " + selectedStudent.FullName + "\n";
            message += "Major: " + selectedStudent.Major + "\n";
            message += "STATUS: " + selectedStudent.Status.ToUpper() + "\n";
            message += "--------------------------------------------------\n";
            message += "ENROLLED SUBJECTS:\n";

            if (selectedStudent.EnrolledCourses.Count == 0)
            {
                message += "No enrolled subjects for this semester.\n";
            }
            else
            {
                foreach (string subject in selectedStudent.EnrolledCourses)
                {
                    message += "• " + subject + "\n";
                }
            }

            message += "--------------------------------------------------\n";
            message += "Would you like to download/save the official COR file?";

            // 2. Display MessageBox with Yes/No option for downloading COR
            DialogResult result = MessageBox.Show(
                message,
                "Enrollment Status & Subject Breakdown",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            // 3. If user clicks "Yes", trigger COR file download
            if (result == DialogResult.Yes)
            {
                DownloadCOR(selectedStudent);
            }
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
                    // Generate COR string content from the Student model
                    string corData = student.GenerateCOR();

                    // Save to selected file path
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
    }
}