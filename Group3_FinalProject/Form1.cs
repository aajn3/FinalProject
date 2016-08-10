using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Group3_FinalProject
{
    public partial class Form1 : Form
    {
        //PRIVATE VARIABLES********************************************************************************
        Dictionary<char, byte[]> ASCII;
        TextHandler textHandler;
        string dictKeys = " abcdefghijklmnopqrstuvwxyz";
        private OpenFileDialog openFileDialog1;
        private string filePath;

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

            textHandler = new TextHandler();
           openFileDialog1 = new OpenFileDialog();
           
            


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
            // opens the dialog and if user click ok then
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // Test result.
            {
                filePath = openFileDialog1.FileName;

                textHandler.CountOccorences(filePath);

                textHandler.PopulateFrequency();
                textHandler.PopulateOrderedFrequency();


                ArrayList occurencesColumn = new ArrayList();

                int listViewIndex=0;
                foreach (char item in textHandler.Occurences.Keys)
                {
                    lstViewDictionaries.Items[listViewIndex].SubItems.Add(textHandler.Occurences[item].ToString());

                    lstViewDictionaries.Items[listViewIndex].SubItems.Add(textHandler.Frequency[item].ToString("P"));
                    listViewIndex++;


                }

               

            }
        }
    }
}
