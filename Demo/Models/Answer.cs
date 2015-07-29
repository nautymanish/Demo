using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    [Table("Answer")]
    public partial class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(10)]
        public string Text { get; set; }

        public int QuestionId { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }
        [ForeignKey("AspNetUserId")]
        public virtual AspNetUsers AspNetUsers { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}