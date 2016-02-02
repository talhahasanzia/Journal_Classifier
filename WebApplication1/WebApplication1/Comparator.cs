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


           






            public static string[] PrepareUserKeywords(string SampleKeywordsText)
            {
                List<string> Keywords = new List<string>();
                try
                {
                    int i=0;
                    string[] splitter = { ".", " ", ":", ",", ";", "'", "\"", "(", ")" };
                    string[] UserWords = SampleKeywordsText.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string uWord in UserWords)
                    {

                        foreach (string word in words)
                        {

                        if (word.Contains("-") && i<UserWords.Length-1 )
                        {
                            int k=i+1;
                            if (word.ToLower() == uWord.ToLower()+"-"+UserWords[k].ToLower())
                            {

                                Keywords.Add(word);
                            }
                        }
                        else
                        {
                            if (word.ToLower() == uWord.ToLower())
                            {

                                Keywords.Add(word);
                            }

                        }

                        }

                        i++;
                    }
                }
                catch (Exception es)
                { }

                return Keywords.ToArray();
            }


           


          
            public static float GetStatsSpringer(string[] journalKeywords, string[] userKeywords)
            {
               
                
              
                int count = 0;

                float totalNumber = userKeywords.Length;
                float percentageOfMatchedKeywWords;
                try
                {
                    //  float percentageOfMatchedWords;
                   



                    //
                    foreach (string uKeywords in userKeywords)
                    {
                        foreach (string jKeywords in journalKeywords)
                        {

                            if (uKeywords.ToLower() == jKeywords.ToLower())
                            {

                                count++;

                            }
                        }




                    }

                }
                catch(Exception ex)
                { }
                percentageOfMatchedKeywWords = (float)count;
                





                return percentageOfMatchedKeywWords;
            }
           
        
            public static float GetStatsEmerald(string[] journalKeywords, string[] userKeywords)
            {



                int count = 0;

                float totalNumber = userKeywords.Length;
                float percentageOfMatchedKeywWords;
                try
                {
                    //  float percentageOfMatchedWords;




                    //
                    foreach (string uKeywords in userKeywords)
                    {
                        foreach (string jKeywords in journalKeywords)
                        {

                            if (uKeywords.ToLower() == jKeywords.ToLower())
                            {

                                count++;

                            }
                        }




                    }

                }
                catch (Exception ex)
                { }
                percentageOfMatchedKeywWords = (float)count;






                return percentageOfMatchedKeywWords;
            }

            public static float GetStatsACM(string[] journalKeywords, string[] userKeywords)
            {



                int count = 0;

                float totalNumber = userKeywords.Length;
                float percentageOfMatchedKeywWords;
                try
                {
                    //  float percentageOfMatchedWords;




                    //
                    foreach (string uKeywords in userKeywords)
                    {
                        foreach (string jKeywords in journalKeywords)
                        {

                            if (uKeywords.ToLower() == jKeywords.ToLower())
                            {

                                count++;

                            }
                        }




                    }

                }
                catch (Exception ex)
                { }
                percentageOfMatchedKeywWords = (float)count;






                return percentageOfMatchedKeywWords;
            }



    }
}