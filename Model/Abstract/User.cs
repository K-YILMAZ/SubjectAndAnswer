using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Abstract
{
    public abstract class User : IEntity
    {
      
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [StringLength(20), Column(Order = 1)]
        public string Name { get; set; }
        [StringLength(50), Column(Order = 2)]
        public string Surname { get; set; }
        [StringLength(50), Column(Order = 3)]
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
