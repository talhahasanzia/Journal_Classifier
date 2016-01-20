using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WebApplication1
{
    public class KeywordExtractor
    {
       public static List<string> springer(string uri)
        {
            List<string> springerkeywords = new List<string>();
            char[] trimmer = { ' ' };
            char[] allTrimmer = { '\\', '(',')','/','<','>','=','"', };
            var html = new HtmlDocument();

            html.LoadHtml(new WebClient().DownloadString(uri)); // load a string web address
            // create a root node
            var root = html.DocumentNode;

            // get element having class =Keyword, which is keyword node
            var p = root.Descendants().Where(n => n.GetAttributeValue("class", "").Equals("Keyword")).ToArray();


            var nodes = p.ToArray();

            foreach(var node in nodes)
            {

                string tempKeyword = node.InnerHtml;
                // get inner text i.e keyword

                tempKeyword = tempKeyword.TrimEnd(trimmer);
                tempKeyword = tempKeyword.TrimStart(trimmer);
                tempKeyword = tempKeyword.Trim(allTrimmer);
                
                springerkeywords.Add(tempKeyword);     // add to list
                System.Diagnostics.Debug.WriteLine(tempKeyword);
            }
            return springerkeywords;
        }


        public static List<string> Elsevier(string uri)
        {
            List<string> ElsevierKeywords = new List<string>();

            var html = new HtmlDocument();


            html.LoadHtml(new WebClient().DownloadString(uri));
            // load a string web address






            // create a root node
            var root = html.DocumentNode;

            // get element having class =title, which is juournal link node
            var p = root.Descendants().Where(n => n.GetAttributeValue("class", "").Equals("svKeywords")).ToArray();


            var nodes = p.ToArray();



           

            foreach (var node in nodes)
            {
                try
                {

                   string key;
                    // get HREF attribute of current node, because we need link
                  

                   key = node.FirstChild.InnerText;
                    ElsevierKeywords.Add(key);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);

                }


            }


            return ElsevierKeywords;
        }


        public static List<string> acm(string uri)
        {
            List<string> acmkeywords = new List<string>();


            int counter = 0;
            string ccsforthisarticle = "CCS&nbsp;for&nbsp;this&nbsp;Article";
            string end = "]);";
            bool printNow = false;
            string quoteandgreatersymbol = "\">";
            string path = HttpContext.Current.Server.MapPath("~/App_Data/ACMhtmlFile.txt");
            Stream writer = new FileStream(path, FileMode.Create);
            writer.Close();
            //  string link = "http://dl.acm.org/citation.cfm?id=1073209&CFID=574953640&CFTOKEN=74149999";
            using (WebClient client = new WebClient())
            {

                client.DownloadFile(uri, path);

                foreach (var line in File.ReadLines(path))
                {

                    if (printNow)
                    {
                        if (line.Contains(end))
                        {
                            printNow = false;
                            counter++;
                        }
                    }
                    if (printNow)
                    {

                        if (line.Contains(quoteandgreatersymbol))
                        {
                            var a = line.IndexOf("href");
                            var b = line.LastIndexOf("/a>");
                            var c = line.Substring(a, b - a);
                            var d = c.IndexOf('>');
                            var e = c.IndexOf('<');
                            var f = c.Substring(d, e - d);
                            acmkeywords.Add(f.Trim('>'));
                            System.Diagnostics.Debug.WriteLine(f.Trim('>'));
                        }

                    }
                    if ((line.Contains(ccsforthisarticle)) && counter == 0)
                        printNow = true;

                }

            }




            return acmkeywords;
        }


    }
}