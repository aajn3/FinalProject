using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Group3_FinalProject
{
    // CODE HANDLER CLASS
    class CodeHandler
    {
        // PRIVATE INSTANCE VARIABLES
        private Dictionary<char, string> huffmanCode = new Dictionary<char, string>();
        private string[] encoding = { "100", "0010", "0011", "1111", "1110", "1100", "1011", "1010", "0110", "0101", "11011", "01111", "01001", "01000", "00011", "00010", "00001", "00000", "110101", "011101", "011100", "1101001", "110100011", "110100001", "110100000", "1101000101", "11010001000" };
        private string encodedFilePath = Directory.GetCurrentDirectory() + @"\Huffman_ciphered.txt"; // points to a file on the current desktop
        private string decodedFilePath = Directory.GetCurrentDirectory() + @"\Huffman_decoded.txt"; // points to a file on the current desktop
        private int totBinary;

        public Dictionary<char, string> HuffmanCode { get { return huffmanCode; } }
        public string EncodedFilePath { get { return encodedFilePath; } }
        public string DecodedFilePath { get { return decodedFilePath; } }
        public int TotBinary { get { return totBinary; } set { totBinary = value; } }




        // CONSTRUCTOR
        public CodeHandler(Dictionary<char, double> orderedFrequency)
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
                    index = char.ToLower((char)reader.Read());

                    if ("abcdefghijklmnopqrstuvwxyz".Contains(index))
                    {
                        writer.Write(huffmanCode[index]);
                        totBinary += huffmanCode[index].Length;
                    }
                    else if(" ,;:".Contains(index))
                    {
                        writer.Write(huffmanCode[' ']);
                        totBinary += huffmanCode[' '].Length;
                    }                    
                }

            }
            // open and display the resulting .txt <-- TODO: make this happen in either the codehandler or form
        }

        public void Decrypt(string path)
        {
            //bool readThreeChars=true;//TEMP

            string currentCharSet = "";
            // open streams to original/new file paths
            using (StreamReader reader = new StreamReader(encodedFilePath))
            using (StreamWriter writer = new StreamWriter(decodedFilePath))
            {
                // read and convert the ciphered file
                while(reader.Peek()>=0){
                    
                    currentCharSet+=((char)reader.Read());
                    huffmanCode.ContainsValue(currentCharSet);

                    char myKey = huffmanCode.FirstOrDefault(x => x.Value == currentCharSet).Key;

                    if (myKey!=0)
                    {
                        writer.Write(myKey);
                        currentCharSet="";
                    }
                }

            }
        }

        public double CalcCompressionRatio(int sizeOfCipherText, int sizeOfClearText)
        {
            double compRatio = 100 - ((sizeOfCipherText / (sizeOfClearText * 8.0)) * 100);
            System.Console.WriteLine(sizeOfCipherText + " " +  sizeOfClearText + " " + compRatio );
            return compRatio;
        }


        //int CountCharInFile(string path)
        //{
        //    int totalChar = 0;

        //    using (StreamReader reader = new StreamReader(path))
        //    {
        //        while (reader.Peek() >= 0)
        //        {
        //            totalChar++; // add 1 to total
        //        }
        //    }
        //    return totalChar;
        //}


    }
}
