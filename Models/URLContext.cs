using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLShorter.Models
{
    /// <summary>An URL context.</summary>
    public class URLContext : DbContext
    {
        /// <summary>Constructor.</summary>
        /// <param name="options">Options for controlling the operation. </param>
        public URLContext(DbContextOptions<URLContext> options)
    : base(options)
        {

        }

        /// <summary>Gets or sets the urls.</summary>
        /// <value>The urls.</value>
        public DbSet<Url> Urls { get; set; }

        /// <summary>Gets or sets the records.</summary>
        /// <value>The records.</value>
        public DbSet<Record> Records { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        /// <summary>An url.</summary>
        public class Url
        {
            /// <summary>Gets or sets the identifier of the URL.</summary>
            /// <value>The identifier of the URL.</value>
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid UrlId { get; set; }

            /// <summary>Gets or sets URL of the shorten.</summary>
            /// <value>The shorten URL.</value>
            public string ShortenUrl { get; set; }

            /// <summary>Gets or sets URL of the original.</summary>
            /// <value>The original URL.</value>
            public string OriginalUrl { get; set; }
        }

        /// <summary>A record.</summary>
        public class Record
        {
            /// <summary>Gets or sets the identifier of the record.</summary>
            /// <value>The identifier of the record.</value>
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid RecordId { get; set; }

            /// <summary>Gets or sets the identifier of the URL.</summary>
            /// <value>The identifier of the URL.</value>
            public Guid UrlId { get; set; }

            /// <summary>Gets or sets the click date.</summary>
            /// <value>The click date.</value>
            public DateTime ClickDate { get; set; }
        }
    }
}
