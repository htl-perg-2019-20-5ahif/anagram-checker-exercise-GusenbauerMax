using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramChecker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAnagramChecker.Controllers
{
    [ApiController]
    [Route("api")]
    public class AnagramCheckerController : ControllerBase
    {
        private readonly IDictionaryReader reader;
        private readonly IAnagramChecker checker;

        public AnagramCheckerController(IDictionaryReader reader, IAnagramChecker checker)
        {
            this.reader = reader;
            this.checker = checker;
        }

        public IDictionaryReader Reader { get; }

        public IAnagramChecker Checker { get;  }

        [HttpGet("checkAnagram")]
        public IActionResult Get([FromBody] Words words)
        {
            if (words.w1 == null || words.w1 == null) return BadRequest();
            if (checker.CheckForAnagram(words.w1, words.w2))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("getKnownAnagram")]
        public IActionResult Get(string w)
        {
            if (w == null) return BadRequest();
            AnagramChecker.Dictionary dict = reader.Read();
            AnagramChecker.DictionaryEntry entry = dict.getEntryForKey(w);
            return Ok(entry.words);
        }
    }
}
