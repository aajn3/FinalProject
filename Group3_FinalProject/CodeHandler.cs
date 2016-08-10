using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Group3_FinalProject
{
    // CODE HANDLER CLASS
    class CodeHandler
    {
        // PRIVATE INSTANCE VARIABLES
        private Dictionary<char, string> huffmanCode = new Dictionary<char, string>();
        private string[] encoding = { "100", "0010", "0011", "1111", "1110", "1100", "1011", "1010", "0110", "0101", "11011", "01111", "01001", "01000", "00011", "00010", "00001", "00000", "110101", "011101", "011100", "1101001", "110100011", "110100001", "110100000", "1101000101", "11010001000" };
        private string encodedFilePath = Environment.SpecialFolder.Desktop.ToString() + @"\Huffman_ciphered.txt"; // points to a file on the current desktop
        private string decodedFilePath = Environment.SpecialFolder.Desktop.ToString() + @"\Huffman_decoded.txt"; // points to a file on the current desktop
        
        // CONSTRUCTOR
        CodeHandler(Dictionary<char, double> orderedFrequency)
        {
            int indexer = 0;
            // populate huffmanCode
            foreach (char key in orderedFrequency.Keys)
            {
                huffmanCode.Add(key, encoding[indexer++]);
            }
        }

        // METHODS
        public void Encrypt(string path)
        {
            // open streams to original/new file paths
            using (StreamReader reader = new StreamReader(path))
            using (StreamWriter writer = new StreamWriter(encodedFilePath))
            {
                char index;
                while (reader.Peek()>=0)
                {
                    index = Char.ToLower((char)reader.Read());

                    if ("abcdefghijklmnopqrstuvwxyz".Contains(index.ToString()))
                    {
                        writer.Write(huffmanCode[index]);
                    }
                    else
                    {
                        writer.Write(huffmanCode[' ']);
                    }                    
                }
            }
            // open and display the resulting .txt <-- TODO: make this happen in either the codehandler or form
        }

        public void Decrypt(string path)
        {
            StringBuilder currentCharSet;
            // open streams to original/new file paths
            using (StreamReader reader = new StreamReader(encodedFilePath))
            using (StreamWriter writer = new StreamWriter(decodedFilePath))
            {
                // read and convert the ciphered file

                // display the decoded file
            }
        }

        double CalcCompressionRatio(int sizeOfCipherText, int sizeOfClearText)
        {
            return 100 - ((sizeOfCipherText / sizeOfClearText) * 8);
        }


        int CountCharInFile(string path)
        {
            int totalChar = 0;

            using (StreamReader reader = new StreamReader(path))
            {
                while (reader.Peek() >= 0)
                {
                    totalChar++; // add 1 to total
                }
            }
            return totalChar;
        }


    }
}
