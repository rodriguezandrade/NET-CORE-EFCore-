using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(10)")]
        [DisplayName("Emp. Code")]
        public string Code { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Location")]
        public string OfficeLocation { get; set; }
    }
}
