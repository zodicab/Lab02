using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab02_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Số tài khoản", 150);
            listView1.Columns.Add("Tên khách hàng", 200);
            listView1.Columns.Add("Địa chỉ", 250);
            listView1.Columns.Add("Số tiền", 150);

            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string soTK = textBox1.Text.Trim();
            string tenKH = textBox2.Text.Trim();
            string diaChi = textBox3.Text.Trim();
            string soTienStr = textBox4.Text.Trim();

            if (string.IsNullOrEmpty(soTK) || string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soTienStr)){
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            decimal soTien = Convert.ToDecimal(soTienStr);
            ListViewItem existingItem = listView1.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Text == soTK);
            if (existingItem == null){
                ListViewItem newItem = new ListViewItem(soTK);
                newItem.SubItems.Add(tenKH);
                newItem.SubItems.Add(diaChi);
                newItem.SubItems.Add(soTien.ToString());
                listView1.Items.Add(newItem);
                MessageBox.Show("Thêm mới dữ liệu thành công!");
            }else{
                existingItem.SubItems[1].Text = tenKH;
                existingItem.SubItems[2].Text = diaChi;
                existingItem.SubItems[3].Text = soTien.ToString();
                MessageBox.Show("Cập nhật dữ liệu thành công!");
            }

            TinhTongTien();
        }

        private void button2_Click(object sender, EventArgs e){
            string soTK = textBox1.Text.Trim();
            ListViewItem itemToDelete = listView1.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Text == soTK);

            if (itemToDelete == null){
                MessageBox.Show("Không tìm thấy số tài khoản cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show("Xóa tài khoản?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes){
                listView1.Items.Remove(itemToDelete);
                MessageBox.Show("Xóa tài khoản thành công!");
                TinhTongTien();
            }
        }

        private void button3_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e){
            if (listView1.SelectedItems.Count > 0){
                ListViewItem selectedItem = listView1.SelectedItems[0];
                textBox1.Text = selectedItem.SubItems[0].Text;
                textBox2.Text = selectedItem.SubItems[1].Text;
                textBox3.Text = selectedItem.SubItems[2].Text;
                textBox4.Text = selectedItem.SubItems[3].Text;
            }
        }

        private void TinhTongTien(){
            decimal tong = 0;
            foreach (ListViewItem item in listView1.Items){
                if (decimal.TryParse(item.SubItems[3].Text, out decimal tien)){
                    tong += tien;
                }
            }textBox5.Text = tong.ToString();
        }
    }
}
