using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Group3_FinalProject
{
    // TEXT HANDLER CLASS
    public class TextHandler
    {
        #region INSTANCE VARIABLES & PROPERTIES
        // PRIVATE INSTANCE VARIABLES
        private int totalChar;

        // PUBLIC PROPERTIES
        public int TotalChar { get { return totalChar; } set { totalChar = value;} }
        public Dictionary<char,int> Occurences { get; set; }
        public Dictionary<char, double> Frequency { get; set; }
        public Dictionary<char, double> Ordered_Frequency { get; set; }
        #endregion

        // CONSTRUCTOR
        public TextHandler()
        {
            Occurences = new Dictionary<char, int>();
            Frequency = new Dictionary<char, double>();
            Ordered_Frequency = new Dictionary<char, double>();
        }

        #region PUBLIC METHODS
        /// <summary>
        /// Count Occurrences Method
        /// </summary>
        /// <param name="path">file path of text to be analyzed</param>
        public void CountOccurrences(string path)
        {
            Occurences.Clear(); // ensures dictionary is empty

            // populate occurrences dictionary
            string keys = "abcdefghijklmnopqrstuvwxyz";
            Occurences.Add(' ', 0);
            foreach (char key in keys)
            {
                Occurences.Add(key, 0);
            }

            this.totalChar = 0;

            // open stream to read from file
            using (StreamReader reader = new StreamReader(path))
            {
                char index;

                while (reader.Peek() >= 0) // check for end of file
                {
                    // Count total char
                    this.totalChar++;

                    index = char.ToLower((char)reader.Read());

                    if ("abcdefghijklmnopqrstuvwxyz".Contains(index)) // counts all alpha
                    {
                        Occurences[index] = (Occurences[index]) + 1; ;
                    }
                    else if (" ,;:".Contains(index)) // counts spaces, commas, colons and semi-colons as spaces
                    {
                        Occurences[' '] = (Occurences[' ']) + 1;
                    }
                }
            } // close stream
        }

        /// <summary>
        /// Populate Frequency Method
        /// Calculates the frequency of each character present in Occurence
        /// </summary>
        public void PopulateFrequency()
        {
            Frequency.Clear(); // ensures dictionary is empty
            foreach (char key in Occurences.Keys)
            {
                Frequency.Add(key, ((double)Occurences[key] / (double)totalChar));
            }
          
        }

        /// <summary>
        /// Populate Ordered Frequency Method
        /// Sorts letters by frequency in descending order
        /// </summary>
        public void PopulateOrderedFrequency()
        {
            Ordered_Frequency.Clear(); // ensures dictionary is empty
            foreach (var item in Frequency.OrderByDescending(key => key.Value))
            {
                Ordered_Frequency.Add(item.Key, item.Value);
            }
        }
        #endregion
    }

}
