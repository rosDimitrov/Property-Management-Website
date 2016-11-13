using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Property_Management.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string PictureString { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public string Preview { get; set; }

        [Display(Name ="Featured")]
        public bool IsFeatured { get; set; }
        [Display(Name = "Create Date")]
        public DateTime CreatedOn { get; set;}
    }
}