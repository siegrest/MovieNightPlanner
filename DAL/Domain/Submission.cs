using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Domain {
    public class Submission {
        [Key] [Column(Order = 1)] public int Id { get; set; }

        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Time { get; set; }

        [MinLength(3), MaxLength(32)] public string AddedBy { get; set; }
        // todo: more strict constraints

        public double Score { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public int Episodes { get; set; }
        public string Duration { get; set; }
        public string Rating { get; set; }
        public string Synopsis { get; set; }
        public string Genres { get; set; }

        [NotMapped] public int UpVotes { get; set; }
        [NotMapped] public int DownVotes { get; set; }
    }
}