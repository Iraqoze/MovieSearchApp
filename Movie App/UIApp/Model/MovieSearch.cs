using System;
using System.Collections.Generic;
using System.Text;

namespace UIApp.Model
{
	//Search Movie class, The result(json) of the search will be mapped to this properties.
    public class Search
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    public class MovieSearch
    {
        public IList<Search> search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }

}
