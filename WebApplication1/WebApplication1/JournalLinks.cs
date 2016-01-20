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
    public class JournalLinks
    {

        static List<string> FinalKeywords = new List<string>();

       public static List<string> FromSpringer(string source,int depth)
        {
            FinalKeywords = new List<string>();

            int currentPage ;

            for (currentPage = 1; currentPage <= depth; currentPage++ )
            {
                
           // how many pages from search results
            Searcher.Springer.page = currentPage;
           
            var html = new HtmlDocument();

            html.LoadHtml(new WebClient().DownloadString(source)); // load a string web address
           // create a root node
           var root = html.DocumentNode;

           // get element having class =title, which is juournal link node
            var p = root.Descendants().Where(n => n.GetAttributeValue("class", "").Equals("title")).ToArray();

                
            var nodes = p.ToArray();


            List<string> Links = new List<string>();

            foreach (var node in nodes)
            {
                try
                {

                    // get HREF attribute of current node, because we need link
                    HtmlAttribute link = node.Attributes["href"];

                    // create a proper link
                    string temp = "http://link.springer.com" + link.Value;
                    Links.Add(temp);
                   
                }
                catch (Exception ex)
                {


                }


            }
           
           // for each journal (link), get keywords
            foreach (string link in Links)
            {
                // keywords returned as List of string
                List<string> tempKeywords=KeywordExtractor.springer(link);
               

                // when keyword is returned, check if that already exists in current bag
                foreach (string keyword in tempKeywords)
                {
                    
                    // already is in current word group-bag
                    if (FinalKeywords.Contains(keyword)) 
                    {   /* do nothing */ }
                    else    // not in word bag, so add
                    { FinalKeywords.Add(keyword);  }
                
                    // do for each keyword

                }


            // do for each journal (link)
            }
       }

            return FinalKeywords;

        }


       public static List<string> FromElsevier(string source, int depth)
       {
           FinalKeywords = new List<string>();

           int currentPage;

          // string htmlSource = GetHtml(source);


           for (currentPage = 1; currentPage <= depth; currentPage++)
           {

               // how many pages from search results
               Searcher.Springer.page = currentPage;

               var html = new HtmlDocument();

               
               html.LoadHtml(new WebClient().DownloadString(source));
               // load a string web address



             
               
               
               // create a root node
               var root = html.DocumentNode;

               // get element having class =title, which is juournal link node
               var p = root.Descendants().Where(n => n.GetAttributeValue("class", "").Equals("cLink artTitle S_C_artTitle")).ToArray();


               var nodes = p.ToArray();


               List<string> Links = new List<string>();


               foreach (var node in nodes)
               {
                   try
                   {

                       // get HREF attribute of current node, because we need link
                       HtmlAttribute link = node.Attributes["href"];

                       // create a proper link
                       string temp =  link.Value;
                       Links.Add(temp);

                   }
                   catch (Exception ex)
                   {
                       System.Diagnostics.Debug.WriteLine(ex.Message);

                   }


               }

               // for each journal (link), get keywords
               foreach (string link in Links)
               {
                   // keywords returned as List of string
                   List<string> tempKeywords = KeywordExtractor.Elsevier(link);


                   // when keyword is returned, check if that already exists in current bag
                   foreach (string keyword in tempKeywords)
                   {

                       // already is in current word group-bag
                       if (FinalKeywords.Contains(keyword))
                       { /* do nothing */ }
                       else    // not in word bag, so add
                       { FinalKeywords.Add(keyword); }

                       // do for each keyword

                   }


                   // do for each journal (link)
               }
           }

       

           return FinalKeywords;
       }


       public static List<string> FromACM(string source, int depth)
       {

           FinalKeywords = new List<string>();

           int currentPage;

           for (currentPage = 1; currentPage <= depth; currentPage++)
           {

               // how many pages from search results
               Searcher.Springer.page = currentPage;

               var html = new HtmlDocument();

               html.LoadHtml(new WebClient().DownloadString(source)); // load a string web address
               // create a root node
               var root = html.DocumentNode;

               // get element having class =title, which is juournal link node
               var p = root.Descendants().Where(n => n.GetAttributeValue("class", "").Equals("title")).ToArray();


               var nodes = p.ToArray();


               List<string> Links = new List<string>();

               foreach (var node in nodes)
               {
                   try
                   {
                       


                       // get HREF attribute of current node, because we need link
                       HtmlAttribute link = node.ChildNodes[1].Attributes["href"];

                       // create a proper link
                       string temp = "http://dl.acm.org/" + link.Value;
                       Links.Add(temp);

                   }
                   catch (Exception ex)
                   {
                       System.Diagnostics.Debug.WriteLine(ex.Message);

                   }


               }

               // for each journal (link), get keywords
               foreach (string link in Links)
               {
                   // keywords returned as List of string
                   List<string> tempKeywords = KeywordExtractor.acm(link);


                   // when keyword is returned, check if that already exists in current bag
                   foreach (string keyword in tempKeywords)
                   {

                       // already is in current word group-bag
                       if (FinalKeywords.Contains(keyword))
                       { /* do nothing */ }
                       else    // not in word bag, so add
                       { FinalKeywords.Add(keyword); }

                       // do for each keyword

                   }


                   // do for each journal (link)
               }
           }

           return FinalKeywords;

       }


       static string GetHtml(string urlAddress)
       {


           string data=null;
           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
           HttpWebResponse response = (HttpWebResponse)request.GetResponse();

           if (response.StatusCode == HttpStatusCode.OK)
           {
               Stream receiveStream = response.GetResponseStream();
               StreamReader readStream = null;

               if (response.CharacterSet == null)
               {
                   readStream = new StreamReader(receiveStream);
               }
               else
               {
                   readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
               }

                data = readStream.ReadToEnd();

               response.Close();
               readStream.Close();
           }

           return data;
       }

    }
}