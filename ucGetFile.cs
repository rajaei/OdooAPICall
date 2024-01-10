using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdooAPI2
{
    public partial class ucGetFile : UserControl
    {
        List<string> FileContent = new List<string>();
        public string FileAddress { get {
                return txtAddress.Text;
                    } }
        public List<string> lstFileLine
        {
            get
            {
                return FileContent.ToList();
            }
        }
        public ucGetFile()
        {
            InitializeComponent();
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            FileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog()== DialogResult.OK )
            {
                txtAddress.Text = dlg.FileName;
                try
                {
                    if (System.IO.File.Exists(txtAddress.Text))
                    {
                        StreamReader sr = new StreamReader(FileAddress);
                        FileContent.Clear();
                        while (!sr.EndOfStream)
                        {
                            string readLine = sr.ReadLine();
                            FileContent.Add(readLine);
                        }
                        sr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }


        }
    }
}
