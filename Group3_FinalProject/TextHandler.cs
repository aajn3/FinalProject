using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group3_FinalProject
{
    public class TextHandler
    {
        Dictionary<char, int> Occurences; //
        Dictionary<string, string> Frequency;
        Dictionary<string, string> Ordered_Frequency;
        

        public TextHandler()
        {
            Occurences = new Dictionary<char, int>();
            Frequency = new Dictionary<string, string>();
            Ordered_Frequency = new Dictionary<string, string>();

            // add keys to occurences
            string keys = "abcdefghijklmnopqrstuvwxyz";
            
            foreach(char key in keys){
                Occurences.Add(key,0);
            }
            Occurences.Add(' ', 0);
        }

        public void CountOccorences(string path){
            if (File.Exists(path))
            {
                Console.WriteLine("I'm here");
            }
            using(StreamReader reader = new StreamReader(path)){
                string line;//line of file
                char index;
                int value;

                while ((line = reader.ReadLine()) != null)
                {
                    // read each char
                    foreach (char c in line)
                    {
                        index = Char.ToLower(c);

                        if ("abcdefghijklmnopqrstuvwxyz".Contains(index))
                        {
                            value=(Occurences[index])+1;
                            Occurences[index] = value;
                        }
                        else
                        {
                            value = (Occurences[' ']) + 1;
                            Occurences[' '] = value;
                        }
                    }
                }
            }

        }//CountOccorences
    }

}
