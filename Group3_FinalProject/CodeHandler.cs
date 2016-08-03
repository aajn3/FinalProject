using System;
using System.Collections.Generic;
using System.IO;


namespace Group3_FinalProject
{



    class CodeHandler
    {
        Dictionary<char, int> Occurences; //
        Dictionary<string, string> Frequency;
        Dictionary<string, string> Ordered_Frequency;
        

        CodeHandler()
        {
            Occurences = new Dictionary<char, int>();
            Frequency = new Dictionary<string, string>();
            Ordered_Frequency = new Dictionary<string, string>();

            // add keys to occurences
            string keys = "abcdefghijklmnopqrstuvwxyz";
            
            foreach(char key in keys){
                Occurences.Add(key,0);
            }
        }

        public void CountOccorences(string path){
            using(StreamReader reader = new StreamReader(path)){
                string line;//line of file

                while ((line = reader.ReadLine()) != null)
                {
                    // read each char
                    foreach (char c in line)
                    {
                        Occurences[c] = Occurences[c]++;
                    }
                }
            }
            Console.WriteLine(Occurences);
        }//CountOccorences
    }


}
