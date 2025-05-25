using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignationMaster.Models
{
    [Table("tbl_CollegeMaster")]
    public class CollegeViewMode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "College Name")]
        [Column(TypeName = "varchar(200)")]
        public string CollegeName { get; set; }
    }
}
