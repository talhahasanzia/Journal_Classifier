using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using HtmlAgilityPack;

namespace WebApplication1
{
    public class Comparator
    {

        static List<string> words = new List<string>();
        



            public Comparator()
        {


            
            
        
        }


            public static void RunAnalysis(string[] keywords)
            {
                Journal[] journalsData = DataManager.GetJournalData();

               // do all analysis code here
            
            
            }






            public static string[] PrepareUserKeywords(string SampleKeywordsText)
            {
                List<string> Keywords = new List<string>();




                return Keywords.ToArray();
            }


           


          
            public static float GetStats(string[] journalKeywords, string[] userKeywords)
            {
                int count = 0;
                //  float percentageOfMatchedWords;
                float totalNumber = userKeywords.Length;
                float percentageOfMatchedKeywWords;
                
                
                
                //
                foreach (string uKeywords in userKeywords)
                {
                    foreach (string jKeywords in journalKeywords)
                    {

                        if (uKeywords.ToLower()==jKeywords.ToLower())
                        {

                            count++;
                           
                        }
                    }




                }
                percentageOfMatchedKeywWords = (float)count;
                





                return percentageOfMatchedKeywWords;
            }


    }
}