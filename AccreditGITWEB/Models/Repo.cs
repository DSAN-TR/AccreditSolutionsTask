using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccreditGITWEB.Models
{
    public class Repo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string description { get; set; }
        public int stargazers_count { get; set; }
    }
}