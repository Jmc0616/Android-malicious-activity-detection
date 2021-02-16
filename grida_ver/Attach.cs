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
    public partial class Attach : Form
    {
        private void Attach_Load(object sender, EventArgs e)
        {

        }

        public Attach()
        {
            InitializeComponent();

            System.Diagnostics.ProcessStartInfo cmd = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            cmd.FileName = "cmd.exe";      //cmd.exe 실행
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
            pro.StandardInput.Write("@adb shell" + Environment.NewLine);
            pro.StandardInput.Write("cd data/local/tmp" + Environment.NewLine);
            pro.StandardInput.Write("./frida-server &" + Environment.NewLine);
            pro.StandardInput.Close();

            pro.Close();
        }
    }
}
