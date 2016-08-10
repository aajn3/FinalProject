using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Group3_FinalProject
{
    public partial class Form1 : Form
    {
        Dictionary<char, byte[]> ASCII;
        string dictKeys = " abcdefghijklmnopqrstuvwxyz";
        
        public Form1()
        {
            InitializeComponent();
            //filling ASCII dictionary and displaying dictionary in listview
            foreach (char key in dictKeys)
            {
                ASCII = new Dictionary<char, byte[]>();
                byte[] value = Encoding.ASCII.GetBytes(key.ToString());
                ASCII.Add(key, value);

                //making the byte[] a string
                string disVal = "";
                Console.WriteLine(value[0].ToString());
                //
                foreach (byte val in value)
                {
                    disVal += val.ToString();
                }

                lstViewDictionaries.Items.Add(new ListViewItem(new string[] { key.ToString(), disVal }));
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
