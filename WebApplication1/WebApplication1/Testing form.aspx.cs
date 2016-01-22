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

            string refined = Comparator.ProcessWords("Robotics and Biomimetics is a high-quality journal that publishes original theoretical and experimental works in Robotics and Biomimetics. Robotics, traditionally as an interdisciplinary area of engineering areas, has been rapidly growing since the 1970s. In recent years, biological science is bringing new breakthroughs in robotics science and technology.Interactions between robotics and biology involve two aspects. On one hand, biological ideas and phenomena are inspiring innovations in every technical areas in robotics including mechanisms, actuation, sensing, control, etc. On the other hand, applying robotics technology to biology is significantly contributing to new understandings of biological systems and their behaviors.");


            Label1.Text = "Robotics and Biomimetics is a high-quality journal that publishes original theoretical and experimental works in Robotics and Biomimetics. Robotics, traditionally as an interdisciplinary area of engineering areas, has been rapidly growing since the 1970s. In recent years, biological science is bringing new breakthroughs in robotics science and technology.Interactions between robotics and biology involve two aspects. On one hand, biological ideas and phenomena are inspiring innovations in every technical areas in robotics including mechanisms, actuation, sensing, control, etc. On the other hand, applying robotics technology to biology is significantly contributing to new understandings of biological systems and their behaviors." + "<br/><br/>New Text:<br/>";

            string[] wordsArray = refined.Split(',');

            foreach (string word in wordsArray)
            {

                if (!(String.IsNullOrEmpty(word) || String.IsNullOrWhiteSpace(word)))
                {
                    Label1.Text += "<br/>" + word;
                
                }
            
            }

            //Journal[] journals = new Journal[links.Count];


            //for (int i = 0; i < journals.Length; i++)
            //{ 
            
            
            
            
            //}

            //string keys = KeywordExtractor.springerKeywords("http://www.springer.com/engineering/civil+engineering/journal/40069");
            //Label1.Text = keys;
        }
    }
}