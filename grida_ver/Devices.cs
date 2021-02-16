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
    public partial class Devices : Form
    {
        private void Devices_Load(object sender, EventArgs e)
        {

        }
        public Devices()
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

            pro.StartInfo = cmd;
            pro.Start();

            pro.StandardInput.Write("@Nox.exe" + Environment.NewLine);
            pro.Close();
        }
    }
}
