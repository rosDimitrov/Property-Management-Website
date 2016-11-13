using System.ComponentModel.DataAnnotations;

namespace Property_Management.Models
{
    public class EditNewsViewModel
    {

        public int NewsId { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Display(Name = "Featured")]
        public bool IsFeatured { get; set; }

    }
}