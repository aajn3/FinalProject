using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace Group3_FinalProject
{
    public partial class Form1 : Form
    {
        //PRIVATE VARIABLES********************************************************************************
        Dictionary<char, byte[]> ASCII;
        TextHandler textHandler;
        CodeHandler codeHandler;
        string dictKeys = " abcdefghijklmnopqrstuvwxyz";
        private OpenFileDialog openFileDialog;
        private string filePath;

        public Form1()
        {
            InitializeComponent();

            textHandler = new TextHandler();
            openFileDialog = new OpenFileDialog();
        }

        private void btnExit_Click(object sender, EventArgs e){this.Close();}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ASCII = new Dictionary<char, byte[]>();
            //filling ASCII dictionary and displaying dictionary in listview
            foreach (char key in dictKeys)
            {                
                byte[] value = Encoding.ASCII.GetBytes(key.ToString());
                ASCII.Add(key, value);

                //making the byte[] a string
                string disVal = "";

                foreach (byte val in value)
                {
                    disVal += val.ToString();
                }
                if (key == ' ')
                {
                    lstViewDictionaries.Items.Add(new ListViewItem(new string[] { "space", disVal }));
                }
                else
                {
                    lstViewDictionaries.Items.Add(new ListViewItem(new string[] { key.ToString(), disVal }));
                }
            }
            // opens the dialog and if user click ok then
            if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
            {
                //location of the iorn heel file 
                filePath = openFileDialog.FileName;
                txtPathName.Text = filePath;
                // sends the file path to textHandler 
                textHandler.CountOccorences(filePath);
                // textHandler will count and sort the file
                textHandler.PopulateFrequency();
                textHandler.PopulateOrderedFrequency();

                /*
                 * Fills Rest of List View ( occur, freq + huff) 
                 */
                int listViewIndex=0;
                codeHandler = new CodeHandler(textHandler.Ordered_Frequency);
                foreach (char item in textHandler.Occurences.Keys){
                    lstViewDictionaries.Items[listViewIndex].SubItems.Add(textHandler.Occurences[item].ToString());
                    lstViewDictionaries.Items[listViewIndex].SubItems.Add(textHandler.Frequency[item].ToString("P"));
                    lstViewDictionaries.Items[listViewIndex].SubItems.Add(codeHandler.HuffmanCode[item]);
                    listViewIndex++;
                }
                


            }
        }

        private void btnEncryt_Click(object sender, EventArgs e)
        {
            //int listViewIndex = 0;
            //
            codeHandler = new CodeHandler(textHandler.Ordered_Frequency);
            codeHandler.Encrypt(filePath);
            Process.Start("wordpad.exe", "\"" + codeHandler.EncodedFilePath + "\"");
            // populate the hufman code


        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            codeHandler.Decrypt(filePath);
            Process.Start("wordpad.exe", "\"" + codeHandler.DecodedFilePath + "\"");
        }

        private void lstViewDictionaries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
