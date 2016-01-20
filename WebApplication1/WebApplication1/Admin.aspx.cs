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
                keywords = JournalLinks.FromACM(source, GetDepth());
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

            if (source == Searcher.Springer.ComputerScience)
            {

                DataManager.SetData(TableNames.Springer.ComputerScience, keywords);

            }
            if (source == Searcher.Springer.Mathematics)
            {

                DataManager.SetData(TableNames.Springer.Mathematics, keywords);

            }
            if (source == Searcher.Springer.Engineering)
            {

                DataManager.SetData(TableNames.Springer.Engineering, keywords);

            }
            if (source == Searcher.Springer.AI)
            {

                DataManager.SetData(TableNames.Springer.AI, keywords);

            }
            if (source == Searcher.Springer.Algebra)
            {

                DataManager.SetData(TableNames.Springer.Algebra, keywords);

            }
            if (source == Searcher.Springer.ComputerNetworks)
            {

                DataManager.SetData(TableNames.Springer.ComputerNetworks, keywords);

            }
            if (source == Searcher.Springer.InformationSystemsAndApplications)
            {

                DataManager.SetData(TableNames.Springer.InformationSystems, keywords);

            }
            if (source == Searcher.Springer.MathematicalAndComputationalPhysics)
            {

                DataManager.SetData(TableNames.Springer.MathematicalAndComputationalPhysics, keywords);

            }
            if (source == Searcher.Springer.TheoreticalComputerScience)
            {

                DataManager.SetData(TableNames.Springer.TheoriticalComputerScience, keywords);

            }
            if (source == Searcher.ACM.AI)
            {

                DataManager.SetData(TableNames.ACM.AI, keywords);


            }
            if (source == Searcher.ACM.ComputerGraphics)
            {

                DataManager.SetData(TableNames.ACM.ComputerGraphics, keywords);


            }
            if (source == Searcher.ACM.ComputerNetworks)
            {

                DataManager.SetData(TableNames.ACM.ComputerNetworks, keywords);


            }
            if (source == Searcher.ACM.ComputerVision)
            {

                DataManager.SetData(TableNames.ACM.ComputerVision, keywords);


            }
            if (source == Searcher.ACM.DistributedDatabase)
            {

                DataManager.SetData(TableNames.ACM.DistributedDatabase, keywords);


            }
            if (source == Searcher.ACM.ParallelComputing)
            {

                DataManager.SetData(TableNames.ACM.ParallelComputing, keywords);


            }
            if (source == Searcher.ACM.SoftwareEngineering)
            {

                DataManager.SetData(TableNames.ACM.SoftwareEngineering, keywords);


            }
            if (source == Searcher.ACM.TheoryOfComputerScience)
            {

                DataManager.SetData(TableNames.ACM.TheoryOfComputerScience, keywords);


            }
            if (source == Searcher.ACM.CloudComputing)
            {

                DataManager.SetData(TableNames.ACM.CloudComputing, keywords);

            }
            if (source == Searcher.Elsevier.AI)
            {

                DataManager.SetData(TableNames.Elsevier.AI, keywords);


            }
            if (source == Searcher.Elsevier.ComputerGraphics)
            {

                DataManager.SetData(TableNames.Elsevier.ComputerGraphics, keywords);


            }
            if (source == Searcher.Elsevier.ComputerNetworks)
            {

                DataManager.SetData(TableNames.Elsevier.ComputerNetworks, keywords);


            }
            if (source == Searcher.Elsevier.ComputerVision)
            {

                DataManager.SetData(TableNames.Elsevier.ComputerVision, keywords);


            }
            if (source == Searcher.Elsevier.DistributedDatabase)
            {

                DataManager.SetData(TableNames.Elsevier.DistributedDatabase, keywords);


            }
            if (source == Searcher.Elsevier.ParallelComputing)
            {

                DataManager.SetData(TableNames.Elsevier.ParallelComputing, keywords);


            }
            if (source == Searcher.Elsevier.SoftwareEngineering)
            {

                DataManager.SetData(TableNames.Elsevier.SoftwareEngineering, keywords);


            }
            if (source == Searcher.Elsevier.TheoryOfComputerScience)
            {

                DataManager.SetData(TableNames.Elsevier.TheoryOfComputerScience, keywords);


            }
            if (source == Searcher.Elsevier.CloudComputing)
            {

                DataManager.SetData(TableNames.Elsevier.CloudComputing, keywords);

            }


        }

        List<string> GetData()
        {

            List<string> tempList = new List<string>();
            if (source == Searcher.Springer.ComputerScience)
            {

                tempList = DataManager.GetData(TableNames.Springer.ComputerScience);


            }
            if (source == Searcher.Springer.Mathematics)
            {

                tempList = DataManager.GetData(TableNames.Springer.Mathematics);

            }
            if (source == Searcher.Springer.Engineering)
            {

                tempList = DataManager.GetData(TableNames.Springer.Engineering);

            }
            if (source == Searcher.Springer.AI)
            {

                tempList = DataManager.GetData(TableNames.Springer.AI);

            }
            if (source == Searcher.Springer.Algebra)
            {

                tempList = DataManager.GetData(TableNames.Springer.Algebra);

            }
            if (source == Searcher.Springer.ComputerNetworks)
            {

                tempList = DataManager.GetData(TableNames.Springer.ComputerNetworks);

            }
            if (source == Searcher.Springer.InformationSystemsAndApplications)
            {

                tempList = DataManager.GetData(TableNames.Springer.InformationSystems);

            }
            if (source == Searcher.Springer.MathematicalAndComputationalPhysics)
            {

                tempList = DataManager.GetData(TableNames.Springer.MathematicalAndComputationalPhysics);

            }
            if (source == Searcher.Springer.TheoreticalComputerScience)
            {

                tempList = DataManager.GetData(TableNames.Springer.TheoriticalComputerScience);

            }
            if (source == Searcher.ACM.AI)
            {

                tempList = DataManager.GetData(TableNames.ACM.AI);


            }
            if (source == Searcher.ACM.ComputerGraphics)
            {

                tempList = DataManager.GetData(TableNames.ACM.ComputerGraphics);


            }
            if (source == Searcher.ACM.ComputerNetworks)
            {

                tempList = DataManager.GetData(TableNames.ACM.ComputerNetworks);


            }
            if (source == Searcher.ACM.ComputerVision)
            {

                tempList = DataManager.GetData(TableNames.ACM.ComputerVision);


            }
            if (source == Searcher.ACM.DistributedDatabase)
            {

                tempList = DataManager.GetData(TableNames.ACM.DistributedDatabase);


            }
            if (source == Searcher.ACM.ParallelComputing)
            {

                tempList = DataManager.GetData(TableNames.ACM.ParallelComputing);


            }
            if (source == Searcher.ACM.SoftwareEngineering)
            {

                tempList = DataManager.GetData(TableNames.ACM.SoftwareEngineering);


            }
            if (source == Searcher.ACM.TheoryOfComputerScience)
            {

                tempList = DataManager.GetData(TableNames.ACM.TheoryOfComputerScience);


            }
            if (source == Searcher.ACM.CloudComputing)
            {

                tempList = DataManager.GetData(TableNames.ACM.CloudComputing);


            }
            if (source == Searcher.Elsevier.AI)
            {

                tempList = DataManager.GetData(TableNames.Elsevier.AI);


            }
            if (source == Searcher.Elsevier.ComputerGraphics)
            {

                tempList = DataManager.GetData(TableNames.Elsevier.ComputerGraphics);


            }
            if (source == Searcher.Elsevier.ComputerNetworks)
            {

                tempList = DataManager.GetData(TableNames.Elsevier.ComputerNetworks);


            }
            if (source == Searcher.Elsevier.ComputerVision)
            {

                tempList = DataManager.GetData(TableNames.Elsevier.ComputerVision);


            }
            if (source == Searcher.Elsevier.DistributedDatabase)
            {

                tempList = DataManager.GetData(TableNames.Elsevier.DistributedDatabase);


            }
            if (source == Searcher.Elsevier.ParallelComputing)
            {

                tempList = DataManager.GetData(TableNames.Elsevier.ParallelComputing);


            }
            if (source == Searcher.Elsevier.SoftwareEngineering)
            {

                tempList = DataManager.GetData(TableNames.Elsevier.SoftwareEngineering);


            }
            if (source == Searcher.Elsevier.TheoryOfComputerScience)
            {

                tempList = DataManager.GetData(TableNames.Elsevier.TheoryOfComputerScience);


            }
            if (source == Searcher.Elsevier.CloudComputing)
            {

                tempList = DataManager.GetData(TableNames.Elsevier.CloudComputing);


            }

            return tempList;
        
        }


        void setValues()
        {

            if (DropDownList1.SelectedValue == "Springer")
            {
                if (DropDownList2.SelectedValue == "CS")
                {

                    source = Searcher.Springer.ComputerScience;

                }
                if (DropDownList2.SelectedValue == "MA")
                {

                    source = Searcher.Springer.Mathematics;

                }
                if (DropDownList2.SelectedValue == "AI")
                {

                    source = Searcher.Springer.AI;

                }
                if (DropDownList2.SelectedValue == "TC")
                {

                    source = Searcher.Springer.TheoreticalComputerScience;

                }
                if (DropDownList2.SelectedValue == "CN")
                {

                    source = Searcher.Springer.ComputerNetworks;

                }
                if (DropDownList2.SelectedValue == "AL")
                {

                    source = Searcher.Springer.Algebra;

                }
                if (DropDownList2.SelectedValue == "IS")
                {

                    source = Searcher.Springer.InformationSystemsAndApplications;

                }
                if (DropDownList2.SelectedValue == "CP")
                {

                    source = Searcher.Springer.MathematicalAndComputationalPhysics;

                }

            }
            if (DropDownList1.SelectedValue == "Elsevier")
            {
                if (DropDownList2.SelectedValue == "AI")
                {

                    source = Searcher.ACM.AI;

                }
                if (DropDownList2.SelectedValue == "SE")
                {

                    source = Searcher.ACM.SoftwareEngineering;

                }
                if (DropDownList2.SelectedValue == "CN")
                {

                    source = Searcher.ACM.ComputerNetworks;

                }
                if (DropDownList2.SelectedValue == "CC")
                {

                    source = Searcher.ACM.CloudComputing;

                }
                if (DropDownList2.SelectedValue == "CG")
                {

                    source = Searcher.ACM.ComputerGraphics;

                }
                if (DropDownList2.SelectedValue == "DD")
                {

                    source = Searcher.ACM.DistributedDatabase;

                }
                if (DropDownList2.SelectedValue == "TC")
                {

                    source = Searcher.ACM.TheoryOfComputerScience;

                }
                if (DropDownList2.SelectedValue == "PC")
                {

                    source = Searcher.ACM.ParallelComputing;

                }
                if (DropDownList2.SelectedValue == "CV")
                {

                    source = Searcher.ACM.ComputerVision;

                }
            }
                if (DropDownList1.SelectedValue == "Elsevier")
                {
                    if (DropDownList2.SelectedValue == "AI")
                    {

                        source = Searcher.Elsevier.AI;

                    }
                    if (DropDownList2.SelectedValue == "SE")
                    {

                        source = Searcher.Elsevier.SoftwareEngineering;

                    }
                    if (DropDownList2.SelectedValue == "CN")
                    {

                        source = Searcher.Elsevier.ComputerNetworks;

                    }
                    if (DropDownList2.SelectedValue == "CC")
                    {

                        source = Searcher.Elsevier.CloudComputing;

                    }
                    if (DropDownList2.SelectedValue == "CG")
                    {

                        source = Searcher.Elsevier.ComputerGraphics;

                    }
                    if (DropDownList2.SelectedValue == "DD")
                    {

                        source = Searcher.Elsevier.DistributedDatabase;

                    }
                    if (DropDownList2.SelectedValue == "TC")
                    {

                        source = Searcher.Elsevier.TheoryOfComputerScience;

                    }
                    if (DropDownList2.SelectedValue == "PC")
                    {

                        source = Searcher.Elsevier.ParallelComputing;

                    }
                    if (DropDownList2.SelectedValue == "CV")
                    {

                        source = Searcher.Elsevier.ComputerVision;

                    }



                
            }       
        
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