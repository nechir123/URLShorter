using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using URLShorter.Models;
using static URLShorter.Models.URLContext;

namespace URLShorter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class URLController : ControllerBase
    {

        private readonly URLContext _context;

        public URLController(URLContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public IActionResult PostUrl([FromBody] Url url)
        {
            try
            {
                var newKey = Guid.NewGuid().ToString("N").Substring(0, 8).ToLower();
                url.ShortenUrl = "https://localhost:44318/"+ newKey;
                URLBLL.AddUrl(_context, url);
                _context.SaveChanges();
                return Ok(url);
            }
            catch (Exception e)
            {
                return BadRequest(new Exception("Can't post!", e));
            }
        }
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

        [HttpDelete("")]
        public IActionResult DeleteUrl(Guid urlId)
        {
            try
            {
                URLBLL.DeleteUrl(_context, urlId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new Exception("Can't get!", e));
            }
        }


        [Route("all")]
        [HttpGet]
        public List<Url> GetUrls()
        {
            try
            {
                return URLBLL.GetUrls(_context).ToList();

            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
