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

        static Journal[] journals; 
        protected void Page_Load(object sender, EventArgs e)
        {
            journals = DataManager.GetJournalData();
            JournalLinksBy.Visible = false;
            JournalTextbox.Visible = false;
            JournalValue.Visible = false;
            KeywordDropdown.Visible = false;
            KeywordTextbox.Visible = false;
            KeywordValue.Visible = false;
        }

        protected void JournalDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JournalDrop.SelectedValue == "JournalLinks")
            {
                JournalLinksBy.Visible = true;
                JournalTextbox.Visible = true;
                JournalValue.Visible = true;
                KeywordDropdown.Visible = false;
                KeywordTextbox.Visible = false;
                KeywordValue.Visible = false;
            
            
            }
            else if (JournalDrop.SelectedValue == "JournalHome")
            {
                JournalLinksBy.Visible = false;
                JournalTextbox.Visible = false;
                JournalValue.Visible = false;
                KeywordDropdown.Visible = true;
                KeywordTextbox.Visible = true;
                KeywordValue.Visible = true;


            }
            else
            { 
            
            
            
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id=0;

            if (DropDownList1.SelectedValue == "Springer")
            {
                DropDownList2.Items.Clear();
                foreach (Journal j in journals)
                {

                    if (j.Website == "Springer")
                    { 
                    
                    
                    DropDownList2.Items.Add(new ListItem(j.Name,j.Website+id.ToString()));
                    
                    }
                
                }
            
            }
            else if (DropDownList1.SelectedValue == "Emerald")
            {

                DropDownList2.Items.Clear();
                foreach (Journal j in journals)
                {

                    if (j.Website == "Emerald")
                    {


                        DropDownList2.Items.Add(new ListItem(j.Name, j.Website + id.ToString()));

                    }

                }

            }
            else if (DropDownList1.SelectedValue == "ACM")
            {
                DropDownList2.Items.Clear();
                foreach (Journal j in journals)
                {

                    if (j.Website == "ACM")
                    {


                        DropDownList2.Items.Add(new ListItem(j.Name, j.Website + id.ToString()));

                    }

                }
            }
            else
            {

                DropDownList2.Items.Clear();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (JournalDrop.SelectedValue == "JournalHome")
            {

                string keys = Crawler.Keywords(UrlText.Text, KeywordDropdown.SelectedValue.ToString(), KeywordTextbox.Text);
            
            }
            if (JournalDrop.SelectedValue == "JournalHome")
            {

                string[] links = Crawler.JournalLinks(UrlText.Text, JournalLinksBy.SelectedValue.ToString(), JournalTextbox.Text);


                foreach (string uri in links)
                {


                    string keys = Crawler.Keywords(uri, KeywordDropdown.SelectedValue.ToString(), KeywordTextbox.Text);
                    
                
                }
            
            }
        }
    }
}