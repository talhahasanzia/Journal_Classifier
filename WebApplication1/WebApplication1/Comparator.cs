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

        public static List<string> words = new List<string>();
        



            public Comparator()
        {


            
            
        
        }

           public static void SetWords()
            {
                words= new List<string>();

            string[] splitter = { ",","\n","\r" };
           
            int i = 0;
            string[] kwords = new string[140];

            Journal[] j=DataManager.GetJournalData();

            foreach(Journal journal in j)
            {
                
                kwords[i] = journal.Keywords;
                i++;
            
            }
           

                foreach(string tword in kwords)
                {
                    string[] tempKeywords = tword.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string keyword in tempKeywords)
                    {
                        string temp = keyword;
                        temp = temp.TrimEnd();
                        temp = temp.TrimStart();
                        temp = temp.Replace("(", " ");
                        temp = temp.Replace(")", " ");
                        temp = temp.Replace("'", "");
                        temp = temp.Replace("\n", "");
                        temp = temp.Replace("\r", "");
                        temp = temp.Replace("\\", "");
                        temp = temp.Replace("/", ",");
                        temp = temp.Replace(" ", "-");
                        temp = temp.ToLower();

                        if (words.Contains(temp))
                        { }
                        else
                        {
                           
                            words.Add(temp);
                        }
                    }
                }

               
            }
           






            public static string[] PrepareUserKeywords(string SampleKeywordsText)
            {
                List<string> Keywords = new List<string>();
                try
                {
                    int i=0;
                    string[] splitter = { ".", " ", ":", ",", ";", "'", "\"", "(", ")" };
                    string[] UserWords = SampleKeywordsText.Split(splitter, StringSplitOptions.RemoveEmptyEntries);


                    SetWords();

                    foreach (string uWord in UserWords)
                    {
                        bool isthere = false;
                        string s = "";

                        foreach (string word in words)
                        {

                        if (word.Contains("-") && i<UserWords.Length-1 )
                        {
                            int k=i+1;
                            if (word.ToLower() == uWord.ToLower()+"-"+UserWords[k].ToLower())
                            {

                                Keywords.Add(word);
                                isthere = false;
                                break;
                            }
                        }
                        else
                        {
                            if (word.ToLower() == uWord.ToLower())
                            {
                                s = word;
                                isthere = true;
                            }

                        }
                        
                        }
                        if (isthere)
                            Keywords.Add(s);

                        i++;
                    }
                }
                catch (Exception es)
                { }

                List<string> newWords = new List<string>();


                foreach (string temp in Keywords)
                {

                    if (newWords.Contains(temp))
                    {

                    }
                    else
                    {

                        newWords.Add(temp);
                    
                    }
                
                }

               
                return newWords.ToArray();
            }



            public static string ProcessWords(string text)
            {
                ///////////////////////// Get words list ////////////////////////////////
                StreamReader read = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/Words.txt"));

                string lineRead = read.ReadLine();

                while (lineRead != null)
                {

                    words.Add(lineRead);
                    try
                    {
                        lineRead = read.ReadLine();
                    }
                    catch (NullReferenceException ec)
                    {
                        break;
                    }
                }
                read.Close();
                read.Dispose();
                /////////////////////////////////////////////////////////////////////////
                string[] splitter = { "," };
                string[] wordsArray = text.Split(splitter, StringSplitOptions.RemoveEmptyEntries);


                //////////////////// Check if words is /////////////////////////////////
                foreach (string word in words)
                {
                    for (int count = 0; count < wordsArray.Length; count++)
                    {
                        if (wordsArray[count].ToLower() == word.ToLower())
                            wordsArray[count] = "";




                    }


                }
                ///////////////////////////////////////////////////////////////////////



                List<string> listString = wordsArray.ToList();



                listString.RemoveAll(item => item == "");


                List<string> newWords = new List<string>();


                foreach (string word in listString)
                {


                    if (newWords.Contains(word))
                    {

                    }
                    else
                    {
                        newWords.Add(word);

                    }

                }

                text = String.Join(",", newWords.ToArray());
                return text;
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
                                break;
                            }
                        }




                    }

                }
                catch(Exception ex)
                { }
                percentageOfMatchedKeywWords = ((float)count/totalNumber)*100.0f;
                





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
                                break;

                            }
                        }




                    }

                }
                catch (Exception ex)
                { }
                percentageOfMatchedKeywWords = ((float)count / totalNumber) * 100.0f;






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
                                break;

                            }
                        }




                    }

                }
                catch (Exception ex)
                { }
                percentageOfMatchedKeywWords = ((float)count / totalNumber) * 100.0f;






                return percentageOfMatchedKeywWords;
            }



    }
}