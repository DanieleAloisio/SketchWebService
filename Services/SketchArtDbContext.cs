using Microsoft.EntityFrameworkCore;
using SketchWebService.Models;

namespace SketchWebService.Services
{
    public class SketchArtDbContext : DbContext
    {
        public SketchArtDbContext(DbContextOptions<SketchArtDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sketch> Sketchs { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sketch>() //Uno Sketch
           .HasOne<Artist>(s => s.Artist) //ha un artista
           .WithMany(g => g.Sketchs) //ad un artista corrispondono molti sketch
           .HasForeignKey(s => s.IdArtist); //la chiave esterna dell'entity

            modelBuilder.Entity<User>()
            .HasOne<Role>(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.IdRole);

            modelBuilder.Entity<Artist>()
            .HasOne<User>(x => x.User)
            .WithOne(x => x.Artist)
            .HasForeignKey<Artist>(x => x.IdArtist);
        }
    }
}
