using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using URLShorter.Models;
using static URLShorter.Models.URLContext;

namespace URLShorter.Controllers
{
    /// <summary>A controller for handling urls.</summary>
    [ApiController]
    [Route("[controller]")]
    public class URLController : ControllerBase
    {
        /// <summary>The context.</summary>
        private readonly URLContext _context;

        /// <summary>Constructor.</summary>
        /// <param name="context">The context. </param>
        public URLController(URLContext context)
        {
            _context = context;
        }

        /// <summary>(An Action that handles HTTP POST requests) posts an URL.</summary>
        /// <param name="url">URL of the resource. </param>
        /// <returns>An IActionResult.</returns>
        [HttpPost("")]
        public IActionResult PostUrl([FromBody] Url url)
        {
            try
            {
                var newKey = Guid.NewGuid().ToString("N").Substring(0, 8).ToLower();
                url.ShortenUrl = "https://localhost:44318/" + newKey;
                URLBLL.AddUrl(_context, url);
                _context.SaveChanges();
                return Ok(url);
            }
            catch (Exception e)
            {
                return BadRequest(new Exception("Can't post!", e));
            }
        }

        /// <summary>(An Action that handles HTTP GET requests) gets an URL.</summary>
        /// <param name="shortenUrl">URL of the shorten. </param>
        /// <returns>The URL.</returns>
        [HttpGet("")]
        public IActionResult GetUrl(string shortenUrl)
        {
            try
            {
                var url = URLBLL.GetUrl(_context, shortenUrl);
                _context.SaveChanges();
                return Ok(url);
            }
            catch (Exception e)
            {
                return BadRequest(new Exception("Can't get!", e));
            }
        }

        /// <summary>(An Action that handles HTTP DELETE requests) deletes the URL described by urlId.
        /// </summary>
        /// <param name="urlId">Identifier for the URL. </param>
        /// <returns>An IActionResult.</returns>
        [HttpDelete("")]
        public IActionResult DeleteUrl(Guid urlId)
        {
            try
            {
                URLBLL.DeleteUrl(_context, urlId);
                return Ok( new Response()
                               {
                                   Success = true
                               });
            }
            catch (Exception e)
            {
                return BadRequest(new Exception("Can't get!", e));
            }
        }

        /// <summary>(An Action that handles HTTP GET requests) gets the urls.</summary>
        /// <param name="code">URL of the shorten. </param>
        /// <returns>The urls.</returns>
        [Route("all")]
        [HttpGet]
        public List<Statistic> GetUrls(string code)
        {
            try
            {
                return URLBLL.GetUrls(code, _context).ToList();

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
