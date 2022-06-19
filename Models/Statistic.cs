
namespace URLShorter.Models
{
    using System;

    /// <summary>A statistic.</summary>
    public class Statistic
    {
        /// <summary>Gets or sets the identifier of the URL.</summary>
        /// <value>The identifier of the URL.</value>
        public Guid UrlId { get; set; }

        /// <summary>Gets or sets the click date.</summary>
        /// <value>The click date.</value>
        public DateTime ClickDate { get; set; }

        /// <summary>Gets or sets URL of the shorten.</summary>
        /// <value>The shorten URL.</value>
        public string ShortenUrl { get; set; }

        /// <summary>Gets or sets URL of the original.</summary>
        /// <value>The original URL.</value>
        public string OriginalUrl { get; set; }
    }
}
