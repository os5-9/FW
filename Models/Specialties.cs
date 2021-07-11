using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustWork.Models
{
    [Table("Specialties")]
    public class Specialties
    {
        [Key]
        public int ID { get; set; }
        [StringLength(8)]
        public string Cypher { get; set; }
        [StringLength(120)]
        public string Description { get; set; }
        public int AmountStatements { get; set; }
        public int AmountPriority { get; set; }
    }
}
