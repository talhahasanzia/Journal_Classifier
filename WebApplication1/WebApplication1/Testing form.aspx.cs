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

           
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {



            Journal[] journals = DataManager.GetJournalData();

            for (int i = 0; i < journals.Length; i++)
            {

                Label1.Text += "<br/>" + journals[i].Name;
            
            }
           
        }
    }
}