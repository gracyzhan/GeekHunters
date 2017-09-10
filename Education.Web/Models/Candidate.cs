using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Web
{
    
    public class Candidate : ICandidate
    {
        public string FirstName
        {
            get;set;
        }

       
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public int ID
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }
    }
}