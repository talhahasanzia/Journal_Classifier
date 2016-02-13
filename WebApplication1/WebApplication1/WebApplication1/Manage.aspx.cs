using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Manage : System.Web.UI.Page
    {
        static Journal tempJournal = new Journal();
        static Journal[] journals; 
        protected void Page_Load(object sender, EventArgs e)
        {
            journals = DataManager.GetJournalData();
            

            LogLabel.Text = "Links";

            
            //JournalLinksBy.Visible = false;
            //JournalTextbox.Visible = false;
            //JournalValue.Visible = false;
            //KeywordDropdown.Visible = false;
            //KeywordTextbox.Visible = false;
            //KeywordValue.Visible = false;
            //HeadingText.Enabled = false;
            //HeadingValue.Enabled = false;
            //SubmitText.Enabled = false;
            //SubmitValue.Enabled = false;
            //Label3.Enabled = false;
            //Label4.Enabled = false;
        }

        protected void JournalDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogLabel.Text = "Links";
            if (JournalDrop.SelectedValue == "JournalLinks")
            {
                JournalLinksBy.Visible = true;
                JournalTextbox.Visible = true;
                JournalValue.Visible = true;
                KeywordDropdown.Visible = false;
                KeywordTextbox.Visible = false;
                KeywordValue.Visible = false;
                HeadingText.Enabled = false;
                HeadingValue.Enabled = false;
                SubmitText.Enabled = false;
                SubmitValue.Enabled = false;
                Label3.Enabled = false;
                Label4.Enabled = false;
            
            
            }
            else if (JournalDrop.SelectedValue == "JournalHome")
            {
                JournalLinksBy.Visible = false;
                JournalTextbox.Visible = false;
                JournalValue.Visible = false;
                KeywordDropdown.Visible = true;
                KeywordTextbox.Visible = true;
                KeywordValue.Visible = true;
                HeadingText.Enabled = true;
                HeadingValue.Enabled = true;
                SubmitText.Enabled = true;
                SubmitValue.Enabled = true;
                Label3.Enabled = true;
                Label4.Enabled = true;


            }
            else
            { 
            
            
            
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogLabel.Text = "Links";
            int id=0;

            if (DropDownList1.SelectedValue == "Springer")
            {
                JournalList.Items.Clear();
                foreach (Journal j in journals)
                {

                    if (j.Website == "Springer")
                    {


                        JournalList.Items.Add(new ListItem(j.Name, j.Link));
                    
                    }
                
                }
            
            }
            else if (DropDownList1.SelectedValue == "Emerald")
            {

                JournalList.Items.Clear();
                foreach (Journal j in journals)
                {

                    if (j.Website == "Emerald")
                    {


                        JournalList.Items.Add(new ListItem(j.Name,j.Link));

                    }

                }

            }
            else if (DropDownList1.SelectedValue == "ACM")
            {
                JournalList.Items.Clear();
                foreach (Journal j in journals)
                {

                    if (j.Website == "ACM")
                    {


                        JournalList.Items.Add(new ListItem(j.Name,j.Link));

                    }

                }
            }
            else if (DropDownList1.SelectedValue == "Other")
            {
                JournalList.Items.Clear();
                foreach (Journal j in journals)
                {

                    if (j.Website == "Other")
                    {


                        JournalList.Items.Add(new ListItem(j.Name, j.Link));

                    }

                }
            }
            else
            {

                JournalList.Items.Clear();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                LogLabel.Text = "Links";
                if (JournalDrop.SelectedValue == "abc" || JournalLinksBy.SelectedValue == "abc" || HeadingValue.SelectedValue == "abc" || KeywordDropdown.SelectedValue == "abc" || SubmitValue.SelectedValue == "abc"
                    || String.IsNullOrEmpty(UrlText.Text) || String.IsNullOrEmpty(KeywordsText.Text) || String.IsNullOrEmpty(SubmitText.Text) || String.IsNullOrEmpty(JournalTextbox.Text)
                    )
                {
                    LogLabel.Text = "   Data Missing, please make sure values are set correctly.";
                }
                else
                {
                    if (JournalDrop.SelectedValue == "JournalHome")
                    {

                        Journal journal = new Journal();

                        journal.Name = Crawler.Name(UrlText.Text, HeadingValue.SelectedValue, HeadingText.Text);
                        journal.Link = UrlText.Text;
                        journal.Keywords = Crawler.Keywords(journal.Link, KeywordDropdown.SelectedValue, KeywordsText.Text);
                        journal.Website = "Other";
                        journal.Submit = Crawler.SubmitLink(journal.Link, SubmitValue.SelectedValue, SubmitText.Text);


                        HyperLink1.NavigateUrl = journal.Link;

                        Name.Text = journal.Name;

                        Website.Text = journal.Website;
                        KeywordsText.Text = journal.Keywords;
                        tempJournal = journal;

                    }
                    if (JournalDrop.SelectedValue == "JournalLinks")
                    {

                        string[] links = Crawler.JournalLinks(UrlText.Text, JournalLinksBy.SelectedValue.ToString(), JournalTextbox.Text);

                        foreach (string link in links)
                        {


                            LogLabel.Text += "<br/>" + link;

                        }


                    }
                }
            }
            catch (Exception ec)
            {



            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void JournalList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogLabel.Text = "Links";
            string JournalLink = JournalList.SelectedValue;
            Journal j = new Journal();

            foreach (Journal journal in journals)
            {

                if (journal.Link == JournalLink)
                {


                    j = journal;
                    break;

                }


            }
            tempJournal = j;
            HyperLink1.NavigateUrl = j.Link;

            Name.Text = j.Name;

            Website.Text = j.Website;
            KeywordsText.Text = j.Keywords;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            try
            {
                Journal[] journal = new Journal[1];

                if (!(tempJournal.Link == ""))
                {
                    journal[0] = tempJournal;
                    DataManager.SetJournalData(journal);
                    LogLabel.Text = "Data Entered Successfully";
                }
                else
                {
                    throw new NullReferenceException();
                
                }

            }
            catch (Exception er)
            {

                LogLabel.Text = "Data Not Entered";
            
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string newKeywords = KeywordsText.Text;


            if (DataManager.UpdateKeywords(tempJournal.Name, newKeywords))
            {

                LogLabel.Text = "Updated keywords successfully.";
            }
            else
            {
                LogLabel.Text = "An error occured.";
            
            }

        }
    }
}