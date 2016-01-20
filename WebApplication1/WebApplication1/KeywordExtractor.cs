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

            List<string> ACMKeywords = new List<string>();



            string extension = "&acronym=TACCESS&_cf_containerId=about‌%E2%80%8B&_cf_nodebug=true&_cf_nocache=true";
            string input = uri;

            int index = input.IndexOf("&");
            if (index > 0)
                input = input.Substring(0, index);

            input = input.Insert(21, "_about");

            input = input + extension;
            var html = new HtmlDocument();



            html.LoadHtml(new WebClient().DownloadString(input));
            // load a string web address






            // create a root node
            var root = html.DocumentNode;

            // get element having class =Keyword, which is keyword node
            var LargestTags = root.Descendants("a").Where(n => n.GetAttributeValue("class", "").Equals("largestTag")).ToArray();
            var LargeTags = root.Descendants("a").Where(n => n.GetAttributeValue("class", "").Equals("largeTag")).ToArray();
            var SmallestTags = root.Descendants("a").Where(n => n.GetAttributeValue("class", "").Equals("smallestTag")).ToArray();
            var SmallTags = root.Descendants("a").Where(n => n.GetAttributeValue("class", "").Equals("smallTag")).ToArray();

            foreach (var Tag in LargestTags)
            {

                ACMKeywords.Add(Tag.InnerHtml);
            
            }
            foreach (var Tag in LargeTags)
            {

                ACMKeywords.Add(Tag.InnerHtml);

            }
            foreach (var Tag in SmallestTags)
            {

                ACMKeywords.Add(Tag.InnerHtml);

            }
            foreach (var Tag in SmallTags)
            {

                ACMKeywords.Add(Tag.InnerHtml);

            }
            return ACMKeywords;
            
        }


    }
}