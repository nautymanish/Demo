using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    //[Table("Question")]
    //public class Question
    //{
    //    public int QuestionId { get; set; }
    //    public string QuestionText { get; set; }
        
    //    public virtual string AspNetUsersId { get; set; }
    //    [ForeignKey("AspNetUsersId")]
    //    public virtual AspNetUsers User { get; set; }

    //}
    [Table("Question")]
    public partial class Question
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Text { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }
        [ForeignKey("AspNetUserId")]
        public virtual AspNetUsers AspNetUser { get; set; }
    }
}