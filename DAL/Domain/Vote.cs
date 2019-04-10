
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain {
    public class Vote {
        [Key]
        [Column(Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        
        [Required]
        public short Value { get; set; }
        
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Time { get; set; }
        
        [Required]
        public long Ip { get; set; }
    }
}