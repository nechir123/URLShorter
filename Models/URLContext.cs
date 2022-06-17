using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLShorter.Models
{
    public class URLContext : DbContext
    {
        public URLContext(DbContextOptions<URLContext> options)
    : base(options)
        {

        }

        public DbSet<Url> Urls { get; set; }
        public DbSet<Record> Records { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>()
                .HasOne(u => u.Url)
                .WithMany(r => r.Records)
                .HasForeignKey(p => p.UrlId);

        }


        public class Url
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid UrlId { get; set; }
            public string ShortenUrl { get; set; }
            public string OriginalUrl { get; set; }

            public List<Record> Records { get; set; }
        }

        public class Record
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid RecordId { get; set; }
            public Guid UrlId { get; set; }

            public DateTime ClickDate { get; set; }

            public Url Url { get; set; }

            
        }

    }
}
