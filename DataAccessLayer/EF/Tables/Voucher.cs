using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Tables
{
    public class Voucher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Code { get; set; }

        [Range(0, 1000)]
        public double? DiscountAmount { get; set; }

        [Range(0, 100)]
        public double? DiscountPercent { get; set; }

        public bool IsUsed { get; set; }
    }
}
