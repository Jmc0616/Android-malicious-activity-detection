using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace grida_ver
{
    public partial class Main_Start : Form
    {
        System.Diagnostics.ProcessStartInfo cmd = new System.Diagnostics.ProcessStartInfo();
        System.Diagnostics.Process pro = new System.Diagnostics.Process();

        private Thread thread00;

        public Main_Start()
        {
            InitializeComponent();

            Floder F = new Floder();

            textBox1.AppendText(DateTime.Now + "\r\n폴더를 생성했습니다.\r\n\r\n");
            textBox1.AppendText(DateTime.Now + "\r\n프로그램 정상작동 !!\r\n" + "시작을 누르면 40초정도 소요됩니다.\r\n\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread00 = new Thread(autostart);
            thread00.Start();
            timer1.Start();
        }

        private void autostart()
        {
            textBox1.AppendText(DateTime.Now + "\r\n프로그램을 자동으로 시작합니다.\r\n\r\n");
            Thread.Sleep(2000);

            textBox1.AppendText(DateTime.Now + "\r\n디바이스를 실행합니다.\r\n\r\n");
            textBox1.AppendText(DateTime.Now + "\r\n잠시만 기다려주세요.\r\n\r\n");
            Devices newnox = new Devices();
            Thread.Sleep(30000);
            

            textBox1.AppendText(DateTime.Now + "\r\n디바이스를 찾고 연결합니다.\r\n\r\n");
            textBox1.AppendText(DateTime.Now + "\r\n잠시만 기다려주세요.\r\n\r\n");
            Device_Connect newconnect = new Device_Connect();
            Thread.Sleep(2000);

            textBox1.AppendText(DateTime.Now + "\r\n디바이스의 백그라운드를 조사합니다.\r\n\r\n");
            textBox1.AppendText(DateTime.Now + "\r\n잠시만 기다려주세요.\r\n\r\n");
            Attach newattach = new Attach();
            Thread.Sleep(2000);

            textBox1.AppendText(DateTime.Now + "\r\n완료되었습니다.\r\n\r\n");
            textBox1.AppendText(DateTime.Now + "\r\nPROCESS 버튼을 눌러 실행해주세요.\r\n\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(DateTime.Now + "\r\n프로세스 정보를 불러옵니다.\r\n\r\n");
            Main_Process newuai = new Main_Process();
            newuai.Show();
            textBox1.AppendText(DateTime.Now + "\r\n정상적으로 완료되었습니다 !!\r\n\r\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\read me.txt");
            textBox1.AppendText(DateTime.Now + "\r\n설명서를 실행시켰습니다.\r\n\r\n");
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                label1.Text = "완료!";
                Thread.Sleep(3000);
                label1.Text = "0%";
                progressBar1.Value = 0;
            }
            else
            {
                progressBar1.Value += 1;
                Thread.Sleep(400);
                label1.Text = progressBar1.Value.ToString() + "%";
            }
        }

        private void Main_Start_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
