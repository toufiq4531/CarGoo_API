using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Tables
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public double DailyRate { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Status { get; set; }

        //public virtual ICollection<Rental> Rentals { get; set; }

    }
}
