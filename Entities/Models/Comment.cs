using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Text { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }
        public string UserID { get; set; }
        

        [ForeignKey("SubjectID")]
        public Subject Subject { get; set; }
        public int? SubjectID { get; set; }
    }
}