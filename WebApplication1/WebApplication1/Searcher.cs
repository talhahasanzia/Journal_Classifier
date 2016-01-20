using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Searcher
    {
        // THIS CLASS DEFINES CATEGORIES


        public class Springer
        {
            public static int page;
            public static string ComputerScience = "http://link.springer.com/search/page/"+page+"?facet-discipline=%22Computer+Science%22&facet-content-type=%22Article%22&query=";
            public static string Engineering = "http://link.springer.com/search/page/" + page + "?facet-discipline=%22Engineering%22&facet-content-type=%22Article%22&query=";
            public static string Mathematics = "http://link.springer.com/search/page/"+page+"?facet-discipline=%22Mathematics%22&facet-content-type=%22Article%22&query=";
			public static string TheoreticalComputerScience = "http://link.springer.com/search/page/"+page+"?facet-discipline=%22Computer+Science%22&facet-sub-discipline=%22Theoretical+Computer+Science%22&facet-content-type=%22Article%22&query=";
			public static string AI = "http://link.springer.com/search/page/"+page+"?facet-discipline=%22Computer+Science%22&facet-sub-discipline=%22AI%22&facet-content-type=%22Article%22&query=";
        	public static string ComputerNetworks = "http://link.springer.com/search/page/"+page+"?facet-discipline=%22Computer+Science%22&facet-sub-discipline=%22Communication+Networks%22&facet-content-type=%22Article%22&query=";
			public static string InformationSystemsAndApplications = "http://link.springer.com/search/page/"+page+"?facet-discipline=%22Computer+Science%22&facet-sub-discipline=%22Information+Systems+and+Applications%22&facet-content-type=%22Article%22&query=";
			
			public static string Algebra = "http://link.springer.com/search/page/"+page+"?facet-discipline=%22Mathematics%22&facet-sub-discipline=%22Algebra%22&facet-content-type=%22Article%22&query=";
			public static string MathematicalAndComputationalPhysics = "http://link.springer.com/search/page/"+page+"?facet-discipline=%22Mathematics%22&facet-sub-discipline=%22Theoretical%2C+Mathematical+%26+Computational+Physics%22&facet-content-type=%22Article%22&query=";
		//test commit
		
		}
        public class ACM
        {
            public static int page;   
            public static string AI = "http://dl.acm.org/results.cfm?query=%28%252Bartificial%20%252Bintelligence%29&start="+page*20+"&filtered=&within=owners%2Eowner%3DACM&dte=&bfr=&srt=_score";
            public static string SoftwareEngineering = "http://dl.acm.org/results.cfm?query=%28%252Bsoftware%20%252Bengineering%29&start="+page*20+"&filtered=&within=owners%2Eowner%3DACM&dte=&bfr=&srt=_score";
            public static string TheoryOfComputerScience = "http://dl.acm.org/results.cfm?query=%28%252BTheory%20%252Bof%20%252Bcomputer%20%252Bscience%29&start="+page*20+"&filtered=&within=owners%2Eowner%3DACM&dte=&bfr=&srt=_score";
            public static string ComputerGraphics = "http://dl.acm.org/results.cfm?query=%28%252Bcomputer%20%252Bgraphics%29&start="+page*20+"&filtered=&within=owners%2Eowner%3DACM&dte=&bfr=&srt=_score";
            public static string CloudComputing = "http://dl.acm.org/results.cfm?query=%28%252Bcloud%20%252Bcomputing%29&start="+page*20+"&filtered=&within=owners%2Eowner%3DACM&dte=&bfr=&srt=_score";
            public static string ParallelComputing = "http://dl.acm.org/results.cfm?query=%28%252Bparallel%20%252Bcomputing%29&start="+page*20+"&filtered=&within=owners%2Eowner%3DACM&dte=&bfr=&srt=_score";
            public static string DistributedDatabase = "http://dl.acm.org/results.cfm?query=%28%252Bdistributed%20%252Bdatabase%29&start="+page*20+"&filtered=&within=owners%2Eowner%3DACM&dte=&bfr=&srt=_score";
            public static string ComputerVision = "http://dl.acm.org/results.cfm?query=%28%252Bcomputer%20%252Bvision%29&start="+page*20+"&filtered=&within=owners%2Eowner%3DACM&dte=&bfr=&srt=_score";
            public static string ComputerNetworks = "http://dl.acm.org/results.cfm?query=%28%252Bcomputer%20%252Bnetworks%29&start=" + page * 20 + "&filtered=&within=owners%2Eowner%3DACM&dte=&bfr=&srt=_score";

        }

        public class Elsevier {

            public static int page;
            public static string AI = "http://www.sciencedirect.com/science?_ob=ArticleListURL&_method=tag&searchtype=a&refSource=search&_st=4&count=1000&sort=r&filterType=&_chunk=1&hitCount=2010&PREV_LIST=0&NEXT_LIST=2&view=c&md5=2e1e4bac2c3da20221e224440f5f9a40&_ArticleListID=-924283942&chunkSize=25&sisr_search=&TOTAL_PAGES=81&zone=exportDropDown&citation-type=RIS&format=cite-abs&bottomPaginationBoxChanged=&bottomPrev=%3C%3C+Previous&displayPerPageFlag=f&resultsPerPage=" + page;
            public static string SoftwareEngineering = "http://www.sciencedirect.com/science?_ob=ArticleListURL&_method=tag&searchtype=a&refSource=search&_st=4&count=1000&sort=r&filterType=&_chunk=1&hitCount=5871&PREV_LIST=0&NEXT_LIST=2&view=c&md5=015423b67844880836c8809618ae0de4&_ArticleListID=-924283210&chunkSize=25&sisr_search=&TOTAL_PAGES=235&zone=exportDropDown&citation-type=RIS&format=cite-abs&bottomPaginationBoxChanged=&bottomPrev=%3C%3C+Previous&displayPerPageFlag=f&resultsPerPage=" + page;
            public static string TheoryOfComputerScience = "http://www.sciencedirect.com/science?_ob=ArticleListURL&_method=tag&searchtype=a&refSource=search&_st=4&count=1000&sort=r&filterType=&_chunk=1&hitCount=7202&PREV_LIST=0&NEXT_LIST=2&view=c&md5=e82c1b5822da087630d4e4922d8f9658&_ArticleListID=-924286035&chunkSize=25&sisr_search=&TOTAL_PAGES=289&zone=exportDropDown&citation-type=RIS&format=cite-abs&bottomPaginationBoxChanged=&bottomPrev=%3C%3C+Previous&displayPerPageFlag=f&resultsPerPage=" + page;
            public static string ComputerGraphics = "http://www.sciencedirect.com/science?_ob=ArticleListURL&_method=tag&searchtype=a&refSource=search&_st=4&count=1000&sort=r&filterType=&_chunk=1&hitCount=1126&PREV_LIST=0&NEXT_LIST=2&view=c&md5=d81c02d00ce8467867a4a6d177427591&_ArticleListID=-924283439&chunkSize=25&sisr_search=&TOTAL_PAGES=46&zone=exportDropDown&citation-type=RIS&format=cite-abs&bottomPaginationBoxChanged=&bottomPrev=%3C%3C+Previous&displayPerPageFlag=f&resultsPerPage=" + page;
            public static string CloudComputing = "http://www.sciencedirect.com/science?_ob=ArticleListURL&_method=tag&searchtype=a&refSource=search&_st=4&count=1000&sort=r&filterType=&_chunk=1&hitCount=1269&PREV_LIST=0&NEXT_LIST=2&view=c&md5=1d71b6524b59f3ce323b8d53a288b00a&_ArticleListID=-924317608&chunkSize=25&sisr_search=&TOTAL_PAGES=51&zone=exportDropDown&citation-type=RIS&format=cite-abs&bottomPaginationBoxChanged=&bottomPrev=%3C%3C+Previous&displayPerPageFlag=f&resultsPerPage=" + page;
            public static string ParallelComputing = "http://www.sciencedirect.com/science?_ob=ArticleListURL&_method=tag&searchtype=a&refSource=search&_st=4&count=1000&sort=r&filterType=&_chunk=1&hitCount=3700&PREV_LIST=0&NEXT_LIST=2&view=c&md5=9b64187abd5861f17857745a6ad35e15&_ArticleListID=-924316527&chunkSize=25&sisr_search=&TOTAL_PAGES=148&zone=exportDropDown&citation-type=RIS&format=cite-abs&bottomPaginationBoxChanged=&bottomPrev=%3C%3C+Previous&displayPerPageFlag=f&resultsPerPage=" + page;
            public static string DistributedDatabase = "http://www.sciencedirect.com/science?_ob=ArticleListURL&_method=tag&searchtype=a&refSource=search&_st=4&count=1000&sort=r&filterType=&_chunk=1&hitCount=1771&PREV_LIST=0&NEXT_LIST=2&view=c&md5=8fd2fb743a766c8fa787fadb1c9da73d&_ArticleListID=-924319961&chunkSize=25&sisr_search=&TOTAL_PAGES=71&zone=exportDropDown&citation-type=RIS&format=cite-abs&bottomPaginationBoxChanged=&bottomPrev=%3C%3C+Previous&displayPerPageFlag=f&resultsPerPage=" + page;
            public static string ComputerVision = "http://www.sciencedirect.com/science?_ob=ArticleListURL&_method=tag&searchtype=a&refSource=search&_st=4&count=1000&sort=r&filterType=&_chunk=1&hitCount=1938&PREV_LIST=0&NEXT_LIST=2&view=c&md5=f144158f86576a4a6a9dd2ac83d1fe8c&_ArticleListID=-924320079&chunkSize=25&sisr_search=&TOTAL_PAGES=78&zone=exportDropDown&citation-type=RIS&format=cite-abs&bottomPaginationBoxChanged=&bottomPrev=%3C%3C+Previous&displayPerPageFlag=f&resultsPerPage=" + page;
            public static string ComputerNetworks = "http://www.sciencedirect.com/science?_ob=ArticleListURL&_method=tag&searchtype=a&refSource=search&_st=4&count=1000&sort=r&filterType=&_chunk=1&hitCount=8222&PREV_LIST=0&NEXT_LIST=2&view=c&md5=6e8d98ebae24b71e1b9dd920cb49068d&_ArticleListID=-924322559&chunkSize=25&sisr_search=&TOTAL_PAGES=329&zone=exportDropDown&citation-type=RIS&format=cite-abs&bottomPaginationBoxChanged=&bottomPrev=%3C%3C+Previous&displayPerPageFlag=f&resultsPerPage=" + page;



        }

    }
}