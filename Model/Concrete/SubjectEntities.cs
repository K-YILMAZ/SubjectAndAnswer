using Model.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Model.Concrete
{
    public class SubjectEntities : User
    {
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Content { get; set; }
    }
}
