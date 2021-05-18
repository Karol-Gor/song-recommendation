using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SongRecommendation.Model
{
    [Table("SongsDB")]
    public partial class SongsDb
    {
        [Key]
        [Column("id")]
        public short Id { get; set; }
        [Required]
        [Column("artist_name")]
        public string ArtistName { get; set; }
        [Column("release_id")]
        public int ReleaseId { get; set; }
        [Required]
        [Column("release_name")]
        public string ReleaseName { get; set; }
        [Required]
        [Column("song_id")]
        public string SongId { get; set; }
        [Column("terms")]
        public string Terms { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("year")]
        public short? Year { get; set; }
    }
}
