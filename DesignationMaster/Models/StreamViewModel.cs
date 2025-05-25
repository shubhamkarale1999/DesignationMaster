using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignationMaster.Models
{
    [Table("tbl_StreamMaster")]
    public class StreamViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Stream Name")]
        [Column(TypeName = "varchar(100)")]
        public string StreamName { get; set; }
    }
}
