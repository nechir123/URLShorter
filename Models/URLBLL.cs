using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static URLShorter.Models.URLContext;

namespace URLShorter.Models
{
    /// <summary>An urlbll.</summary>
    public class URLBLL
    {
        /// <summary>Adds an URL to 'url'.</summary>
        /// <exception cref="DbUpdateException">Thrown when a Database Update error condition occurs. </exception>
        /// <exception cref="Exception">        Thrown when an exception error condition occurs. </exception>
        /// <param name="context">The context. </param>
        /// <param name="url">    URL of the resource. </param>
        /// <returns>An URL.</returns>
        public static Url AddUrl(URLContext context, Url url)
        {
            try
            {
                context.Urls.Add(url);
                context.SaveChanges();
                return url;

            }
            catch (DbUpdateException dbE)
            {
                throw dbE;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>Gets an URL.</summary>
        /// <exception cref="DbUpdateException">Thrown when a Database Update error condition occurs. </exception>
        /// <exception cref="Exception">        Thrown when an exception error condition occurs. </exception>
        /// <param name="context">   The context. </param>
        /// <param name="shortenUrl">URL of the shorten. </param>
        /// <returns>The URL.</returns>
        public static Url GetUrl(URLContext context, string shortenUrl)
        {
            try
            {
                Url url = context.Urls.First(u => u.ShortenUrl == shortenUrl);
                Record newRecord = new Record()
                {
                    UrlId = url.UrlId,
                    ClickDate = DateTime.Now
                };
                context.Records.Add(newRecord);
                return url;

            }
            catch (DbUpdateException dbE)
            {
                throw dbE;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>Gets the urls in this collection.</summary>
        /// <exception cref="Exception">Thrown when an exception error condition occurs. </exception>
        /// <param name="code">   URL of the shorten. </param>
        /// <param name="context">The context. </param>
        /// <returns>An enumerator that allows foreach to be used to process the urls in this collection.
        /// </returns>
        public static IEnumerable<Statistic> GetUrls(string code, URLContext context)
        {
            IEnumerable<Statistic> statistics = new List<Statistic>();
            try
            {
                statistics = context.Urls.Where(a => a.ShortenUrl.Contains(code))
                    .Join(
                        context.Records,
                        url => url.UrlId,
                        record => record.UrlId,
                        (url, record) => new Statistic
                                              {
                                                  ClickDate = record.ClickDate,
                                                  UrlId = url.UrlId,
                                                  ShortenUrl = url.ShortenUrl,
                                                  OriginalUrl = url.OriginalUrl
                                              });
            }
            catch (Exception e)
            {
                throw e;
            }

            return statistics;
        }

        /// <summary>Deletes the URL.</summary>
        /// <exception cref="ArgumentException">Thrown when one or more arguments have unsupported or
        ///                                     illegal values. </exception>
        /// <param name="context">The context. </param>
        /// <param name="urlId">  Identifier for the URL. </param>
        public static void DeleteUrl (URLContext context, Guid urlId)
        {
            try
            {
                if (urlId == Guid.Empty)
                {
                    throw new ArgumentException();
                }

                var url = new Url
                {
                    UrlId = urlId
                };
                context.Urls.Remove(url);
                context.SaveChanges();
            }
            catch (DbUpdateException dbE)
            {
            }
            catch (Exception e)
            {
            }
        }
    }
}
