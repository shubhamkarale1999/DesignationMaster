using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignationMaster.Models
{
    [Table("tbl_Designation")]
    public class DesignationMasterViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "College")]
        public int? CollegeId { get; set; }

        [ForeignKey("CollegeId")]
        public CollegeViewMode? College { get; set; }

        [Display(Name = "Designation Code")]
        public int? DesignationCode { get; set; }

        [Required]
        [Display(Name = "Designation Acronym")]
        [Column(TypeName = "varchar(50)")]
        public string DesignationAcronym { get; set; }

        [Required]
        [Display(Name = "Designation Name")]
        [Column(TypeName = "varchar(150)")]
        public string DesignationName { get; set; }

        [Display(Name = "Stream")]
        public int? StreamId { get; set; }

        [ForeignKey("StreamId")]
        public StreamViewModel? Stream { get; set; }

        [Required]
        [Display(Name = "Roles & Responsibilities")]
        [Column(TypeName = "varchar(500)")]
        public string RolesAndResponsibilities { get; set; }

        [Display(Name = "Created By")]
        [Column(TypeName = "varchar(150)")]
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Updated By")]
        [Column(TypeName = "varchar(150)")]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Status { get; set; }

        public string? StaffType { get; set; } 

        public string? Priority { get; set; }
    }
}
