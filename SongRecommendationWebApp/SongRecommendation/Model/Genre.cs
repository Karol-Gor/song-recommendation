using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SongRecommendation.Model
{
    [Keyless]
    public partial class Genre
    {
        [Required]
        [Column("Genre")]
        [StringLength(50)]
        public string Genre1 { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
