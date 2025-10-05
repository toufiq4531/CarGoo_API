using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Tables
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Phone { get; set; }
    }
}
