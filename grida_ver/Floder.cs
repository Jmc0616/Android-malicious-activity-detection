using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace grida_ver
{
    public partial class Floder : Form
    {
        public Floder()
        {
            InitializeComponent();

            System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists("Tree"))
            {
                System.IO.Directory.CreateDirectory("Tree");
            }

            System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists("Value"))
            {
                System.IO.Directory.CreateDirectory("Value");
            }
        }

        private void Floder_Load(object sender, EventArgs e)
        {

        }
    }
}
