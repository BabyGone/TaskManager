using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetProcess_Click(object sender, EventArgs e)
        {
            // Gọi hàm hiển thị tiến trình
            GetProcesses();
            // Làm mới danh sách tiến trình
            lstProcess.Items.Clear();
            // Gọi lại hàm hiển thị tiến trình
            GetProcesses();
        }

        // Hàm hiển thị tiến trình
        private void GetProcesses()
        {
            // Biến tiến trình
            Process[] task = Process.GetProcesses();

            // Vòng lặp đưa dữ liệu vào bảng ListBox
            foreach (Process proc in task)
            {
                lstProcess.Items.Add(proc.ProcessName);
            }           
        }

        // Hàm click chuột vào nút để dừng chương trình được chọn
        private void btnEndTask_Click(object sender, EventArgs e)
        {
            // Biến tiến trình
            Process[] task = Process.GetProcesses();

            // Vòng lặp đọc dữ liệu
            foreach (Process proc in task)
            {
                // Tiến trình được chọn sẽ được dừng lại
                if(lstProcess.SelectedItem.ToString() == proc.ProcessName)
                {
                    // Dừng chương trình
                    proc.Kill();
                    // Kết thúc vòng lặp
                    break;
                }    
            }
            // Làm mới danh sách tiến trình
            lstProcess.Items.Clear();
            // Gọi lại hàm hiển thị tiến trình
            GetProcesses();
        }

        // Hàm chạy tiến trình mới
        private void btnStartTask_Click(object sender, EventArgs e)
        {
            // Tạo InputBox để nhập tên tiến trình cần chạy
            string path = Microsoft.VisualBasic.Interaction.InputBox("Nhập tiến trình", "Task Manager", "", 350, 350);
            // Khởi động tiến trình
            Process.Start(path);
            // Làm mới danh sách tiến trình
            lstProcess.Items.Clear();
            // Gọi lại hàm hiển thị tiến trình
            GetProcesses();
        }

        // Hàm xem thông tin chi tiết của tiến trình
        private void btnProperties_Click(object sender, EventArgs e)
        {
            // Biến tiến trình
            Process[] task = Process.GetProcesses();

            // Vòng lặp đọc dữ liệu
            foreach (Process proc in task)
            {
                // Chọn tiến trình để xem thông tin chi tiết
                if (lstProcess.SelectedItem.ToString() == proc.ProcessName)
                {
                    string temp = string.Empty;
                    temp += "ID tiến trình : " + proc.Id.ToString(); // Lấy ID tiến trình được chọn
                    temp += "\nThời gian sử dụng tiến trình : " + proc.UserProcessorTime.ToString(); // Lấy thời gian sử dụng tiến trình được chọn
                    temp += "\nThời gian bắt đầu tiến trình : " + proc.StartTime.ToString(); // Lấy thời gian bắt đầu tiến trình được chọn
                    MessageBox.Show(temp); // Hiện form thông tin chi tiết
                    break; // Dừng vòng lặp
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
