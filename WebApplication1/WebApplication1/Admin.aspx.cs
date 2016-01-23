using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.Page
    {
        static List<string> keywords=new List<string>();
      
       static Journal[] journalData;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //OutputLabel.Text = "";
        }

        protected void RunButton_Click(object sender, EventArgs e)
        {
           

            // SET CATEGORIES

            setValues();

           



               
        }

       

        protected void UpdateButton_Click(object sender, EventArgs e)
        {

            setValues();

            UpdateData();

            Label1.Text = "<br> Click 'Show Data' to see changes";
        
        }

       
        protected void ShowButton_Click(object sender, EventArgs e)
        {
            
        }

        int GetDepth()
        {
            int d = 1;


            return d;
        }


        void UpdateData()
        {

            DataManager.SetJournalData(journalData);

        }

       void GetData()
        {

           
        }


        void setValues()
        {

           
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedValue == "Springer")
            {
                // set dropDown list2 options
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add(new ListItem("Journal","SD",true));

               

            }
            else if (DropDownList1.SelectedValue == "ACM")
            {
                // set dropDown list2 options
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add(new ListItem("Journal", "SD", true));

               

            }

            else if (DropDownList1.SelectedValue == "Elsevier")
            {
                // set dropDown list2 options
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add(new ListItem("Journal", "SD", true));

               

            }



        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        
        }
    }
}