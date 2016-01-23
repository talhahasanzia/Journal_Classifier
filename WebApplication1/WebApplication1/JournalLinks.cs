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