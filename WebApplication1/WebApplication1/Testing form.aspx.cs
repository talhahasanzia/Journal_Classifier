using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            StreamReader read = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/Links.txt"));

            string lineRead = read.ReadLine();

            while (lineRead != null)
            {

                links.Add(lineRead);
                try
                {
                    lineRead = read.ReadLine();
                }
                catch(NullReferenceException ec)
                {
                    break;
                }
            }
            read.Close();
            read.Dispose();


            Label1.Text = "Array loaded succesfully";


            foreach (string link in links)
            {


                Label1.Text += "<br/>" + link;
            
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string keys = KeywordExtractor.springerKeywords("http://www.viejournal.com/");
            Label1.Text = keys;
        }
    }
}