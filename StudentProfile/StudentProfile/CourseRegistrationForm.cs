using System;
using System.IO;
using System.Windows.Forms;
using static StudentProfile.Student;

namespace StudentProfile
{
    public partial class CourseRegistrationForm : Form
    {
        private StudentManager manager = new StudentManager();
        private Student selectedStudent = null;
        private int receiptCounter = 1003;

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

            selectedStudent = (Student)manager.StudentList[index];

            // Fill all the data on the form UI
            DisplayStudentData(selectedStudent);
        }

        private void DisplayStudentData(Student student)
        {
            // 1. Fill Tuition Breakdown Label
            lblTuitionBreakdown.Text = "Tuition (" + student.TotalUnits + " Units @ P" + student.TuitionRatePerUnit + "): P" + student.TotalTuitionFee.ToString("N2") +
                                       "\nMisc Fees: P" + student.MiscFees.ToString("N2") +
                                       "\nTotal Assessed: P" + student.TotalAssessedFees.ToString("N2");

            // 2. Fill Balance Label
            lblBalance.Text = "P" + student.RemainingBalance.ToString("N2");

            // 3. Fill Payment History ListBox
            lstPaymentHistory.Items.Clear();
            if (student.PaymentHistory.Count == 0)
            {
                lstPaymentHistory.Items.Add("No payment records found.");
            }
            else
            {
                foreach (string record in student.PaymentHistory)
                {
                    lstPaymentHistory.Items.Add(record);
                }
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

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a Student ID or Name to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student foundStudent = null;
            foreach (Student s in manager.StudentList)
            {
                if (s.MatchesSearch(searchTerm))
                {
                    foundStudent = s;
                    break;
                }
            }

            if (foundStudent != null)
            {
                // Sync ComboBox selection (this will trigger cmbStudents_SelectedIndexChanged)
                cmbStudents.SelectedItem = foundStudent.FullName;
            }
            else
            {
                MessageBox.Show("No student found with ID or Name matching: \"" + searchTerm + "\"", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearUI();
            }
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("Please search or select a student first.", "No Student Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Payment Input
            if (!double.TryParse(txtPaymentAmount.Text.Trim(), out double paymentAmount) || paymentAmount <= 0)
            {
                MessageBox.Show("Please enter a valid payment amount greater than zero.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (paymentAmount > selectedStudent.RemainingBalance)
            {
                MessageBox.Show("Payment amount cannot exceed the remaining balance (P" + selectedStudent.RemainingBalance.ToString("N2") + ").", "Overpayment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Process Payment
            string currentOR = "OR-" + receiptCounter++;
            selectedStudent.AddPayment(paymentAmount, currentOR);

            if (selectedStudent.RemainingBalance == 0)
            {
                selectedStudent.Status = "Cleared";
            }

            // Refresh Form Controls directly
            DisplayStudentData(selectedStudent);
            txtPaymentAmount.Clear();

            MessageBox.Show("Payment of P" + paymentAmount.ToString("N2") + " successfully processed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Generate & Prompt to Save Receipt File
            DownloadReceipt(selectedStudent, paymentAmount, currentOR);
        }

        private void DownloadReceipt(Student student, double paidAmount, string receiptNo)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Official Digital Receipt";
                saveFileDialog.FileName = "Receipt_" + receiptNo + "_" + student.StudentId + ".txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string receiptData = student.GenerateReceipt(paidAmount, receiptNo);
                    File.WriteAllText(saveFileDialog.FileName, receiptData);

                    MessageBox.Show("Official Digital Receipt saved successfully!", "Receipt Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ClearUI()
        {
            selectedStudent = null;
            lblTuitionBreakdown.Text = "------------------------";
            lblBalance.Text = "------------------------";
            lstPaymentHistory.Items.Clear();
            txtPaymentAmount.Clear();
        }
    }
}