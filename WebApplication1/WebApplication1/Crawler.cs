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
        

        public static string[] JournalLinks(string uri, string tagAttribute, string tagValue)
        {
            List<string> linkList = new List<string>();
            HtmlDocument doc = new HtmlDocument();
            

            try
            {
                doc.LoadHtml(new WebClient().DownloadString(uri));


                var rootNode = doc.DocumentNode;



                if (tagAttribute == "Tag")
                {

                    var data = rootNode.Descendants(tagValue);
                    foreach (var dataNode in data)
                    {


                        string dataString = dataNode.InnerText;
                        dataString += " " + dataNode.InnerHtml;
                        linkList.Add(dataString);

                    }
                   
                }
                else
                {
                    var data = rootNode.Descendants().Where(n => n.GetAttributeValue(tagAttribute, "").Equals(tagValue));
                    foreach (var dataNode in data)
                    {


                        string dataString = dataNode.InnerText;
                        dataString += " " + dataNode.InnerHtml;
                        linkList.Add(dataString);

                    } 
                }

               


               

            }
            catch (Exception ex)
            { 
            
            
            
            }


            return linkList.ToArray();
        
        }

        public static string Keywords(string uri, string tagAttribute, string tagValue)
        {





            List<string> keywordsList = new List<string>();
            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc.LoadHtml(new WebClient().DownloadString(uri));


                var rootNode = doc.DocumentNode;

                if (tagAttribute == "Tag")
                {

                    var data = rootNode.Descendants(tagValue);
                    foreach (var dataNode in data)
                    {


                        string dataString = dataNode.InnerText;
                        dataString += " " + dataNode.InnerHtml;
                        keywordsList.Add(dataString);

                    }
                }
                else
                {


                    var data = rootNode.Descendants().Where(n => n.GetAttributeValue(tagAttribute, "").Equals(tagValue));
                    foreach (var dataNode in data)
                    {


                        string dataString = dataNode.InnerText;
                        dataString += " " + dataNode.InnerHtml;
                        keywordsList.Add(dataString);

                    }
                
                }



                

            }
            catch (Exception ex)
            {



            }
            string Keywords = String.Join(", ", keywordsList.ToArray());






            return Keywords;
        
        
        
        
        }
        public static string Name(string uri, string tagAttribute, string tagValue)
        {



            string Name = "";

           
            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc.LoadHtml(new WebClient().DownloadString(uri));


                var rootNode = doc.DocumentNode;

                if (tagAttribute == "Tag")
                {
                    var data = rootNode.Descendants(tagValue);





                    foreach (var dataNode in data)
                    {



                        Name = dataNode.InnerText;
                        break;

                    }
                }
                else {

                    var data = rootNode.Descendants().Where(n => n.GetAttributeValue(tagAttribute, "").Equals(tagValue));





                    foreach (var dataNode in data)
                    {



                        Name = dataNode.InnerText;
                        break;

                    }
                
                }
                
            }
            catch (Exception ex)
            {



            }
            






            return Name;




        }

        public static string SubmitLink(string uri, string tagAttribute, string tagValue)
        {



            string SubmitLink = "";

           
            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc.LoadHtml(new WebClient().DownloadString(uri));


                var rootNode = doc.DocumentNode;

                if (tagAttribute == "Tag")
                {
                    var data = rootNode.Descendants(tagValue);





                    foreach (var dataNode in data)
                    {

                        SubmitLink = dataNode.Attributes["href"].Value;


                    }
                }
                else
                {

                    var data = rootNode.Descendants().Where(n => n.GetAttributeValue(tagAttribute, "").Equals(tagValue));





                    foreach (var dataNode in data)
                    {

                        SubmitLink = dataNode.Attributes["href"].Value;


                    }
                }

            }
            catch (Exception ex)
            {



            }
           






            return SubmitLink;




        }


    }
}