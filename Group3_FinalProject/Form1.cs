using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Group3_FinalProject
{
    // FORM 1 CLASS
    public partial class Form1 : Form
    {
        #region PRIVATE INSTANCE VARIABLES        
        private Dictionary<char, byte[]> ASCII;
        private TextHandler textHandler;
        private CodeHandler codeHandler;
        private string dictKeys = " abcdefghijklmnopqrstuvwxyz";
        private OpenFileDialog openFileDialog;
        private string filePath;
        #endregion

        // CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();

            textHandler = new TextHandler();
            openFileDialog = new OpenFileDialog();
        }

        #region EVENT HANDLERS
        /// <summary>
        /// Browse Button Click Handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ASCII = new Dictionary<char, byte[]>();
            int listViewIndex = 0;
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
                //displaying the ASCII dictionary
                //making the space character the word space so more human readable
                if (key == ' ')
                {
                    lstViewDictionaries.Items.Add("space");
                    lstViewDictionaries.Items[listViewIndex].SubItems.Add(disVal);
                }
                else
                {
                    lstViewDictionaries.Items.Add(key.ToString());
                    lstViewDictionaries.Items[listViewIndex].SubItems.Add(disVal);         
                }
                listViewIndex++;
            }
                // opens the dialog and if user click ok then
                if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
                {
                    //location of the iorn heel file 
                    filePath = openFileDialog.FileName;
                    txtPathName.Text = filePath;
                    // sends the file path to textHandler 
                    textHandler.CountOccurrences(filePath);
                    // textHandler will count and sort the file
                    textHandler.PopulateFrequency();
                    textHandler.PopulateOrderedFrequency();

                    /*
                     * Fills Rest of List View ( occur, freq + huff) 
                     */
                    listViewIndex = 0;
                    codeHandler = new CodeHandler(textHandler.Ordered_Frequency);
                    foreach (char item in textHandler.Occurences.Keys)
                    {
                        lstViewDictionaries.Items[listViewIndex].SubItems.Add(textHandler.Occurences[item].ToString());
                        lstViewDictionaries.Items[listViewIndex].SubItems.Add(textHandler.Frequency[item].ToString("P"));
                        lstViewDictionaries.Items[listViewIndex].SubItems.Add(codeHandler.HuffmanCode[item]);
                        listViewIndex++;
                        
                    }
                }            
        }

        /// <summary>
        /// Encrypt Button Click Handler
        /// Encrypts the target file and opens it in Wordpad
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            codeHandler = new CodeHandler(textHandler.Ordered_Frequency);
            codeHandler.Encrypt(filePath);
            Process.Start("wordpad.exe", "\"" + codeHandler.EncodedFilePath + "\"");
            txtCipheredTxt.Text = textHandler.TotalChar.ToString("N0");
            txtClearTxt.Text = codeHandler.ToBinary.ToString("N0");
            txtCompRatio.Text = string.Format("{0:P2}", codeHandler.CalcCompressionRatio(textHandler.TotalChar, codeHandler.ToBinary) / 100);
        }

        /// <summary>
        /// Decrypt Button Click Handler
        /// Decrypts the encoded file and opens it in Wordpad
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            codeHandler.Decrypt(filePath);
            Process.Start("wordpad.exe", "\"" + codeHandler.DecodedFilePath + "\"");
        }

        /// <summary>
        /// Exit Button Click Handler
        /// Closes the program
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnExit_Click(object sender, EventArgs e){this.Close(); }
        #endregion        
    }
}
