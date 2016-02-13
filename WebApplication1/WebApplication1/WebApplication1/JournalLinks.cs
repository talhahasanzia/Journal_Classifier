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



        public static string[] OpenAccessLinks()
        {
            string[] links=null;



            HtmlDocument doc = new HtmlDocument();
            //doc.LoadHtml(new WebClient().DownloadString();
           
            
            doc.Load(HttpContext.Current.Server.MapPath("~/App_Data/Emerald Insight Browse Journals and Books.htm"));

            var rootNode = doc.DocumentNode;


            var titles = rootNode.Descendants("tr").Where(n => n.GetAttributeValue("class", "").Equals("browseItem"));

            links = new string[titles.ToArray().Length];

            int i = 0;
            foreach (var node in titles)
            {



                HtmlNode third = node.ChildNodes[3];

                var col = third.Descendants("a").ToArray();
                string link = col[0].Attributes["href"].Value;
                link = link.Replace("/loi/", "");

                links[i] = "http://emeraldgrouppublishing.com/products/journals/journals.htm?id=" + link;
                i++;
            
            
            
            }

            return links;
        
        }
        
        
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
                    //JournalObj.Keywords = KeywordExtractor.springerKeywords(JournalObj.Link);
                    //JournalObj.Submit = KeywordExtractor.springerLink(JournalObj.Link);
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


      


       



       

    }
}