using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group3_FinalProject
{
    public class TextHandler
    {

        private int totalChar;


        public Dictionary<char,int> Occurences { get; set; }
        public Dictionary<char, double> Frequency { get; set; }
        public Dictionary<char, double> Ordered_Frequency { get; set; }

        public TextHandler()
        {
            Occurences = new Dictionary<char, int>();
            Frequency = new Dictionary<char, double>();
            Ordered_Frequency = new Dictionary<char, double>();
            totalChar = 0;

            // add keys to occurences
            string keys = "abcdefghijklmnopqrstuvwxyz";

            Occurences.Add(' ', 0);
            foreach (char key in keys){
                Occurences.Add(key,0);
            }
            
        }

        public void CountOccorences(string path){

            using(StreamReader reader = new StreamReader(path)){
                char index;

                while (reader.Peek()>=0)
                {

                    // Count total char
                    totalChar++;

                    index = Char.ToLower((char)reader.Read());

                    if ("abcdefghijklmnopqrstuvwxyz".Contains(index))
                    {
                        Occurences[index] = (Occurences[index]) + 1; ;
                    }
                    else
                    {
                        Occurences[' '] = (Occurences[' ']) + 1;
                    }

                }
            }

        }//CountOccorences

        public void PopulateFrequency()
        {

            foreach (char key in Occurences.Keys)
            {
                Frequency.Add(key, ((double)Occurences[key] / (double)totalChar));
            }

          
        }//PopulateFrequency


        public void PopulateOrderedFrequency()
        {
            foreach (var item in Frequency.OrderByDescending(key => key.Value))
            {
                Ordered_Frequency.Add(item.Key, item.Value);
            }

        }
    }

}
