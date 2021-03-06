﻿using System;
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

        float Strictness = 20;


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
            string names = "";
            foreach (Journal j in journals)
            { 
            
            float match=Comparator.GetStatsSpringer(j.Keywords.Split(splitter,StringSplitOptions.RemoveEmptyEntries),userKeywords);

                if (match >= Strictness)
                {
                    DropDownList1.Items.Add(new ListItem(j.Name, j.Link + "^" + j.Submit));
                    DropDownList1.SelectedIndex = DropDownList1.Items.Count - 1;
                   
                   
                    Springer = j;
                    names += j.Name + "<br>";  // remove this line
                    // add journal name as text here (html plain text or asp label)
                    // add new button here
                    // add button in div (see html for journal SPRINGER names div)
                    // add onClick event by button.onClick+=newOnclickhandler;
                    // add response.redirect(j.link); code to that event , it will redirect to that link
                    // SEE EXISTING onClick EVENTS FOR LINKS CORRECTION
                 }
            
            }

            if (String.IsNullOrEmpty(names))
                Journal1Details.Text = "No match found";

        
        }

        void MatchEmerald(string[] userKeywords)
        {

            Journal Emerald= new Journal();
            string[] splitter = { ".", " ", ":", ",", ";", "'", "\"", "(", ")" };
            Journal[] journals = DataManager.GetEmeraldData();
            float mostmatch = 0;
            string names = "";
            foreach (Journal j in journals)
            {

                float match = Comparator.GetStatsEmerald(j.Keywords.Split(splitter, StringSplitOptions.RemoveEmptyEntries), userKeywords);

                if (match >= Strictness)
                {

                    DropDownList2.Items.Add(new ListItem(j.Name, j.Link + "^" + j.Submit));
                    DropDownList2.SelectedIndex = DropDownList2.Items.Count - 1;
                   
                   
                     Emerald = j;
                    names += j.Name + "<br>"; // remove this line
                    // add journal name as text here (html plain text or asp label)
                    // add new button here
                    // add button in div (see html for journal EMERALD names div)
                    // add onClick event by button.onClick+=newOnclickhandler;
                    // add response.redirect(j.link); code to that event , it will redirect to that link
                    // SEE EXISTING onClick EVENTS FOR LINKS CORRECTION

                }

            }

            if (String.IsNullOrEmpty(names))
                Journal2Details.Text = "No match found";


        }

        void MatchACMandOther(string[] userKeywords)
        {
            

            string names = "";
            Journal ACM = new Journal();
            string[] splitter = { ".", " ", ":", ",", ";", "'", "\"", "(", ")" };
            Journal[] journals = DataManager.GetACMData();
            float mostmatch = 0;
            foreach (Journal j in journals)
            {

                float match = Comparator.GetStatsACM(j.Keywords.Split(splitter, StringSplitOptions.RemoveEmptyEntries), userKeywords);

                if (match >= Strictness)

                  
                    
                    DropDownList3.Items.Add(new ListItem(j.Name, j.Link+"^"+j.Submit));
                    DropDownList3.SelectedIndex = DropDownList3.Items.Count - 1;
                    ACM = j;
                    names += j.Name + "<br>";  // remove this line
                    // add journal name as text here (html plain text or asp label)
                    // add new button here
                    // add button in div (see html for journal ACM names div)
                    // add onClick event by button.onClick+=newOnclickhandler;
                    // add response.redirect(j.link); code to that event , it will redirect to that link
                    // SEE EXISTING onClick EVENTS FOR LINKS CORRECTION
                }

            if (String.IsNullOrEmpty(names))
                Journal3Details.Text = "No match found";





            }
            
       
           

        


        void RunAnalysis()
        {


            string keywords = TextBox2.Text;

           
            string[] stringSeparators = new string[] { "," };


            string[] s = keywords.Split(stringSeparators,StringSplitOptions.RemoveEmptyEntries);



            MatchACMandOther(s);
            MatchEmerald(s);
            MatchSpringer(s);

           
        }


        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

           
        }

       

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

            string suggestedWords = String.Join(",",Comparator.PrepareUserKeywords(TextBox1.Text));
            //suggestedWords = Comparator.ProcessWords(suggestedWords);
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

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string[] splitter = { "^" };

                string[] links = DropDownList3.SelectedValue.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                Journal3SubLink = links[1];
                Journal3Link = links[0];
            }
            catch (Exception ed)
            { 
            
            
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] splitter = { "^" };

                string[] links = DropDownList2.SelectedValue.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                Journal2SubLink = links[1];
                Journal2Link = links[0];
            }
            catch (Exception ed)
            {


            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] splitter = { "^" };

                string[] links = DropDownList1.SelectedValue.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                Journal1SubLink = links[1];
                Journal1Link = links[0];
            }
            catch (Exception ed)
            {


            }
        }
    }
}

