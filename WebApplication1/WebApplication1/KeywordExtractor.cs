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
        

       public static string springerKeywords(string uri)
        {

            string Keywords = null;

           string springer="http://www.springer.com/";

            var html = new HtmlDocument();

           char[] splitter={','};

           if (uri.Contains(springer))
           {
               uri = uri + "?detailsPage=aboutThis";

               try
               {
                   html.LoadHtml(new WebClient().DownloadString(uri)); // load a string web address


                   // create a root node
                   var root = html.DocumentNode;

                   string Name = root.SelectSingleNode("//h1[@class='headline']").InnerText;

                   var node = root.SelectSingleNode("//div[@class='colLeftContentContainer']");

                   var Tags = node.Descendants("a");

                   //  var TagArray = Tags.ToArray();
                   


                   // this should run only once
                   foreach (var tag in Tags)
                   {

                       if (tag.FirstChild != null)
                       {
                           HtmlNode spanNode = tag.FirstChild;

                           if (!String.IsNullOrEmpty(spanNode.InnerText))
                           {

                               if (String.IsNullOrEmpty(Keywords))
                                   Keywords = spanNode.InnerText;
                               else
                               Keywords += ", " + spanNode.InnerText;
                           }
                       }
                   }
               }
               catch (Exception ec)
               {



               }
              


           }
           else
           {


               uri = uri + "about";

               try
               {
                   html.LoadHtml(new WebClient().DownloadString(uri)); // load a string web address


                   // create a root node
                   var root = html.DocumentNode;

                   var Tags = root.Descendants("div").Where(n => n.GetAttributeValue("class", "").Equals("wrap-inner content"));

                   //  var TagArray = Tags.ToArray();

                   string Name = root.SelectSingleNode("//h1").InnerText;
                   Name = Name.Replace("About ", "");
                   // this should run only once
                   foreach (var tag in Tags)
                   {


                       HtmlNode spanNode = tag.ChildNodes[9];
                       Keywords = spanNode.InnerText;
                       break;

                   }
               }
               catch (Exception ec)
               {



               }
               
           
           
           }

           ProcessText();

           return Keywords;

        }

       static void ProcessText()
       { 
       
       
       
       
       }

        public static string springerLink(string uri)
       {

           string SubmitLink = null;

           var html = new HtmlDocument();


           try
           {
               html.LoadHtml(new WebClient().DownloadString(uri)); // load a string web address
               // create a root node
               var root = html.DocumentNode;

               var Tags = root.Descendants("div").Where(n => n.GetAttributeValue("id", "").Equals("FOR_AUTHOR_AND_EDITORS"));




               foreach (var element in Tags)
               {


                   var Tag = element.Descendants("a").Where(n => n.GetAttributeValue("class", "").Equals("rightArrow linkToOpenLayer isLink"));


                   foreach (var Slink in Tag)
                   {
                       HtmlAttribute LinkAttribute = Slink.Attributes["href"];
                       SubmitLink = LinkAttribute.Value;
                       break;
                   }
                   break;
               }
           }
           catch (Exception ex)
           { }
           return SubmitLink;
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


        public static string acm(string uri)
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


            string Keywords = string.Join(",", ACMKeywords.ToArray());
            
            
            return Keywords;
            
        }


    }
}