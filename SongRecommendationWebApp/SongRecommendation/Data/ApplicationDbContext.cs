using Microsoft.EntityFrameworkCore;
using SongRecommendation.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRecommendation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }
        public  DbSet<Genre> Genres { get; set; }
        public  DbSet<SongsDb> SongsDb { get; set; }

        public DbSet <UserRate> UserRates { get; set; }
    }
}
