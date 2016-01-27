using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication1
{
    public class Crawler
    {


        public static string[] JournalLinks(string uri, string tagData, string tagDataValue)
        {
            List<string> linkList = new List<string>();
            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc.LoadHtml(new WebClient().DownloadString(uri));


                var rootNode = doc.DocumentNode;


                var data = rootNode.Descendants().Where(n => n.GetAttributeValue(tagData, "").Equals(tagDataValue));


               


                foreach (var dataNode in data)
                {


                    string dataString = dataNode.InnerText;
                    dataString += " " + dataNode.InnerHtml;
                    linkList.Add(dataString);

                }

            }
            catch (Exception ex)
            { 
            
            
            
            }


            return linkList.ToArray();
        
        }

        public static string Keywords(string uri, string tagData, string tagDataValue)
        {





            List<string> keywordsList = new List<string>();
            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc.LoadHtml(new WebClient().DownloadString(uri));


                var rootNode = doc.DocumentNode;


                var data = rootNode.Descendants().Where(n => n.GetAttributeValue(tagData, "").Equals(tagDataValue));





                foreach (var dataNode in data)
                {


                    string dataString = dataNode.InnerText;
                    dataString += " " + dataNode.InnerHtml;
                    keywordsList.Add(dataString);

                }

            }
            catch (Exception ex)
            {



            }
            string Keywords = String.Join(", ", keywordsList.ToArray());






            return Keywords;
        
        
        
        
        }


    }
}