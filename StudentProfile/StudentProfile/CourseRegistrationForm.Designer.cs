namespace StudentProfile
{
    partial class CourseRegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbStudents = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnProcessPayment = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtPaymentAmount = new TextBox();
            lstPaymentHistory = new ListBox();
            lblBalance = new Label();
            lblTuitionBreakdown = new Label();
            SuspendLayout();
            // 
            // cmbStudents
            // 
            cmbStudents.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(12, 47);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(223, 29);
            cmbStudents.TabIndex = 0;
            cmbStudents.SelectedIndexChanged += cmbStudents_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(151, 21);
            label1.TabIndex = 1;
            label1.Text = "Registered Students:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(596, 18);
            label2.Name = "label2";
            label2.Size = new Size(117, 21);
            label2.TabIndex = 2;
            label2.Text = "Search Student:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(591, 47);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(214, 29);
            txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(794, 45);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(96, 31);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnProcessPayment
            // 
            btnProcessPayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProcessPayment.Location = new Point(607, 164);
            btnProcessPayment.Name = "btnProcessPayment";
            btnProcessPayment.Size = new Size(185, 31);
            btnProcessPayment.TabIndex = 5;
            btnProcessPayment.Text = "Process Payment";
            btnProcessPayment.UseVisualStyleBackColor = true;
            btnProcessPayment.Click += btnProcessPayment_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 148);
            label3.Name = "label3";
            label3.Size = new Size(143, 21);
            label3.TabIndex = 6;
            label3.Text = "Tuition Breakdown:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(370, 148);
            label4.Name = "label4";
            label4.Size = new Size(66, 21);
            label4.TabIndex = 7;
            label4.Text = "Balance:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(29, 244);
            label5.Name = "label5";
            label5.Size = new Size(133, 21);
            label5.TabIndex = 8;
            label5.Text = "Payment Amount:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(273, 242);
            label6.Name = "label6";
            label6.Size = new Size(127, 21);
            label6.TabIndex = 9;
            label6.Text = "Payment History:";
            // 
            // txtPaymentAmount
            // 
            txtPaymentAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPaymentAmount.Location = new Point(29, 268);
            txtPaymentAmount.Name = "txtPaymentAmount";
            txtPaymentAmount.Size = new Size(197, 29);
            txtPaymentAmount.TabIndex = 10;
            // 
            // lstPaymentHistory
            // 
            lstPaymentHistory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lstPaymentHistory.FormattingEnabled = true;
            lstPaymentHistory.ItemHeight = 21;
            lstPaymentHistory.Location = new Point(273, 266);
            lstPaymentHistory.Name = "lstPaymentHistory";
            lstPaymentHistory.Size = new Size(633, 172);
            lstPaymentHistory.TabIndex = 11;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalance.Location = new Point(370, 174);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(164, 21);
            lblBalance.TabIndex = 12;
            lblBalance.Text = "______________________";
            // 
            // lblTuitionBreakdown
            // 
            lblTuitionBreakdown.AutoSize = true;
            lblTuitionBreakdown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTuitionBreakdown.Location = new Point(29, 174);
            lblTuitionBreakdown.Name = "lblTuitionBreakdown";
            lblTuitionBreakdown.Size = new Size(164, 21);
            lblTuitionBreakdown.TabIndex = 13;
            lblTuitionBreakdown.Text = "______________________";
            // 
            // CourseRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 450);
            Controls.Add(lblTuitionBreakdown);
            Controls.Add(lblBalance);
            Controls.Add(lstPaymentHistory);
            Controls.Add(txtPaymentAmount);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnProcessPayment);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbStudents);
            Name = "CourseRegistrationForm";
            Text = "CourseRegistrationForm";
            Load += CourseRegistrationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbStudents;
        private Label label1;
        private Label label2;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnProcessPayment;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtPaymentAmount;
        private ListBox lstPaymentHistory;
        private Label lblBalance;
        private Label lblTuitionBreakdown;
    }
}