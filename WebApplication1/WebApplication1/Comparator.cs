using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Comparator
    {
      




            public Comparator()
        {

             
           
            
        
        }


            public static void RunAnalysis(string[] keywords)
            {
                Journal[] journalsData = DataManager.GetJournalData();

               // do all analysis code here
            
            
            }


            static float[] GetResultFromACM(Journal[] journals, string[] totalKeywords)
            {
                List<float> Matches = new List<float>();

                foreach (Journal j in journals)
                {

                    if (j.Website == "ACM")
                    {
                        float matchFound = 0;
                        string[] keywords = j.Keywords.Split(new char[] { ',' });
                        foreach (string word in totalKeywords)
                        {
                            if (keywords.Contains(word))
                            {
                                matchFound = matchFound + 1;

                            }


                        }

                        if (matchFound > 0)
                        {
                            float perc = (matchFound / (float)totalKeywords.Length) * (float)100.0;
                            Matches.Add(perc);

                        }


                    }


                }
                return Matches.ToArray();
            }
    }
}