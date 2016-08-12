using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Group3_FinalProject
{
    // CODE HANDLER CLASS
    class CodeHandler
    {
        #region INSTANCE VARIABLES & PROPERTIES
        // PRIVATE INSTANCE VARIABLES
        private int toBinary;
        private Dictionary<char, string> huffmanCode = new Dictionary<char, string>();
        private string[] encoding = { "100", "0010", "0011", "1111", "1110", "1100", "1011", "1010", "0110", "0101", "11011", "01111", "01001", "01000", "00011", "00010", "00001", "00000", "110101", "011101", "011100", "1101001", "110100011", "110100001", "110100000", "1101000101", "11010001000" };
        
        // file paths
        private string encodedFilePath = Directory.GetCurrentDirectory() + @"\Huffman_ciphered.txt";
        private string decodedFilePath = Directory.GetCurrentDirectory() + @"\Huffman_decoded.txt";

        // PUBLIC PROPERTIES
        public Dictionary<char, string> HuffmanCode { get { return huffmanCode; } }
        public string EncodedFilePath { get { return encodedFilePath; } }
        public string DecodedFilePath { get { return decodedFilePath; } }
        public int TotalBinary { get { return toBinary; } set { toBinary = value; } }
        #endregion

        // CONSTRUCTOR
        public CodeHandler(Dictionary<char, double> orderedFrequency)
        {
            int indexer = 0;
            // populate huffmanCode dictionary
            foreach (char key in orderedFrequency.Keys) {
                huffmanCode.Add(key, encoding[indexer++]);
            }    
        }

        #region PUBLIC METHODS
        /// <summary>
        /// Encrypt Method creates an encoded text file of 1's and 0's
        /// </summary>
        /// <param name="path">file path to the txt to be encoded</param>
        public void Encrypt(string path)
        {
            // open streams to original/new file paths
            using (StreamReader reader = new StreamReader(path))
            using (StreamWriter writer = new StreamWriter(encodedFilePath))
            {
                char index;
                while (reader.Peek()>=0) // check for end of file
                {
                    index = char.ToLower((char)reader.Read());

                    if ("abcdefghijklmnopqrstuvwxyz".Contains(index))
                    {
                        writer.Write(huffmanCode[index]);
                        toBinary += huffmanCode[index].Length;
                    }
                    else if(" ,;:".Contains(index))
                    {
                        writer.Write(huffmanCode[' ']);
                        toBinary += huffmanCode[' '].Length;
                    }                    
                }
            } // close streams
        }

        /// <summary>
        /// Decrypt Method outputs decoded file from 1's and 0's into human readable text
        /// </summary>
        /// <param name="path">file path to the txt to be decoded</param>
        public void Decrypt(string path)
        {
            string currentCharSet = "";

            // open streams to original/new file paths
            using (StreamReader reader = new StreamReader(encodedFilePath))
            using (StreamWriter writer = new StreamWriter(decodedFilePath))
            {
                while (reader.Peek() >= 0) // checks for end of file
                {
                    currentCharSet+=((char)reader.Read());
                    huffmanCode.ContainsValue(currentCharSet);

                    /* 
                     * Reduce the number of checks to dictonary
                     */ 
                    if (currentCharSet.Length > 2)
                    {
                        char myKey = huffmanCode.FirstOrDefault(x => x.Value.Equals(currentCharSet)).Key;
                        if (myKey != 0)
                        {
                            writer.Write(myKey);
                            currentCharSet = "";
                        }
                    }
                }
            } // close streams
        }

        /// <summary>
        /// Calculate Compression Ration Method
        /// </summary>
        /// <param name="sizeOfCipherText">number of characters in encoded file</param>
        /// <param name="sizeOfClearText">number of characters in original file</param>
        /// <returns>outputs the theoretical compression ratio</returns>
        public double CalcCompressionRatio(int sizeOfCipherText, int sizeOfClearText)
        {
            double compRatio = 100 - ((sizeOfCipherText / (sizeOfClearText * 8.0)) * 100);
            //System.Console.WriteLine("Size of Cipher Text: {0}\tSize of Clear Text: {1}\tCompression Ratio: {2}", sizeOfCipherText, sizeOfClearText, compRatio);
            return compRatio;
        }

        #endregion
    }
}
