using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

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


            public static List<string> synonyms(string word)
            {
                string line;
                string inspeccontrolledindex = "<div class=\"relevancy-list\">";
                var colorOfBox = "#fcbb45";
                string end = "</div>";
                bool printNow = false;
                bool hasDarkYellow = false;
                string datakeyword = "<span class=\"text\">";
                int counter = 0;
                List<string> synonymsList = new List<string>();
                string path = HttpContext.Current.Server.MapPath("~/App_Data/synonyms.txt");
                Stream writer = new FileStream(path, FileMode.OpenOrCreate);
                writer.Close();

                using (WebClient client = new WebClient())
                {


                    try
                    {

                        client.DownloadFile("http://www.thesaurus.com/browse/" + word + "?s=t", path);
                    }
                    catch (WebException ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);

                    }


                    foreach (var linee in File.ReadLines(path))
                    {
                        //Console.WriteLine(linee);
                        if (printNow)
                        {
                            if (linee.Contains(end))
                            {
                                printNow = false;
                                counter++;
                            }
                        }
                        if (printNow)
                        {
                            if (linee.Contains(colorOfBox))
                            {
                                // Debug.WriteLine(linee);
                                hasDarkYellow = true;

                            }
                            if (linee.Contains(datakeyword) && hasDarkYellow == true)
                            {

                                var a = linee.IndexOf("\"text\">");
                                var b = linee.LastIndexOf("/span>");
                                var c = linee.Substring(a, b - a);
                                var d = c.IndexOf('>');
                                var e = c.IndexOf('<');
                                var f = c.Substring(d, e - d);
                                // c.

                                Console.WriteLine(f.Trim('>'));
                                synonymsList.Add(f.Trim('>'));
                                hasDarkYellow = false;

                            }


                        }
                        if ((linee.Contains(inspeccontrolledindex)) && counter == 0)
                            printNow = true;


                    }


                }
                return synonymsList;

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

                string[] wordsArray = text.Split(new string[] { "\n", "\r\n",",","."," " ,":","(",")","-"},StringSplitOptions.RemoveEmptyEntries);


                //////////////////// Check if words is /////////////////////////////////
                foreach (string word in words)
                {
                    for(int count=0; count<wordsArray.Length; count++)
                    {
                        if (wordsArray[count].ToLower() == word.ToLower())
                            wordsArray[count] = "";
                            
                    }
                
                
                }
                ///////////////////////////////////////////////////////////////////////

               

                List<string> listString = wordsArray.ToList();


                string stringWord = ",";
                string emptyWord = "";
                        
                
                listString.Remove(stringWord);
                listString.Remove(emptyWord);
                listString.RemoveAll(item => item == "");
                   


                text = String.Join(",",listString.ToArray());
                return text;
            }

    }
}