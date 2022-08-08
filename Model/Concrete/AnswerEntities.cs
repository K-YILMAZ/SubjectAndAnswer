using Model.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Model.Concrete
{
    public class AnswerEntities :User
    {
 
        [StringLength(200)]
        public string Content { get; set; }
        public long SubjectId { get; set; }

    }
}
