using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab02_3
{
    public partial class Form1 : Form
    {
        private Dictionary<int, int> seatPrices = new Dictionary<int, int>()
        {
            { 1, 30000 }, { 2, 30000 }, { 3, 30000 }, { 4, 30000 }, { 5, 30000 },
            { 6, 40000 }, { 7, 40000 }, { 8, 40000 }, { 9, 40000 }, { 10, 40000 },
            { 11, 50000 }, { 12, 50000 }, { 13, 50000 }, { 14, 50000 }, { 15, 50000 },
            { 16, 80000 }, { 17, 80000 }, { 18, 80000 }, { 19, 80000 }, { 20, 80000 }
        };

        public Form1()
        {
            InitializeComponent();
            SetupSeatLayout();
        }

        private void SetupSeatLayout(){
            tableLayoutPanelSeats.ColumnCount = 5;
            tableLayoutPanelSeats.RowCount = 4;
            tableLayoutPanelSeats.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelSeats.ColumnStyles.Clear();
            tableLayoutPanelSeats.RowStyles.Clear();
            for (int i = 0; i < 5; i++)
                tableLayoutPanelSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            for (int i = 0; i < 4; i++)
                tableLayoutPanelSeats.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            for (int i = 1; i <= 20; i++){
                Button btn = new Button();
                btn.Text = i.ToString();
                btn.Dock = DockStyle.Fill;
                btn.BackColor = Color.White;
                btn.Click += btnChooseASeat;
                tableLayoutPanelSeats.Controls.Add(btn);
            }
        }

        private void btnChooseASeat(object sender, EventArgs e){
            Button btn = sender as Button;
            if (btn.BackColor == Color.White)
                btn.BackColor = Color.Blue;
            else if (btn.BackColor == Color.Blue)
                btn.BackColor = Color.White;
            else if (btn.BackColor == Color.Yellow)
                MessageBox.Show("Ghế đã được bán!!");
        }

        private void btnChon_Click(object sender, EventArgs e){
            int total = 0;
            foreach (Control ctrl in tableLayoutPanelSeats.Controls){
                if (ctrl is Button btn && btn.BackColor == Color.Blue){
                    int seatNumber = int.Parse(btn.Text);
                    total += seatPrices[seatNumber];
                    btn.BackColor = Color.Yellow;
                }
            }
            lblThanhTien.Text = $"Thành Tiền: {total:N0} đ";
        }

        private void btnHuyBo_Click(object sender, EventArgs e){
            foreach (Control ctrl in tableLayoutPanelSeats.Controls)
            {
                if (ctrl is Button btn && btn.BackColor == Color.Blue)
                {
                    btn.BackColor = Color.White;
                }
            }
            lblThanhTien.Text = "Thành Tiền: 0 đ";
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
