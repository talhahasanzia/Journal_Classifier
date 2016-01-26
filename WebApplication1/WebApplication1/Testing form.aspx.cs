using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Testing_form : System.Web.UI.Page
    {
        static List<string> links = new List<string>();
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

            
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            Label1.Text = " technology, strategy, behaviour <br/> platform, methodology, function<br/> <br/>";


            List<string> ss1 = new List<string>();

            string[] s1={"technology","strategy", "behaviour"};

            ss1.AddRange(s1);
            
            string[] list1 = Comparator.GetSynonyms(s1.ToList()).ToArray();

            ss1.AddRange(list1);

            List<string> ss2 = new List<string>();
            
            string[] s2 = { "platform", "methodology", "function" };
            ss2.AddRange(s2);

            string[] list2 = Comparator.GetSynonyms(s2.ToList()).ToArray();

            ss2.AddRange(list2);
            
            Label1.Text += "<br/>Bag1:<br/>";
            foreach (string s in ss1)
                Label1.Text += "<br/>" + s;
            Label1.Text += "<br/>Bag2:<br/>";
            foreach (string s in ss2)
                Label1.Text += "<br/>" + s;


            float percentage = Comparator.GetStats(ss1.ToArray(), ss2.ToArray());

            Label1.Text += "<br/><br/>Match: " + percentage + "%";
           
        }

       
    }
}