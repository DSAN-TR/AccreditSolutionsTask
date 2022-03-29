using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccreditGITWEB.Models
{
    public class User
    {
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string repos_url { get; set; }
        public string name { get; set; }

        public string location { get; set; }
    }
}