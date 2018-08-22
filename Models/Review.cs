using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTauranter.Models
{
    // public class User
    // {
    //     // public int Id { get; set; }
    // }

    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string User { get; set; }

        [Required]
        [MinLength(2)]
        public string Restaurant { get; set; }

        [Required]
        [MinLength(11)]
        // [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        // [Display("1")]
        public int Stars { get; set; }

        [Required]
        [Range(DataType(DateTime.Date), "1/1/2000", "DateTime.Today")]
        //Cannot be in the future - [Date(< DateTime.Today)]?
        public DateTime VisitDate { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Update_at { get; set; }
    }
}