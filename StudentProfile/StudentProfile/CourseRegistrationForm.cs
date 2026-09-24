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

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string message;
            // Get selected student from the ArrayList
            int index = cmbStudents.SelectedIndex;
            if (index >= 0)
            {
                Student selectedStudent = (Student)manager.StudentList[index];
                message = "ID: " + selectedStudent.StudentId + "\nMajor: " + selectedStudent.Major;

                MessageBox.Show(message, "Student Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CourseRegistrationForm_Load(object sender, EventArgs e)
        {
            // Populating WinForms ComboBox with student names from the ArrayList
            foreach (Student s in manager.StudentList)
            {
                cmbStudents.Items.Add(s.FullName);
            }
        }
    }
}
