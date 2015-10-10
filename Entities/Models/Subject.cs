using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}