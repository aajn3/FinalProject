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
            openFileDialog.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
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

            ResetFields();

            // fill ASCII dictionary and display dictionary in listview
            foreach (char key in dictKeys)
            {
                byte[] value = Encoding.ASCII.GetBytes(key.ToString());
                ASCII.Add(key, value);

                // convert the bytes into strings
                string disVal = "";
                foreach (byte val in value)
                {
                    disVal += val.ToString();
                }

                // display the ASCII dictionary                
                if (key == ' ')
                {
                    listViewDictionaries.Items.Add("space"); // replace ' ' with string for readability
                    listViewDictionaries.Items[listViewIndex].SubItems.Add(disVal);
                }
                else
                {
                    listViewDictionaries.Items.Add(key.ToString());
                    listViewDictionaries.Items[listViewIndex].SubItems.Add(disVal);
                }
                listViewIndex++;
            }

            // open the file dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
            {
                filePath = openFileDialog.FileName; //location of the selected file
                txtPathName.Text = filePath;

                // send the file path to textHandler 
                textHandler.CountOccurrences(filePath);

                // use textHandler to count and sort the file
                textHandler.PopulateFrequency();
                textHandler.PopulateOrderedFrequency();

                // fill the rest of the List View columns ( occur, freq + huff)
                listViewIndex = 0;
                codeHandler = new CodeHandler(textHandler.Ordered_Frequency);
                foreach (char item in textHandler.Occurences.Keys)
                {
                    listViewDictionaries.Items[listViewIndex].SubItems.Add(textHandler.Occurences[item].ToString());
                    listViewDictionaries.Items[listViewIndex].SubItems.Add(textHandler.Frequency[item].ToString("P"));
                    listViewDictionaries.Items[listViewIndex].SubItems.Add(codeHandler.HuffmanCode[item]);
                    listViewIndex++;
                }
            }
        }        

        /// <summary>
        /// Encrypt Button Click Handler
        /// Encrypts the target file and opens it for viewing
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                codeHandler = new CodeHandler(textHandler.Ordered_Frequency);
                codeHandler.Encrypt(filePath);

                Process.Start("wordpad.exe", "\"" + codeHandler.EncodedFilePath + "\""); // open target file in wordpad

                // populate text fields in GUI
                txtCipheredTxt.Text = textHandler.TotalChar.ToString("N0");
<<<<<<< HEAD
                txtClearTxt.Text = codeHandler.ToBinary.ToString("N0");
                txtCompRatio.Text = string.Format("{0:P2}", codeHandler.CalcCompressionRatio(codeHandler.ToBinary, textHandler.TotalChar) / 100);
=======
                txtClearTxt.Text = codeHandler.TotalBinary.ToString("N0");
                txtCompRatio.Text = string.Format("{0:P2}", codeHandler.CalcCompressionRatio(textHandler.TotalChar, codeHandler.TotalBinary) / 100);
>>>>>>> fd7fe926baee6d8be6259a5e99ebfe7980e9523c
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                MessageBox.Show("Invalid File Path: Please select a valid text file.");
            }
        }

        /// <summary>
        /// Decrypt Button Click Handler
        /// Decrypts the encoded file and opens it for viewing
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                codeHandler.Decrypt(filePath);

                Process.Start("wordpad.exe", "\"" + codeHandler.DecodedFilePath + "\""); // open target file in wordpad
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                MessageBox.Show("Invalid File Path: Please select a valid text file.");
            }
        }

        /// <summary>
        /// Exit Button Click Handler
        /// Closes the program
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void btnExit_Click(object sender, EventArgs e){ this.Close(); }
        #endregion    
    
        #region PRIVATE METHODS
        /// <summary>
        /// Resets the GUI to original state
        /// </summary>
        private void ResetFields()
        {
            listViewDictionaries.Items.Clear(); // clears any existing items in the table
            txtPathName.Text = "";
            txtCipheredTxt.Text = "";
            txtClearTxt.Text = "";
            txtCompRatio.Text = "";
        }
        #endregion
    }
}
