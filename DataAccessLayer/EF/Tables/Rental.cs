using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Tables
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReturnDate { get; set; }

        public double OriginalCost { get; set; }

        public double DiscountAmount { get; set; }

        public double LateFeeAmount { get; set; }

        public double FinalCost { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Status { get; set; } // active, completed, cancelled

        public bool EmailSent { get; set; }
        

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }


        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


        [ForeignKey("Voucher")]
        public int? VoucherId { get; set; }
        public virtual Voucher Voucher { get; set; }

    }
}
