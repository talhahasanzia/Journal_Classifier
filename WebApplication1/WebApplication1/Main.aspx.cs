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

       

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {


            RunAnalysis();
           
         
        }



        void RunAnalysis()
        {



            string keywords = TextBox2.Text;

            keywords = Comparator.ProcessWords(keywords);
            string[] stringSeparators = new string[] { "," };
            
            
            Journal[] journalData = DataManager.GetJournalData();

            Journal Springer = new Journal();
            Journal ACM = new Journal();
            Journal Emerald = new Journal();


            float springerMatch=0, acmMatch=0, emeraldMatch=0;

            foreach (Journal j in journalData)
            {

                if (j.Website == "Springer")
                {

                    string[] keys = keywords.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    string[] keySyn = Comparator.GetSynonyms(keys.ToList()).ToArray();

                    string[] journalKeys = j.Keywords.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    string[] jourSyn = Comparator.GetSynonyms(journalKeys.ToList()).ToArray();


                    float match = Comparator.GetStats(jourSyn, keySyn);

                    if (match > springerMatch)
                    {

                        springerMatch = match;
                        Springer = j;
                    
                    
                    }
                
                
                }
                if (j.Website == "ACM")
                {


                    string[] keys = keywords.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    string[] keySyn = Comparator.GetSynonyms(keys.ToList()).ToArray();

                    string[] journalKeys = j.Keywords.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    string[] jourSyn = Comparator.GetSynonyms(journalKeys.ToList()).ToArray();


                    float match = Comparator.GetStats(jourSyn, keySyn);

                    if (match > acmMatch)
                    {

                        acmMatch = match;
                        ACM = j;


                    }

                }
                if (j.Website == "Emerald")
                {


                    string[] keys = keywords.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    string[] keySyn = Comparator.GetSynonyms(keys.ToList()).ToArray();

                    string[] journalKeys = j.Keywords.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    string[] jourSyn = Comparator.GetSynonyms(journalKeys.ToList()).ToArray();


                    float match = Comparator.GetStats(jourSyn, keySyn);

                    if (match > emeraldMatch)
                    {

                        emeraldMatch = match;
                       Emerald = j;


                    }

                }
            
            
            
            }
        
        
        
        
        }


        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

           
        }

       

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
            string suggestedWords = Comparator.ProcessWords(TextBox1.Text);
            suggest.Text = "Suggested Keywords: " + suggestedWords;


           
            
        }
    }
}