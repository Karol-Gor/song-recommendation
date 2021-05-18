using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SongRecommendation.Model
{
    public partial class UserRate
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? SongId { get; set; }
        public int? Rate { get; set; }
    }
}
