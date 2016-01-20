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
           char[] trimmer={' '};
            
            List<string> keywords = TextBox2.Text.Split(',').ToList();

            List<string> filteredKeywords = new List<string>();

            foreach (string word in keywords)
            {

                string temp = word.ToLower();
                temp = temp.TrimEnd(trimmer);
                temp = temp.TrimStart(trimmer);
                filteredKeywords.Add(temp);
            
            
            }
           
            ; ;
        }
    }
}