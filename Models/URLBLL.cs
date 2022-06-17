using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static URLShorter.Models.URLContext;

namespace URLShorter.Models
{
    public class URLBLL
    {

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

        public static Url GetUrl(URLContext context, string shortenUrl)
        {
            try
            {
                Url url = context.Urls.First(url => url.ShortenUrl == shortenUrl);
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

        public static IEnumerable<Url> GetUrls(URLContext context)
        {
            IEnumerable<Url> urls = new List<Url>();
            try
            {
                urls = context.Urls.AsNoTracking().ToArray();

            }
            catch (Exception e)
            {
                throw e;
            }

            return urls;
        }

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
