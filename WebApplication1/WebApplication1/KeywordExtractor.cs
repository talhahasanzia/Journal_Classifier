﻿using HtmlAgilityPack;
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
        

       public static Journal springerKeywords(string uri)
        {
            Journal journalObj = new Journal();

            journalObj.Link = uri;

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

                   // Submit Online
                   /////////////////////////// GET Submit Link ////////////////////////
                   var spans = root.Descendants("span");
                   HtmlNode linkNode = null;

                   foreach (var item in spans)
                   {

                       if (item.InnerText == "Submit Online")
                       {
                           linkNode = item;
                           break;

                       }


                   }



                   string SubmitLink = linkNode.ParentNode.Attributes["href"].Value;
                   journalObj.Submit = SubmitLink;

                   ////////////////////////////// end submit link ///////////////////////
                   //////////////////////////////////////////////////////////////////////

                   
                   
                   
                   
                   
                   string Name = root.SelectSingleNode("//h1[@class='headline']").InnerText;
                   journalObj.Name = Name;

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

                   string t = ec.Source;

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


                   /////////////////////////// GET Submit Link ////////////////////////
                   var spans = root.Descendants("span");
                   HtmlNode linkNode = null;

                   foreach (var item in spans)
                   {

                       if (item.InnerText == "Submit a manuscript")
                       {
                           linkNode = item;
                           break;

                       }


                   }



                   string SubmitLink = linkNode.ParentNode.Attributes["href"].Value;

                   journalObj.Submit = SubmitLink;
                   
                   ////////////////////////////// end submit link ///////////////////////
                   //////////////////////////////////////////////////////////////////////



                   string Website = "Springer";
                   journalObj.Website = Website;
                   

                   ///////////////////////////// Get Aims and scope paragraph ie keywords data ///////////////////

                   var Tags = root.Descendants("div").Where(n => n.GetAttributeValue("class", "").Equals("wrap-inner content"));


                
                   
                   //  var TagArray = Tags.ToArray();

                   string Name = root.SelectSingleNode("//h1").InnerText;
                   Name = Name.Replace("About ", "");

                   journalObj.Name = Name;
                  
                   
                   
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

                   string ecp = ec.Source;

               }
               
           
           
           }
           /////////////////////////////////////////////// end keywords ///////////////////////////////////////
           Keywords = Comparator.ProcessWords(Keywords);
           journalObj.Keywords = Keywords;
           journalObj.Website = "Springer";

           return journalObj;


        }

      

       
       


    }
}