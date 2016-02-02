using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Main : System.Web.UI.Page
    {

        static string Journal1Link = null;
        static string Journal1SubLink = null;
        static string Journal2Link = null;
        static string Journal2SubLink = null;
        static string Journal3Link = null;
        static string Journal3SubLink = null;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {


            RunAnalysis();
           
         
        }



        void RunAnalysis()
        {


            int i = 0;
            string keywords = TextBox2.Text;

           
            string[] stringSeparators = new string[] { "," };


            Journal[] journalData = DataManager.GetJournalData();

            Journal Springer = new Journal();
            Journal ACM = new Journal();
            Journal Emerald = new Journal();

            string[] splitter = { ",", " " };

            string[] keys = keywords.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            string[] keySyn = (keys);
            var list = new List<string>();
            list.AddRange(keys);
            list.AddRange(keySyn);

            string[] journalKeywords;
            
            string[] KeyWords = list.ToArray();
            float springerMatch = 0, acmMatch = 0, emeraldMatch = 0;

            foreach (Journal j in journalData)
            {
                i++;


                string journalKeywordString = (j.Keywords);
                 journalKeywords=journalKeywordString.Split(splitter,StringSplitOptions.RemoveEmptyEntries);


             
                float match = Comparator.GetStats(journalKeywords, KeyWords);

                if (j.Website == "Springer")
                {



                    if (match > springerMatch)
                    {

                        springerMatch = match;
                        Springer = j;


                    }


                }
                if (j.Website == "ACM" || j.Website=="Other")
                {


                    
                    if (match > acmMatch)
                    {

                        acmMatch = match;
                        ACM = j;


                    }

                }
                if (j.Website == "Emerald")
                {

                 

                    if (match > emeraldMatch)
                    {

                        emeraldMatch = match;
                        Emerald = j;


                    }

                }



            }


           
            
            if (String.IsNullOrEmpty(ACM.Name))
                ACM.Name = "No Journal Match Found";
            if (String.IsNullOrEmpty(Springer.Name))
                Springer.Name = "No Journal Match Found";
            if (String.IsNullOrEmpty(Emerald.Name))
                Emerald.Name = "No Journal Match Found";

            Journal1Link = Springer.Link;
            Journal1SubLink = Springer.Submit;
            Journal1Name.Text = Springer.Name;

            Journal2Link = Emerald.Link;
            Journal2SubLink = Emerald.Submit;
            Journal2Name.Text = Emerald.Name;

            Journal3Link = ACM.Link;
            Journal3SubLink = ACM.Submit;
            Journal3Name.Text = ACM.Name;
        }


        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

           
        }

       

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

            string suggestedWords = (TextBox1.Text);
            TextBox3.Text =  suggestedWords;


           
            
        }

        protected void Journal2Details_Click(object sender, EventArgs e)
        {
            Journal2Link = Journal2Link.Replace("\r", "");
            Journal2Link = Journal2Link.Replace("\n", "");
            Journal2Link = Journal2Link.Replace(" ", "");
            Response.Redirect(Journal2Link);
        }

        protected void Journal2Submit_Click(object sender, EventArgs e)
        {
            Journal2SubLink = Journal2SubLink.Replace("\r", "");
            Journal2SubLink = Journal2SubLink.Replace("\n", "");
            Journal2SubLink = Journal2SubLink.Replace(" ", "");
            Response.Redirect(Journal2SubLink);
        }

        protected void Journal3Details_Click(object sender, EventArgs e)
        {
            Journal3Link = Journal3Link.Replace("\r", "");
            Journal3Link = Journal3Link.Replace("\n", "");
            Journal3Link = Journal3Link.Replace(" ", "");
            
            Response.Redirect(Journal3Link);
        }

        protected void Journal3Submit_Click(object sender, EventArgs e)
        {
            Journal3SubLink = Journal3SubLink.Replace("\r", "");
            Journal3SubLink = Journal3SubLink.Replace("\n", "");
            Journal3SubLink = Journal3SubLink.Replace(" ", "");
            Response.Redirect(Journal3SubLink);
        }

        protected void Journal1Details_Click(object sender, EventArgs e)
        {
            Journal1SubLink = Journal1SubLink.Replace("\r", "");
            Journal1SubLink = Journal1SubLink.Replace("\n", "");
            Journal1SubLink = Journal1SubLink.Replace(" ", "");
            Response.Redirect(Journal1Link);
        }

        protected void Journal1Submit_Click(object sender, EventArgs e)
        {

            Journal1SubLink = Journal1SubLink.Replace("\r", "");
            Journal1SubLink = Journal1SubLink.Replace("\n", "");
            Journal1SubLink = Journal1SubLink.Replace(" ", "");
            Response.Redirect(Journal1SubLink);
        }
    }
}