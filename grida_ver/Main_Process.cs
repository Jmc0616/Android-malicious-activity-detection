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

namespace grida_ver
{
    public partial class Main_Process : Form
    {
        System.Diagnostics.ProcessStartInfo cmd = new System.Diagnostics.ProcessStartInfo();
        System.Diagnostics.Process pro = new System.Diagnostics.Process();

        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath);

        private Thread thread1;

        String str = "";
        String str1 = "";
        String str2 = "";
        String str3 = "";

        int timerCount = 0;

        public Main_Process()
        {
            InitializeComponent();

            cmd.FileName = "cmd.exe";       //cmd.exe 실행
            cmd.CreateNoWindow = true;     //보이게한다.
            cmd.UseShellExecute = false;

            cmd.RedirectStandardInput = true;   //데이터 보내기
            cmd.RedirectStandardOutput = true;  //데이터 가져오기
            cmd.RedirectStandardError = true;   //오류 가져오기

            pro.EnableRaisingEvents = false;
            pro.StartInfo = cmd;
            pro.Start();
            //cmd 실행, 입력, 종료
            pro.StandardInput.Write(Application.StartupPath + Environment.NewLine);
            pro.StandardInput.Write("@cd Value" + Environment.NewLine);
            pro.StandardInput.Write("@frida-ps -U" + Environment.NewLine);
            pro.StandardInput.Write("@frida-ps -U > list.txt" + Environment.NewLine);
            pro.StandardInput.Close();

            pro.WaitForExit();
            pro.Close();

            string path = Application.StartupPath + @"\Value\list.txt";
            string[] textValue = System.IO.File.ReadAllLines(path);

            if (textValue.Length > 0)
            {
                for (int i = 0; i < textValue.Length; i++)
                {
                    listBox1.Items.Add(textValue[i]);
                }
            }
            textBox2.AppendText(DateTime.Now + "\r\n : 프로세스를 불러왔습니다 !!\r\n\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

            thread1 = new Thread(attach);
            thread1.Start();
        }
        private void attach()
        {
            textBox2.AppendText(DateTime.Now + "\r\n : 검사시작 !!\r\n\r\n");

            cmd.FileName = "cmd.exe";       //cmd.exe 실행
            cmd.CreateNoWindow = true;     //보이게한다.
            cmd.UseShellExecute = false;

            cmd.RedirectStandardInput = true;   //데이터 보내기
            cmd.RedirectStandardOutput = true;  //데이터 가져오기
            cmd.RedirectStandardError = true;   //오류 가져오기

            pro.EnableRaisingEvents = false;
            pro.StartInfo = cmd;
            pro.Start();

            //cmd 실행, 입력, 종료
            pro.StandardInput.Write(Application.StartupPath + Environment.NewLine);
            pro.StandardInput.Write("frida-trace -U " + str + str1 + str2 + str3 + textBox1.Text + @" > Value\trace.txt" + Environment.NewLine);
            pro.StandardInput.Close();

            pro.WaitForExit();
            pro.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo cmd = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();
            
            cmd.FileName = "cmd.exe";       //cmd.exe 실행
            cmd.CreateNoWindow = true;     //보이게한다.
            cmd.UseShellExecute = false;

            cmd.RedirectStandardInput = true;   //데이터 보내기
            cmd.RedirectStandardOutput = true;  //데이터 가져오기
            cmd.RedirectStandardError = true;   //오류 가져오기

            pro.StartInfo = cmd;
            pro.Start();

            pro.StandardInput.Write(@"cd C:\windows\system32" + Environment.NewLine);
            pro.StandardInput.Write("@taskkill /im cmd.exe" + Environment.NewLine);
            pro.Close();

            textBox2.AppendText(DateTime.Now + "\r\n : 검사종료 !!\r\n\r\n");

            timer1.Stop();
            timerCount = 0;
            label4.Text = "00:00:00";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\Tree\decisionTree.html");
            textBox2.AppendText(DateTime.Now + "\r\n 시각화를 완료했습니다.\r\n\r\n");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCount++;

            int sec = 0, min = 0, hour = 0;

            if (timerCount < 60)
            {
                sec = timerCount;
            }
            else if (timerCount < 3600)
            {
                min = timerCount / 60;
                sec = timerCount % 60;
            }
            else
            {
                hour = timerCount / 3600;
                min = (timerCount % 3600) / 60;
                sec = ((timerCount % 3600) % 60);
            }
            label4.Text = hour.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                str = "-i \"sendto\" ";
                textBox2.AppendText("Checked");
            }
            else
            {
                textBox2.AppendText("Unchecked");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox2.Checked)
            {
                str1 =  "-i \"open\" ";
                textBox2.AppendText("Checked");
            }
            else
            {
                textBox2.AppendText("Unchecked");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                str2 = "-i \"memcpy\" ";
                textBox2.AppendText("Checked");
            }
            else
            {
                textBox2.AppendText("Unchecked");
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                str3 = "-i \"" + maskedTextBox1.Text + "\" ";
                textBox2.AppendText("Checked");
            }
            else
            {
                textBox2.AppendText("Unchecked");
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                textBox1.Text = (listBox1.SelectedItem.ToString());
            }
        }

        private void Process_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
