namespace Lab02_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelSeats = new System.Windows.Forms.TableLayoutPanel();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.lblManAnh = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tableLayoutPanelSeats
            // 
            this.tableLayoutPanelSeats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSeats.Location = new System.Drawing.Point(30, 44);
            this.tableLayoutPanelSeats.Name = "tableLayoutPanelSeats";
            this.tableLayoutPanelSeats.Size = new System.Drawing.Size(280, 200);
            this.tableLayoutPanelSeats.TabIndex = 1;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.Location = new System.Drawing.Point(30, 247);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(280, 23);
            this.lblThanhTien.TabIndex = 2;
            this.lblThanhTien.Text = "Thành Tiền: 0 đ";
            // 
            // btnChon
            // 
            this.btnChon.Location = new System.Drawing.Point(30, 280);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(75, 30);
            this.btnChon.TabIndex = 3;
            this.btnChon.Text = "Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(120, 280);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 30);
            this.btnHuyBo.TabIndex = 4;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Location = new System.Drawing.Point(210, 280);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(75, 30);
            this.btnKetThuc.TabIndex = 5;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // lblManAnh
            // 
            this.lblManAnh.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManAnh.ForeColor = System.Drawing.Color.Gold;
            this.lblManAnh.Location = new System.Drawing.Point(30, 9);
            this.lblManAnh.Name = "lblManAnh";
            this.lblManAnh.Size = new System.Drawing.Size(280, 31);
            this.lblManAnh.TabIndex = 0;
            this.lblManAnh.Text = "MÀN ẢNH";
            this.lblManAnh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 340);
            this.Controls.Add(this.lblManAnh);
            this.Controls.Add(this.tableLayoutPanelSeats);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnKetThuc);
            this.Name = "Form1";
            this.Text = "BÁN VÉ RẠP CHIẾU PHIM";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSeats;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Label lblManAnh;
    }
}
