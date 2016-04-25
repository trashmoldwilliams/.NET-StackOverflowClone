using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.Models
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string AnswerBody { get; set; }
        public int QuestionId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Question Question { get; set; }



    }
}
