using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
       
        string[] userKeywords;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {


            RunAnalysis();
           
         
        }

        void MatchSpringer(string[] userKeywords)
        {

             Journal Springer = new Journal();
            string[] splitter = { ".", " ", ":", ",", ";", "'", "\"", "(", ")" };
            Journal[] journals = DataManager.GetSpringerData();
            float mostmatch = 0;
            foreach (Journal j in journals)
            { 
            
            float match=Comparator.GetStatsSpringer(j.Keywords.Split(splitter,StringSplitOptions.RemoveEmptyEntries),userKeywords);

                if (match > mostmatch)
                {

                    mostmatch = match;
                    Springer = j;

                 }
            
            }


            Journal1Link = Springer.Link;
            Journal1SubLink = Springer.Submit;
            Journal1Name.Text = "Springer:<br>"+Springer.Name;
        
        }

        void MatchEmerald(string[] userKeywords)
        {

            Journal Emerald= new Journal();
            string[] splitter = { ".", " ", ":", ",", ";", "'", "\"", "(", ")" };
            Journal[] journals = DataManager.GetSpringerData();
            float mostmatch = 0;
            foreach (Journal j in journals)
            {

                float match = Comparator.GetStatsSpringer(j.Keywords.Split(splitter, StringSplitOptions.RemoveEmptyEntries), userKeywords);

                if (match > mostmatch)
                {

                    mostmatch = match;
                    Emerald = j;

                }

            }


            Journal1Link = Emerald.Link;
            Journal1SubLink =Emerald.Submit;
            Journal1Name.Text = "Emerald:<br>" + Emerald.Name;

        }

        void MatchACMandOther(string[] userKeywords)
        {



            Journal ACM = new Journal();
            string[] splitter = { ".", " ", ":", ",", ";", "'", "\"", "(", ")" };
            Journal[] journals = DataManager.GetSpringerData();
            float mostmatch = 0;
            foreach (Journal j in journals)
            {

                float match = Comparator.GetStatsSpringer(j.Keywords.Split(splitter, StringSplitOptions.RemoveEmptyEntries), userKeywords);

                if (match > mostmatch)
                {

                    mostmatch = match;
                    ACM = j;

                }

            }


            Journal1Link = ACM.Link;
            Journal1SubLink = ACM.Submit;
            Journal1Name.Text = ACM.Website+":<br>" + ACM.Name;

        }
        void RunAnalysis()
        {


            string keywords = TextBox2.Text;

           
            string[] stringSeparators = new string[] { "," };


            string[] s = Comparator.PrepareUserKeywords(keywords);



            Parallel.Invoke(
      () => MatchACMandOther(s),
      () => MatchEmerald(s),
      () => MatchSpringer(s));

           

           
        }


        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

           
        }

       

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

            string suggestedWords = String.Join(",",Comparator.PrepareUserKeywords(TextBox1.Text));
            TextBox2.Text =  suggestedWords;


           
            
        }

        protected void Journal2Details_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Journal2Link))
            {

            }
            else
            {



                Journal2Link = Journal2Link.Replace("\r", "");
                Journal2Link = Journal2Link.Replace("\n", "");
                Journal2Link = Journal2Link.Replace(" ", "");
                Response.Redirect(Journal2Link);
            }
        }

        protected void Journal2Submit_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Journal2SubLink))
            {

            }
            else
            {

                Journal2SubLink = Journal2SubLink.Replace("\r", "");
                Journal2SubLink = Journal2SubLink.Replace("\n", "");
                Journal2SubLink = Journal2SubLink.Replace(" ", "");
                Response.Redirect(Journal2SubLink);
            }
        }

        protected void Journal3Details_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Journal3Link))
            {

            }
            else
            {


                Journal3Link = Journal3Link.Replace("\r", "");
                Journal3Link = Journal3Link.Replace("\n", "");
                Journal3Link = Journal3Link.Replace(" ", "");

                Response.Redirect(Journal3Link);
            }
        }

        protected void Journal3Submit_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(Journal3SubLink))
            {

            }
            else
            {


                Journal3SubLink = Journal3SubLink.Replace("\r", "");
                Journal3SubLink = Journal3SubLink.Replace("\n", "");
                Journal3SubLink = Journal3SubLink.Replace(" ", "");
                Response.Redirect(Journal3SubLink);
            }
        }

        protected void Journal1Details_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(Journal1Link))
            {

            }
            else
            {

                Journal1Link = Journal1Link.Replace("\r", "");
                Journal1Link = Journal1Link.Replace("\n", "");
                Journal1Link = Journal1Link.Replace(" ", "");
                Response.Redirect(Journal1Link);
            }
        }

        protected void Journal1Submit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Journal1SubLink))
            {

            }
            else
            {

                Journal1SubLink = Journal1SubLink.Replace("\r", "");
                Journal1SubLink = Journal1SubLink.Replace("\n", "");
                Journal1SubLink = Journal1SubLink.Replace(" ", "");
                Response.Redirect(Journal1SubLink);
            }
        }
    }
}