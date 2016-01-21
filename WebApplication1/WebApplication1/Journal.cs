using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication1
{
    public class Journal
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public string Keywords { get; set; }

        public string Website { get; set; }

        public string Submit { get; set; }



        public Journal()
        {

            Name = "";
            Link = "";
            Keywords = "";
            Website = "";
            Submit = "";
        
        
        }

    }
}
