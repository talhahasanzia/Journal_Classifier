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
       static string source=Searcher.Springer.ComputerScience;
       static Journal[] journalData;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            OutputLabel.Text = "";
        }

        protected void RunButton_Click(object sender, EventArgs e)
        {
            keywords = new List<string>();

            // SET CATEGORIES

            setValues();

            if (DropDownList1.SelectedValue == "Springer")
                keywords = JournalLinks.FromSpringer(source, GetDepth());
            else if (DropDownList1.SelectedValue == "ACM")
                journalData= JournalLinks.FromACM();
            else if (DropDownList1.SelectedValue == "Elsevier")
                keywords = JournalLinks.FromElsevier(source, GetDepth());

            else
                OutputLabel.Text ="Error occurred";



                try
                {
                    foreach (string word in keywords)
                    {
                        OutputLabel.Text += "<br>" + word;

                    }
                }
                catch (Exception ecs)
                { 
                
                
                }
        }

       

        protected void UpdateButton_Click(object sender, EventArgs e)
        {

            setValues();

            UpdateData();

            OutputLabel.Text = "<br> Click 'Show Data' to see changes";
        
        }

       
        protected void ShowButton_Click(object sender, EventArgs e)
        {
            setValues();
           
            List<string> tempList=GetData();
            
            foreach (string word in tempList)
            {


                OutputLabel.Text += "<br>" + word;
            
            }
        }

        int GetDepth()
        {
            int d = 1;


            if (DropDownList3.SelectedValue == "x1")
            {

                d = 1;
                if (DropDownList1.SelectedValue == "Elsevier")
                    d = 25;


            }
            else if (DropDownList3.SelectedValue == "x2")
            {

                d = 2;
                if (DropDownList1.SelectedValue == "Elsevier")
                    d = 50;

            }
            else if (DropDownList3.SelectedValue == "x3")
            {

                d = 3;
                if (DropDownList1.SelectedValue == "Elsevier")
                    d = 100;

            }
            else
            {

                d = 1;
                if (DropDownList1.SelectedValue == "Elsevier")
                    d = 25; ;
            }

            return d;
        }


        void UpdateData()
        {

           

        }

        List<string> GetData()
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
                DropDownList2.Items.Add(new ListItem("Discipline","SD",true));

                DropDownList2.Items.Add(new ListItem("Computer Science","CS"));
                DropDownList2.Items.Add(new ListItem("Engineering", "EN"));
                DropDownList2.Items.Add(new ListItem("Mathematics", "MA"));
                DropDownList2.Items.Add(new ListItem("Artificial Intelligence", "AI"));
                DropDownList2.Items.Add(new ListItem("Computer Networks", "CN"));
                DropDownList2.Items.Add(new ListItem("Information Systems", "IS"));
                DropDownList2.Items.Add(new ListItem("Theoritical Computer Science", "TC"));
                DropDownList2.Items.Add(new ListItem("Algebra", "AL"));
                DropDownList2.Items.Add(new ListItem("Computational Physics", "CP"));

            }
            else if (DropDownList1.SelectedValue == "ACM")
            {
                // set dropDown list2 options
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add(new ListItem("Discipline", "SD", true));

                DropDownList2.Items.Add(new ListItem("Artificial Intelligence", "AI"));
                DropDownList2.Items.Add(new ListItem("Software Engineering", "SE"));
                DropDownList2.Items.Add(new ListItem("Computer Networks", "CN"));
                DropDownList2.Items.Add(new ListItem("Cloud Computing", "CC"));
                DropDownList2.Items.Add(new ListItem("Computer Graphics", "CG"));
                DropDownList2.Items.Add(new ListItem("Distributed Database", "DD"));
                DropDownList2.Items.Add(new ListItem("Theoritical Computer Science", "TC"));
                DropDownList2.Items.Add(new ListItem("Parallel Computing", "PC"));
                DropDownList2.Items.Add(new ListItem("Computer Vision", "CV"));

            }

            else if (DropDownList1.SelectedValue == "Elsevier")
            {
                // set dropDown list2 options
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add(new ListItem("Discipline", "SD", true));

                DropDownList2.Items.Add(new ListItem("Artificial Intelligence", "AI"));
                DropDownList2.Items.Add(new ListItem("Software Engineering", "SE"));
                DropDownList2.Items.Add(new ListItem("Computer Networks", "CN"));
                DropDownList2.Items.Add(new ListItem("Cloud Computing", "CC"));
                DropDownList2.Items.Add(new ListItem("Computer Graphics", "CG"));
                DropDownList2.Items.Add(new ListItem("Distributed Database", "DD"));
                DropDownList2.Items.Add(new ListItem("Theoritical Computer Science", "TC"));
                DropDownList2.Items.Add(new ListItem("Parallel Computing", "PC"));
                DropDownList2.Items.Add(new ListItem("Computer Vision", "CV"));

            }



        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        
        }
    }
}