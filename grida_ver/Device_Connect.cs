using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grida_ver
{
    public partial class Device_Connect : Form
    {
        private void Device_Connect_Load(object sender, EventArgs e)
        {

        }

        public Device_Connect()
        {
            InitializeComponent();


            System.Diagnostics.ProcessStartInfo cmd = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            cmd.FileName = "cmd.exe";       //cmd.exe 실행
            cmd.CreateNoWindow = true;     //보이게한다.
            cmd.UseShellExecute = false;

            cmd.RedirectStandardInput = true;   //데이터 보내기
            cmd.RedirectStandardOutput = true;  //데이터 가져오기
            cmd.RedirectStandardError = true;   //오류 가져오기

            pro.EnableRaisingEvents = false;
            pro.StartInfo = cmd;
            pro.Start();

            //명령어실행
            //cmd 실행, 입력, 종료
            pro.StandardInput.Write("@adb devices" + Environment.NewLine);
            pro.StandardInput.Write("@adb connect 127.0.0.1:62001" + Environment.NewLine);
            pro.StandardInput.Close();

            /*값이 저장되는 경로
            string resuiltValue = pro.StandardOutput.ReadToEnd();
            StringBuilder sb = new StringBuilder();

            sb.Append(resuiltValue);
            sb.Append("\r\n");

            pro.WaitForExit();
            pro.Close();
            */
        }
    }
}
