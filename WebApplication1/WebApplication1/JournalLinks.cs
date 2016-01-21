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

       public static Journal[] FromSpringer()
        {

            List<Journal> JournalsFromSpringer = new List<Journal>();

            string source = "https://www.springer.com/gp/adis/products-services";
            var html = new HtmlDocument();

            try
            {
                html.LoadHtml(new WebClient().DownloadString(source)); // load a string web address
                // create a root node
                var root = html.DocumentNode;

                var Links = root.Descendants().Where(n => n.GetAttributeValue("class", "").Equals("flapContent--paragraph"));


                foreach (var Link in Links)
                {


                    Journal JournalObj = new Journal();

                    HtmlAttribute newAttribute = Link.FirstChild.Attributes["href"];
                    JournalObj.Link = newAttribute.Value;
                    JournalObj.Name = Link.InnerText;
                    JournalObj.Website = "Springer";
                    JournalObj.Keywords = KeywordExtractor.springerKeywords(JournalObj.Link);
                    JournalObj.Submit = KeywordExtractor.springerLink(JournalObj.Link);
                    if (String.IsNullOrEmpty(JournalObj.Submit))
                    {
                        JournalObj.Submit = "https://www.editorialmanager.com/";
                    
                    }
                    JournalsFromSpringer.Add(JournalObj);


                }
            }
            catch (Exception ex)
            { 
            
            
            }
            return JournalsFromSpringer.ToArray();
        }


       public static List<string> FromElsevier(string source, int depth)
       {
           FinalKeywords = new List<string>();

           int currentPage;

          // string htmlSource = GetHtml(source);


           for (currentPage = 1; currentPage <= depth; currentPage++)
           {

               
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


       public static Journal[] FromACM()
       {

           FinalKeywords = new List<string>();
           List<Journal> JournalDataList = new List<Journal>();
           string source = "http://dl.acm.org/pubs.cfm";
           var html = new HtmlDocument();
         
           
           html.LoadHtml(new WebClient().DownloadString(source)); // load a string web address
           // create a root node
           var root = html.DocumentNode;

           var trs = root.Descendants("tr").Where(n => n.GetAttributeValue("valign", "").Equals("top"));

           foreach (var item in trs)
           {
               Journal journalData = new Journal();

               FinalKeywords = new List<string>();
              
               var SecondChild = item.ChildNodes[3];
               var SecondGrandChild = SecondChild.ChildNodes[2];


               HtmlAttribute TitleName = SecondGrandChild.Attributes["title"];
               HtmlAttribute TitleLink = SecondGrandChild.Attributes["href"];

               string LinkOfJournal = "http://dl.acm.org/" + TitleLink.Value;
               journalData.Name = TitleName.Value;
               journalData.Link = LinkOfJournal;
               journalData.Website = "ACM";


               journalData.Keywords = KeywordExtractor.acm(LinkOfJournal);

               
              
               JournalDataList.Add(journalData);
           }

           return JournalDataList.ToArray();



       }



       

    }
}