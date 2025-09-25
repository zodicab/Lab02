using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lab02_2
{
    public partial class Form1 : Form
    {
        // DataTable to hold student information
        private DataTable studentTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
            InitializeDataTable();
        }

        // Sets up the columns for the DataTable
        private void InitializeDataTable()
        {
            studentTable.Columns.Add("MSSV", typeof(string));
            studentTable.Columns.Add("Họ Tên", typeof(string));
            studentTable.Columns.Add("Giới Tính", typeof(string));
            studentTable.Columns.Add("Điểm TB", typeof(double));
            studentTable.Columns.Add("Khoa", typeof(string));

            // Binds the DataTable to the DataGridView
            dataGridView1.DataSource = studentTable;
        }

        // Runs when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            // Adds faculties to the combo box
            comboBox1.Items.Add("QTKD");
            comboBox1.Items.Add("CNTT");
            comboBox1.Items.Add("NNA");
            comboBox1.SelectedIndex = 0;

            // Sets default gender to Female
            radioButton2.Checked = true;

            // Updates the student count on load
            UpdateStudentCount();
        }

        // Handles the Add/Edit button click
        private void button1_Click(object sender, EventArgs e)
        {
            // Input validation: checks if any text box is empty
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string studentId = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            double score;

            // Tries to convert the score to a number; if it fails, shows an error
            if (!double.TryParse(textBox3.Text, out score))
            {
                MessageBox.Show("Điểm trung bình không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string gender = radioButton1.Checked ? "Nam" : "Nữ";
            string faculty = comboBox1.SelectedItem.ToString();

            // Finds an existing student row by ID (MSSV)
            DataRow existingRow = studentTable.AsEnumerable()
                                             .FirstOrDefault(row => row.Field<string>("MSSV") == studentId);

            if (existingRow == null)
            {
                // Adds a new row if student does not exist
                DataRow newRow = studentTable.NewRow();
                newRow["MSSV"] = studentId;
                newRow["Họ Tên"] = name;
                newRow["Giới Tính"] = gender;
                newRow["Điểm TB"] = score;
                newRow["Khoa"] = faculty;
                studentTable.Rows.Add(newRow);

                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Updates the existing row if student exists
                existingRow["Họ Tên"] = name;
                existingRow["Giới Tính"] = gender;
                existingRow["Điểm TB"] = score;
                existingRow["Khoa"] = faculty;

                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateStudentCount();
            ClearInputs();
        }

        // Handles the Delete button click
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string studentId = textBox1.Text.Trim();
            DataRow rowToDelete = studentTable.AsEnumerable()
                                             .FirstOrDefault(row => row.Field<string>("MSSV") == studentId);

            if (rowToDelete == null)
            {
                MessageBox.Show("Không tìm thấy MSSV cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                studentTable.Rows.Remove(rowToDelete);
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStudentCount();
                ClearInputs();
            }
        }

        // Handles a cell click on the DataGridView to populate input fields
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["MSSV"].Value.ToString();
                textBox2.Text = row.Cells["Họ Tên"].Value.ToString();
                textBox3.Text = row.Cells["Điểm TB"].Value.ToString();
                comboBox1.SelectedItem = row.Cells["Khoa"].Value.ToString();

                string gender = row.Cells["Giới Tính"].Value.ToString();
                if (gender == "Nam")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
        }

        // Updates the count of male and female students
        private void UpdateStudentCount()
        {
            int maleCount = studentTable.AsEnumerable()
                                         .Count(row => row.Field<string>("Giới Tính") == "Nam");
            int femaleCount = studentTable.AsEnumerable()
                                           .Count(row => row.Field<string>("Giới Tính") == "Nữ");

            textBox4.Text = maleCount.ToString();
            textBox5.Text = femaleCount.ToString();
        }

        // Clears all input fields
        private void ClearInputs()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            radioButton2.Checked = true;
            comboBox1.SelectedIndex = 0;
        }

        // Empty event handlers that are not needed but were in the designer code
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
    }
}